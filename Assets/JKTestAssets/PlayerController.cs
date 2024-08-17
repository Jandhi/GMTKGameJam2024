using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpSpeed = 10f;
    private Rigidbody2D rb;
    private float jumpInput;

    [SerializeField] EdgeCollider2D feetCollider;
    [SerializeField] EdgeCollider2D rightCollider;
    [SerializeField] EdgeCollider2D leftCollider;
    LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mask = LayerMask.GetMask("Platform");
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Vertical"))
        {
            jumpInput = 1;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis ("Horizontal"); 
        // = Mathf.Max(Input.GetAxis("Jump") , Input.GetAxis("Vertical"));

        if((rightCollider.IsTouchingLayers(mask) && horizontalInput>0) || (leftCollider.IsTouchingLayers(mask) && horizontalInput<0))
        {
            horizontalInput = 0f;
        }

        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        Jump();
    
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            Squashable.ToggleSquash(transform.position);
        }
        if (Input.GetKeyDown(KeyCode.Period))
        {
            Squashable.ToggleSquash(transform.position, true);
        }
    }

    void InputHandling()
    {

    }

    void Jump()
    {
        if(feetCollider.IsTouchingLayers(mask) && jumpInput >0)
        {
            rb.AddForce(transform.up * jumpSpeed *jumpInput, ForceMode2D.Impulse);
        }
        else
        {
            jumpInput = 0;
        }
    }
}
