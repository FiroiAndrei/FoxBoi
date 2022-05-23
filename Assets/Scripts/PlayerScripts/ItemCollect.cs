using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollect : MonoBehaviour
{
    private int diamonds = 0;

    [SerializeField] private Text diamondsText;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Diamond"))
        {
            Destroy(collision.gameObject);
            collectionSoundEffect.Play();
            diamonds++;
            diamondsText.text = "" + diamonds;
        }
    }

}
