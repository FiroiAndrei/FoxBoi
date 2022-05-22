using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator animation;

    private float dirX = 0f;

    [SerializeField] private LayerMask jumpGround;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;   

    private enum State { idle, running, jumping, falling}
    private State state = State.idle;

    private void Start ()
    {       
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        animation = GetComponent<Animator>();
    }

    private void Update()
    {

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

	    dirX = Input.GetAxisRaw ("Horizontal") * moveSpeed;       
        UpdateAnimationState();

    }

	void FixedUpdate()
	{
		if (GameObject.Find("Player").GetComponent<HealthSystem>().isHurting == false)
			rb.velocity = new Vector2 (dirX, rb.velocity.y);

    }

    private void UpdateAnimationState()
    {
        sprite = GetComponent<SpriteRenderer>();

        if (dirX > 0f)
        {
            state = State.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = State.running;
            sprite.flipX = true;
        }
        else
        {
            state = State.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = State.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = State.falling;
        }

        animation.SetInteger("state", (int)state);

    }

    private bool IsGrounded()
    {

       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpGround);

    }

}