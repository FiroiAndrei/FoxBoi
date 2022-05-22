using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animation;

    public bool isHurting;
    private bool trapRight;
    public int healthPoints = 4;
    public bool enemyDead;
    private bool damageFromEnemy = false;

    private Renderer rend;
    private Color c;

    public Image[] hearts;
    public Sprite emptyHeart;
    [SerializeField] private float hurtForce = 11f;

    private void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
        rend = GetComponent<Renderer> ();
        c = rend.material.color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FrogController frog = collision.collider.GetComponent<FrogController>();
        if ((collision.gameObject.tag == "Trap" || collision.gameObject.tag == "Enemy") && healthPoints > 0 )
        {
            if(collision.gameObject.tag == "Enemy")
            {
                foreach (ContactPoint2D point in collision.contacts)
                {
                    Debug.Log(point.normal);
                    Debug.DrawLine(point.point, point.point + point.normal, Color.red, 10);
                    if(point.normal.y >= 0.9f)
                    {
                        break;
                    }
                    else
                    {
                        damageFromEnemy = true;
                        Debug.Log(damageFromEnemy);
                    }
                }

                if(damageFromEnemy == true)
                {
                    healthPoints -= 1;
                    hearts[healthPoints].sprite = emptyHeart;
                    damageFromEnemy = false; 
                }
            }
            if(collision.gameObject.tag == "Trap")
            {
                healthPoints -= 1;
                hearts[healthPoints].sprite = emptyHeart;
            }

            if(healthPoints > 0)
            {
                if(collision.gameObject.tag == "Enemy")
                {
                    foreach (ContactPoint2D point in collision.contacts)
                    {
                        if(point.normal.y >= 0.9f)
                        {
                            rb.velocity = new Vector2(rb.velocity.x, 15);
                            frog.frogIsDead();
                        }
                        else
                        {
                            if(collision.gameObject.transform.position.x > transform.position.x)  
                                trapRight = true; //trap is to right so i move to right
                            else
                                trapRight = false; //trap is to left so i move to left
                            StartCoroutine ("Hurt");
                        }
                    } 
                }
                else
                {
                    if(collision.gameObject.transform.position.x > transform.position.x)  
                        trapRight = true; //trap is to right so i move to right
                    else
                        trapRight = false; //trap is to left so i move to left
                    StartCoroutine ("Hurt");
                }       
            }
            
        }
    }

	IEnumerator Hurt()
	{
        StartCoroutine ("Invincibility"); 
        animation.SetBool("isHurting", true);
		isHurting = true;
		rb.velocity = Vector2.zero;

		if (trapRight == true)
			rb.velocity = new Vector2(-hurtForce, rb.velocity.y);
		else
			rb.velocity = new Vector2(hurtForce, rb.velocity.y);
		
		yield return new WaitForSeconds (0.5f);
        animation.SetBool("isHurting", false);
		isHurting = false;
          
	}

    IEnumerator Invincibility()
    {
        Physics2D.IgnoreLayerCollision (6,10,true);
        Physics2D.IgnoreLayerCollision (6,9,true);
        c.a = 0.5f;
        rend.material.color = c;
        yield return new WaitForSeconds (1f);
        Physics2D.IgnoreLayerCollision (6,10,false);
        Physics2D.IgnoreLayerCollision (6,9,false);
        c.a = 1f;
        rend.material.color = c;
    }     
}
