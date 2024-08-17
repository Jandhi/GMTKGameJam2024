using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpSpeed = 10f;
    private Rigidbody2D rb;

    [SerializeField] bool canJump = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LayerMask mask = LayerMask.GetMask("Platform");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis ("Horizontal"); 
        float jumpInput = Mathf.Max(Input.GetAxis("Jump") , Input.GetAxis("Vertical"));


        Vector2 movementDir = new Vector2(horizontalInput, 0);

        Debug.Log(jumpInput);

        rb.AddForce(movementDir * moveSpeed);

        Jump( jumpInput);
    
    }

    void InputHandling()
    {

    }

    void Jump(float jumpInput)
    {
        if(canJump && jumpInput >0)
        {
            rb.AddForce(transform.up * jumpSpeed *jumpInput, ForceMode2D.Impulse);
            canJump = false;
        }
        else if(!canJump)
        {

        }
    }
}
