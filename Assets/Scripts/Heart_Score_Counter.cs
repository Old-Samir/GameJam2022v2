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

    public void AddToScore(int pointsToAdd)
    {
        //Adds 
        coinScore += pointsToAdd;
        CoinText.text = coinScore.ToString();
        Debug.Log("The player has " + coinScore + " coins.");
    }

    public int GetCoinCount()
    {
        //This function returns the total # of coins the user has collected in a level.
        //Used to determine if things like a goal can be activated.
        return coinScore;
    }
    public void ProcessPlayerDeath()
    {    
        if (playerLives > 1)
        {
            TakeDamage();
        }
        else
        {
            GoToCredits();
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
        FindObjectOfType<LevelManager>().LoadMainMenu();
        Destroy(gameObject);
    }
    void GoToCredits()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        FindObjectOfType<LevelManager>().LoadCredits();
        Destroy(gameObject);
    }
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

