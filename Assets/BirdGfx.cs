using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BirdGfx : MonoBehaviour
{
    [SerializeField] private AIPath aiPath;
    private SpriteRenderer sprite;

    private bool flip = false;
    private Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            sprite.flipX = true;
        }
        else if (aiPath.desiredVelocity.x <= -0.01)
        {
            sprite.flipX = false;
        }


    }
}
