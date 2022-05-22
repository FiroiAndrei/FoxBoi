using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFallower : MonoBehaviour
{
    [SerializeField] private GameObject[] wayPoints;
    private int index = 0;
    [SerializeField] private float speed = 2f;

    private void Update()
    {
        if(Vector2.Distance(wayPoints[index].transform.position, transform.position) < .1f)
        {
            index++;
            if(index >= wayPoints.Length)
            {
                index = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[index].transform.position, Time.deltaTime * speed);
    }
}
