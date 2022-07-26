using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevitateAbl : MonoBehaviour
{
    public GameObject Player;
    public UIaHub UIaHub;
    public ChestAnim ChestAnim;
    private int levitateAct, ChestOpen;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    { 
        if (UIaHub.levitateAct == 1)
            {
                var distance = Vector3.Distance(Player.transform.position, transform.position);
                if (distance <= 80)
                {
                    Destroy(gameObject);
                }
            }
        
        if (ChestAnim.ChestOpen == 1)
        {
            var distance = Vector3.Distance(Player.transform.position, transform.position);
            if (distance <= 14)
            {
                Destroy(gameObject);
            }
        }
    }
}
