using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerImageTransition : MonoBehaviour
{
    [SerializeField] Image playerImage;
    [SerializeField] Color playerStartColor;
    [SerializeField] Color playerEndColor;

    [SerializeField] Image coinImage;
    [SerializeField] Color coinStartColor;
    [SerializeField] Color coinEndColor;

    int maxCoins;
    int coinsPlayerHas;

    // Update is called once per frame
   
   private void Awake() 
   {
       playerImage.color = playerStartColor;
       coinImage.color = coinStartColor;
   }
   
    void Update()
    {

    }

    public void ColorCoinTransition()
    {
        coinImage.color = Color.Lerp(coinStartColor, coinEndColor, FindObjectOfType<Goal>().PercentofCoins());
    }

    public void ColorPlayerTransition()
    {
        playerImage.color = Color.Lerp(playerEndColor, playerStartColor, FindObjectOfType<Heart_Score_Counter>().PercentofPlayerLived());
    }
}
