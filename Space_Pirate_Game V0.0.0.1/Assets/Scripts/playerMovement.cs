using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    [SerializeField] private LayerMask jumpableGround;

    private enum movementState {idle, running, jumping, falling } //UDT in Logix. each comma is refferenced in an INT

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal"); //"Horizontal" and "Jump" are Unity key maps within project settings that will allow players to change key maps later vs hard coding
        rb.velocity = new Vector2 (dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded()) //Only execute when space is pressed down
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x,jumpForce); //Get the ridged body component's velocity and apply a force vector of X,Y
        }

        UpdateAnimationState();

    }

    private void UpdateAnimationState()
    {
        movementState state;

        if (dirX > 0.1f) //moving right
        {
            state = movementState.running; // In Animator window
            sprite.flipX = false;
        }
        else if (dirX < 0) //moving left
        {
            state = movementState.running;
            sprite.flipX = true;
        }
        else // Not Moving
        {
            state = movementState.idle;
        }

        if(rb.velocity.y > 0.1f)
        {
            state = movementState.jumping;
        }
        else if  (rb.velocity.y < -0.1f)
        {
            state = movementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        //creates a new box around the player 0.1f down that will check if the player is on the ground
        return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
