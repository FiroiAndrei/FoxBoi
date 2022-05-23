using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animation;
    [SerializeField] private AudioSource playerDeathSoundEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();        
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Trap" || collision.gameObject.tag == "Enemy") && GameObject.Find("Player").GetComponent<HealthSystem>().healthPoints <= 1)
        {
            Debug.Log(GameObject.Find("Player").GetComponent<HealthSystem>().healthPoints);
            animation.SetTrigger("death");
            playerDeathSoundEffect.Play();
            rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
       
    }

    private void restartLevel()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
