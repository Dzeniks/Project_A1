using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeCount : MonoBehaviour
{
    public TextMeshProUGUI LifeText;
    // Start is called before the first frame update
    void Start()
    {
        LifeText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player"))
        {
            GameObject theplayer = GameObject.Find("Player");
            Player_Main playerScript = theplayer.GetComponent<Player_Main>();
            LifeText.text = $"{playerScript.playerLife}";
        }
    }
}
