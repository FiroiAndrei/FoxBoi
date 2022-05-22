using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollect : MonoBehaviour
{
    private int diamonds = 0;

    [SerializeField] private Text diamondsText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Diamond"))
        {
            Destroy(collision.gameObject);
            diamonds++;
            diamondsText.text = "" + diamonds;
        }
    }

}
