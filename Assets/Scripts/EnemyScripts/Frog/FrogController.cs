using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator animation;
    public bool deadEnemy = false;


    private float dirX = 0f;

    [SerializeField] private LayerMask jumpGround;
    [SerializeField] private LayerMask spikes;

    [SerializeField] private float jumpForceX = 7f;
    [SerializeField] private float jumpForceY = 14f;
    [SerializeField] private float idleTime = 2f;
    private float currentIdleTime = 0;

    private string currentAnimation;

    const string FROG_IDLE = "Frog_idle";
    const string FROG_JUMP = "Frog_jump";
    const string FROG_FALL = "Frog_fall";
    const string FROG_DEATH = "Frog_death";

    [SerializeField] private bool flip = false;
    private bool isIdle = true;
    private bool isJumping = false;
    private bool isFalling = false;
    private bool isGrounded = true;
    private float lastYPos = 0f;

    //private enum State { idle, jumping, falling }
    //private State state = State.idle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        animation = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        lastYPos = transform.position.y;

    }

    void FixedUpdate()
    {

        if (SitOnSpikes())
        {
            frogIsDead();
        }

        

        if (isIdle)
        {
            currentIdleTime += Time.deltaTime;
            if (currentIdleTime >= idleTime)
            {
                currentIdleTime = 0;
                Jump();
                
            }
        }



        

        if (IsGrounded())
        {
            if (flip)
            {
                sprite.flipX = !sprite.flipX;
                flip = false;
            }
            isFalling = false;
            isJumping = false;
            isIdle = true;

            UpdateAnimationState(FROG_IDLE);


        }
        else if (transform.position.y > lastYPos)
        {
            isJumping = true;
            isFalling = false;
            UpdateAnimationState(FROG_JUMP);
        }
        else if (transform.position.y < lastYPos)
        {
            isJumping = false;
            isFalling = true;
            UpdateAnimationState(FROG_FALL);
        }

        lastYPos = transform.position.y;

    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpGround);
    }

    private bool SitOnSpikes()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, spikes);
    }

    void Jump()
    {
        flip = true;
        isJumping = true;
        isIdle = false;
        int direction;
        if (sprite.flipX == true)
            direction = -1;
        else
            direction = 1;

        rb.velocity = new Vector2(jumpForceX * direction, jumpForceY);
    }

    private void UpdateAnimationState(string newState)
    {
        if (currentAnimation == newState || currentAnimation == FROG_DEATH)
            return;
        else
            animation.Play(newState);
        currentAnimation = newState;

    }

    public void frogIsDead()
    {
        UpdateAnimationState(FROG_DEATH);
  
    }
    public void KillFrog()
    {
        Destroy(gameObject);

    }

}
