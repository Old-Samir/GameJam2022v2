using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Collider2D feet;
    [SerializeField] AudioClip maleDeathSFX;
    public bool isActive = true;
    bool wasKilled = false;
    bool canMove = true;

    Vector2 moveDirection;
    Vector2 rawInput;
    bool isJumping;
    Rigidbody2D rb;
    float failReload = 1.00f;
    const string platformLayer = "Platform";

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Move the player if they're alive
        if(canMove)
        {
            rb.velocity = new Vector2(rawInput.x * moveSpeed, rb.velocity.y);

        //Make the player jump
            if (isJumping)
            {
                rb.velocity += new Vector2(0f, jumpForce);
                isJumping = false;
            }
        }
    }

    //Used by the input system 
    void OnMove(InputValue value)
    {
        if (!isActive) { return; }
        rawInput = value.Get<Vector2>();
    }

    //Used by the input system
    void OnJump(InputValue value)
    {
        if (!isActive) { return; }
        if (!feet.IsTouchingLayers(LayerMask.GetMask(platformLayer))) { return; }

        isJumping = true;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
     {
        if ((other.gameObject.tag == "Spikey" || other.gameObject.tag == "Enemy") && !wasKilled)
         {
             //wasKilled = true was added as a bug fix to prevent the death counter from removing two lives on death
            wasKilled = true;
            canMove = false;
            GetComponent<AudioSource>().PlayOneShot(maleDeathSFX);
            Invoke("DeathBegins", failReload);
            Debug.Log ("oww");
         } 
    }

    void DeathBegins()
    {
        FindObjectOfType<Heart_Score_Counter>().ProcessPlayerDeath();
    }
}
