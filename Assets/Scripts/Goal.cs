using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Goal : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI counterDisplay;
    [SerializeField] int target;
    [SerializeField] Color defaultColor = Color.red;
    [SerializeField] Color unlockColor = Color.blue;   
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
        if(playerWallet.GetCoins() >= target)
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
            if(isUnlocked) {
                // Reload Level
                // LevelManager.Instance.ReloadLevel();

                //Load New Level
                LevelManager.Instance.LoadNewLevel();
            }
        }
    }

    public string ReturnWallet()
    {
        return(playerWallet.GetCoins().ToString());
    }

    public string ReturnCoinTarget()
    {
        return (target.ToString());
    }
}
