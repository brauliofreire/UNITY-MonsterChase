using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    private Rigidbody2D myBody;
    private SpriteRenderer sRenderer;
    private Animator animator;
    private string WALK_ANIMATION = "Walk";
    private string TAG_GROUND = "Ground";

    private bool isGrounded = true;

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
        playerJump();
    }

    private void FixedUpdate()
    {
        
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

    void playerJump()
    {       
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TAG_GROUND))
        {
            isGrounded = true; 
        }
    }


}// class
