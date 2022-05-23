using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyDiamonds : MonoBehaviour
{
    public void Awake()
    {
        GameObject[] countDiamondsCountObject = GameObject.FindGameObjectsWithTag("DiamondsCount");
        
        if(countDiamondsCountObject.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
