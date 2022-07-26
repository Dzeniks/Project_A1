using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour
{
    public TextMeshProUGUI CoinText;
    // Start is called before the first frame update
    void Start()
    {
        CoinText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player"))
        {
            GameObject theplayer = GameObject.Find("Player");
            Player_Main playerScript = theplayer.GetComponent<Player_Main>();
            CoinText.text = $"{playerScript.playerCoins}";
        }
    }
}
