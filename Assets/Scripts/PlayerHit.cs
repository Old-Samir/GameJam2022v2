using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    [SerializeField] Color playerHit = Color.white;
    [SerializeField] Color normalPlayer = Color.green;
    [SerializeField] float betweenColors = .1f;
    [SerializeField] float timeToFlash = 5;
    SpriteRenderer spriteRenderer;


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = normalPlayer;
    }


    public void CallFlasher()
    {
        StartCoroutine(Flasher());
    }

    IEnumerator Flasher() 
    {
        for (int i = 0; i < timeToFlash; i++)
        {
            spriteRenderer.color = playerHit;
            yield return new WaitForSeconds(betweenColors);
            spriteRenderer.color = normalPlayer;
            yield return new WaitForSeconds(betweenColors);
        }
    }
}
