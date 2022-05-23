using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleGfx : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x >= 0.01f)
        {
            sprite.flipX = true;
        }
        else if (rb.velocity.x <= -0.01 )
        {
            sprite.flipX = true;
        }



    }
}
