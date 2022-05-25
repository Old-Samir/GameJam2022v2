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

    //Add None UI build index Levels in the array
    public int[] noneUILevels = new int[] {1};

    int coinsPlayerHas;

    bool isUnlocked;

    void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultColor;

        //GetCoinCount needs to be run twice, once for every scene reload (in this method), and
        //the other in the Update in order for the currently picked up coints to count
        coinsPlayerHas = FindObjectOfType<Heart_Score_Counter>().GetCoinCount();
    }

    void Update()
    {
        //Check if player has enough coins to unlock the goal
        
        coinsPlayerHas = FindObjectOfType<Heart_Score_Counter>().GetCoinCount();
        
        if(coinsPlayerHas >= maxCoinsInScene)
        {
            isUnlocked = true;
            spriteRenderer.color = unlockColor;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(isUnlocked)
        {         
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // "1" need to equal the intro levels, or any other levels that do not utilize a UI
        for (int i = 0; SceneManager.GetActiveScene().buildIndex != noneUILevels[i]; i++)
        {
            FindObjectOfType<Heart_Score_Counter>().ResetCoinCounter();
        }

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(nextSceneIndex);
    }

}
