using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class camera_movement : MonoBehaviour
{
    // Start is called before the first frame update
    public Player_Main Player_Main;

    
    // Update is called once per frame
    void Update()
    { 
        if (GameObject.Find("Player") && Player_Main.DeathBool == false)
        {
            Vector3 pos = GameObject.Find("Player").transform.position; 
            transform.position = new Vector3(0, 7, -6+pos.z);
        }
        else if (!GameObject.Find("Player") || Player_Main.DeathBool == true)
        {
            transform.position = new Vector3(0, 7, -6 + Player_Main.PlayerDeathPos.z);
        }
        

    }
}
