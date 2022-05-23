using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Heart_Score_Counter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI CoinText;
    [SerializeField] int playerLives;
    public int coinScore = 0;

    public int resetCoinScore = 0;

    void Awake()
    {
        int numGameSessions = FindObjectsOfType<Heart_Score_Counter>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() 
    {
      livesText.text = playerLives.ToString();
      CoinText.text = coinScore.ToString();
    }

    // private void Update() {
    //     CoinCounter();
    // }

    public void AddToScore(int pointsToAdd)
    {
        coinScore += pointsToAdd;
        CoinText.text = coinScore.ToString();
    }
    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeDamage();
        }
        else
        {
            StartFromMainMenu();
        }

    }
    public void TakeDamage()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();  

    }
    void StartFromMainMenu()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    // void CoinCounter()
    // {
    //     CoinText.text = FindObjectOfType<Goal>().ReturnWallet() + " . " + FindObjectOfType<Goal>().ReturnCoinTarget();
    // }

    public void LevelBeaten()
    {
        Destroy(CoinText);
    }

    public void ResetCoinCounter()
    {
        coinScore = resetCoinScore;
        CoinText.text = resetCoinScore.ToString();
    }
}

