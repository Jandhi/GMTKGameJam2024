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
    public bool isDead = false;
    public GameObject spawnPoint;

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

    public void Die()
    {
        this.isDead = true;
        StartCoroutine(DelayedSpawn());
    }

    IEnumerator DelayedSpawn()
    {
        yield return new WaitForSeconds(1.0f);
        Respawn();
    }

    void Respawn()
    {
        this.isDead = false;
        transform.position = spawnPoint.transform.position;
        GetComponent<Rigidbody2D>().totalForce = Vector2.zero;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    void Update()
    {
        if(isDead) return;
        
        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Vertical") || Input.GetKey(KeyCode.Space))
        {
            jumpInput = 1;
        }
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            SquashManager.Instance.ToggleSquash(transform.position);
        }
        if (Input.GetKeyDown(KeyCode.Period))
        {
            SquashManager.Instance.ToggleSquash(transform.position, true);
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
