using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTransition : MonoBehaviour
{
    [SerializeField] SpriteRenderer doorClosed;
    [SerializeField] Sprite doorOpen;
    [SerializeField] SpriteRenderer doorTopClosed;
    [SerializeField] Sprite doorTopOpen;



    public void DoorClosedToOpen() 
    {
        doorClosed.sprite = doorOpen;
        doorTopClosed.sprite = doorTopOpen;
    }

}
