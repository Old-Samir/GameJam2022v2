using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Goal : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI counterDisplay;
    [SerializeField] int maxCoinsInScene;
    [SerializeField] Color defaultColor = Color.red;
    [SerializeField] Color unlockColor = Color.blue;
    [SerializeField] float levelLoadDelay = 1f;
    SpriteRenderer spriteRenderer;
    Wallet playerWallet;

    bool isUnlocked;

    void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultColor;
        playerWallet = FindObjectOfType<Wallet>();
    }

    void Update()
    {
        //Check if player has enough coins to unlock the goal
        if(playerWallet.GetCoins() >= maxCoinsInScene)
        {
            isUnlocked = true;
            spriteRenderer.color = unlockColor;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Complete the level if the player has enough coins
        if (other.GetComponent<Wallet>() == playerWallet)
        {
            if(isUnlocked)
            {
                // Reload Level
                // LevelManager.Instance.ReloadLevel();

                //Load New Level
                StartCoroutine(LoadNextLevel());
                //Reset coin counter (does not work)
                FindObjectOfType<Heart_Score_Counter>().ResetCoinCounter();
                //FindObjectOfType<Heart_Score_Counter>().LevelBeaten();
                //Destroy(GetComponent<Heart_Score_Counter>().CoinText);
                //LevelManager.Instance.LoadNewLevel();
            }
        }
    }

    public string ReturnWallet()
    {
        return(playerWallet.GetCoins().ToString());
    }

    public string ReturnCoinTarget()
    {
        return (maxCoinsInScene.ToString());
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(nextSceneIndex);
    }

}
