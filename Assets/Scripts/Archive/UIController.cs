using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    int target = 1;

    [SerializeField] Color defaultColor = Color.green;
    [SerializeField] Color unlockColor = Color.black;  
    Wallet playerWallet;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultColor;
        playerWallet = FindObjectOfType<Wallet>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerWallet.GetCoins() >= target)
        {
            spriteRenderer.color = unlockColor;
        }
    }
}
