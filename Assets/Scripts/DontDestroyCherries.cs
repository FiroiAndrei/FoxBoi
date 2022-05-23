using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyCherries : MonoBehaviour
{
    public void Awake()
    {
        GameObject[] countCherriesObject = GameObject.FindGameObjectsWithTag("GameMusic");
        
        if(countCherriesObject.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
