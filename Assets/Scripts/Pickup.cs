using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] int pickupCoin = 1;
    
    void OnTriggerEnter2D(Collider2D other) 
    {      
        if (other.tag == "Player")
        {
            FindObjectOfType<Heart_Score_Counter>().AddToScore(pickupCoin);
            Destroy(gameObject);
        }
    }
}
