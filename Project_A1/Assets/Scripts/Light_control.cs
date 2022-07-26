using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_control : MonoBehaviour
{
    private Vector3 nextPosition;
    private float moveSpeed;

    
    // Update is called once per frame
    void Update()
    { 
        if (!GameObject.Find("Player"))
        {
            transform.position = new Vector3(0, 0, 0);
        }
        else if (GameObject.Find("Player"))
        {
            Vector3 pos = GameObject.Find("Player").transform.position; 
            transform.position = new Vector3(50, 50, 5+pos.z);
        }
    }
}
