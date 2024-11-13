using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    private Transform startPosition;
    public float speed;
    public float jumpForce;
    public Rigidbody2D rb;

    private bool canJump = false;
    private bool climbing = false;

    private float climbSpeed = 1;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        startPosition = this.transform;
    }

    void Update()
    {
        Move();

        if (Input.GetKey(KeyCode.Space) && canJump)
        {
            Jump();
        }
        //Debug.Log(startPosition.position);

    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = 0;

        if (climbing)
        {
            verticalInput = Input.GetAxis("Vertical");
        }

        Vector2 movement = new Vector2(horizontalInput * speed, verticalInput * speed);
        rb.linearVelocity = movement;
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            canJump = true;

            if(other.gameObject.GetComponent<Animator>() != null)
                this.transform.SetParent(other.transform);
        }

        if (other.gameObject.name == "Base")
        {
            this.transform.position = new Vector2(startPosition.position.x, startPosition.position.y);
            //Debug.Log(startPosition.position);
        }
            
    }
    
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            canJump = false;
            if(this.transform.parent != null)
                this.transform.SetParent(null);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Climbable")
            climbing = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Climbable" && climbSpeed < 2)
            climbSpeed++;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Climbable")
        {
            climbing = false;
            if(climbSpeed > 1)
                climbSpeed--;
        }
            
    }
}
