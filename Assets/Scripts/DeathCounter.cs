using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCounter : MonoBehaviour
{
    
    public GameObject[] hearts;

    bool dead;

    [SerializeField] int playerLife;

    [SerializeField] TextMeshProUGUI livesText;
    public int LifeCounter ()
    {
        return (playerLife);
    }

    void Awake()
    {
        int numGameSessions = FindObjectsOfType<DeathCounter>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

 void Start() 
 {
        livesText.text = playerLife.ToString();

    }


    // private void Start() 
    // {
    //     life = hearts.Length;
    // }


    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            Debug.Log ("Am Dead");
            SceneManager.LoadScene("MainMenu");
            dead = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
         if (other.gameObject.tag == "Spikey")
         {
             takeDamage(1);
             Debug.Log ("oww");

         } 
    } 

    public void takeDamage(int damage)
    {
        if (playerLife> 0)
        {
        playerLife -= damage;
         Destroy(hearts[playerLife].gameObject);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        livesText.text = playerLife.ToString();
        SceneManager.LoadScene(currentSceneIndex);
       // Destroy(gameObject);
        if (playerLife <1 )
          {
             dead = true;
         }
        }

    }
}
