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
    private float horizontalInput;
    private float animationHorizontalInput;
    private Animator ani;
    private SpriteRenderer spr;
    public bool isDead = false;
    public GameObject spawnPoint;
    public float SuckDuration = 0.5f;

    [SerializeField] EdgeCollider2D feetCollider;
    [SerializeField] EdgeCollider2D rightCollider;
    [SerializeField] EdgeCollider2D leftCollider;
    LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mask = LayerMask.GetMask("Platform");
        ani = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    public void Die()
    {
        this.isDead = true;
        ani.SetBool("IsDead", true);
        StartCoroutine(DelayedSpawn());
    }

    IEnumerator DelayedSpawn()
    {
        yield return new WaitForSeconds(1.0f);
        Respawn();
    }

    void Respawn()
    {
        ani.SetBool("IsDead", false);
        this.isDead = false;
        transform.position = spawnPoint.transform.position + Vector3.up * 0.1f;
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
        if (Input.GetButtonDown("HorizontalSqueeze"))
        {
            SquashManager.Instance.ToggleSquash(transform.position);
        }
        if (Input.GetButtonDown("VerticalSqueeze"))
        {
            SquashManager.Instance.ToggleSquash(transform.position, true);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis ("Horizontal"); 
        animationHorizontalInput = horizontalInput;
        // = Mathf.Max(Input.GetAxis("Jump") , Input.GetAxis("Vertical"));

        if((rightCollider.IsTouchingLayers(mask) && horizontalInput>0) || (leftCollider.IsTouchingLayers(mask) && horizontalInput<0))
        {
            horizontalInput = 0f;
        }

        if(isDead)
        {
            return;
        }

        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        Jump();
        HandleAnimation();
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

    void HandleAnimation()
    {
        //set direction facing
        if(animationHorizontalInput < 0)
        {
            spr.flipX = false;
        }
        else if( animationHorizontalInput > 0)
        {
            spr.flipX = true;
        }
        

        if(feetCollider.IsTouchingLayers(mask))
        {
            ani.SetBool("IsJumping" , false); 

            if(Mathf.Abs(animationHorizontalInput) > 0f)
            {
                ani.SetBool("IsRunning", true);
            }
            else
            {
                ani.SetBool("IsRunning", false);
            }
        }
        else 
        {
            ani.SetBool("IsJumping" , true);
            
            if(rb.velocity.y < 0)
            {
                ani.SetBool("IsFalling", true);
            }
            else
            {
                ani.SetBool("IsFalling", false);
            }
        }
    }
    
    public void SuckIn(Vector3 position)
    {
        this.GetComponent<Rigidbody2D>().simulated = false;
        Tween.Position(transform, new Vector3(position.x, position.y, transform.position.z), SuckDuration, 0.0f);
        Tween.Rotation(transform, new Vector3(0f, 0f, (360f * 3f)), SuckDuration, 0.0f);
        Tween.LocalScale(transform, Vector2.zero, SuckDuration, 0.0f);
    }

    public void SuckOut(Vector3 position)
    {
        transform.position = position;
        Tween.Position(transform, new Vector3(position.x, position.y, transform.position.z), SuckDuration, 0.0f);
        Tween.Rotation(transform, new Vector3(0f, 0f, (360f * -3f)), SuckDuration, 0.0f);
        Tween.LocalScale(transform, Vector2.one, SuckDuration, 0.0f);
        StartCoroutine(SuckOutEnd());
    }

    IEnumerator SuckOutEnd()
    {
        yield return new WaitForSeconds(SuckDuration);
        this.GetComponent<Rigidbody2D>().simulated = true;
    }
}
