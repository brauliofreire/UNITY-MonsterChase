using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 5f;

    private float movementX;

    private Rigidbody2D myBody;
    private SpriteRenderer sRenderer;
    private Animator animator;
    private string WALK_ANIMATION = "Walk";
    private string TAG_GROUND = "Ground";
    private string TAG_ENEMY = "Enemy";

    private bool isGrounded = true;
    private bool isJumping = false;
    private float jumpingCounter = 0.4f;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        sRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    void Start()
    {
        
    }
    
    void Update()
    {
        PlayMoveKeyboard();
        animatePlayer();

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
        if (isJumping)
            jumpingCounter -= Time.deltaTime;

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpingCounter = 0.4f;
        }
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            if (jumpingCounter > 0)
                myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
        }
    }

    private void PlayMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    private void animatePlayer()
    {
        if(movementX > 0)
        {
            animator.SetBool(WALK_ANIMATION, true);
            sRenderer.flipX = false;
        }
        else
        if(movementX < 0)
        {
            animator.SetBool(WALK_ANIMATION, true);
            sRenderer.flipX = true;
        }
        else
        {
            animator.SetBool(WALK_ANIMATION, false);
        }

    }    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TAG_GROUND))
        {
            isGrounded = true; 
        }
        ////Catched by one enemy
        //if (collision.gameObject.CompareTag(TAG_ENEMY))
        //{
        //    Destroy(gameObject);
        //}
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TAG_GROUND))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Player Trigger: " + collision.gameObject.name);
        ////Catched by one enemy
        //if (collision.gameObject.CompareTag(TAG_ENEMY))
        //{
        //    Destroy(gameObject);
        //}
    }

}// class
