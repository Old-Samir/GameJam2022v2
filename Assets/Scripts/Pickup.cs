using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] int pickupCoin = 1;
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        Wallet wallet = other.GetComponent<Wallet>();
        
        if (other.tag == "Player")
        {
            FindObjectOfType<Heart_Score_Counter>().AddToScore(pickupCoin);
            wallet.IncrementCoins();
            Destroy(gameObject);
        }

        //Add the coin to the player wallet when collectd
        
        // if(wallet != null)
        // {
        //     wallet.IncrementCoins();
        //     Destroy(gameObject);
        // }
    }
}
