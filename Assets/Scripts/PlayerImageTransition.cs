using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerImageTransition : MonoBehaviour
{
    [SerializeField] Image playerImage;
    [SerializeField] Color playerStartColor;
    [SerializeField] Color playerEndColor;

    // Update is called once per frame
   
   private void Awake() 
   {
       playerImage.color = playerStartColor;
   }
   
    void Update()
    {

    }
}
