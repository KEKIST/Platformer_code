using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D call;
    private SpriteRenderer sprite;
    public MovementState state;

    [SerializeField] private LayerMask jumpableGround;

    float Dirx = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    public enum MovementState { idle, running, jumping, falling, death}

    [SerializeField] private AudioSource jumpSoundEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        call = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

  
    void Update()
    {
        if (state != MovementState.death)
        {
            Dirx = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(Dirx * moveSpeed, rb.velocity.y);

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                jumpSoundEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            }

        }



        updateAnimationState();
    }
    private void updateAnimationState()
    {
        if (state != MovementState.death)
        {
            if (Dirx > 0f)
            {
                state = MovementState.running;
                sprite.flipX = false;
            }
            else if (Dirx < 0f)
            {
                state = MovementState.running;
                sprite.flipX = true;
            }
            else if (state != MovementState.death)
            {
                state = MovementState.idle;
            }

            if (rb.velocity.y > .1f)
            {
                state = MovementState.jumping;
            }
            else if (rb.velocity.y < -.1f)
            {
                state = MovementState.falling;
            }
        }
        

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(call.bounds.center, call.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
