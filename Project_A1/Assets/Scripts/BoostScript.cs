using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoostScript : MonoBehaviour
{
    // Start is called before the first frame update

    private TextMeshProUGUI TextHP, TextCoin, TextXP, TextDst, TextRvs, TextCD;
    
    void Start()
    {
        // Access to mode text
        TextHP = GameObject.Find("HPPlusText").GetComponent<TextMeshProUGUI>();
        TextCoin = GameObject.Find("CoinPlusText").GetComponent<TextMeshProUGUI>();
        TextXP = GameObject.Find("XPPlusText").GetComponent<TextMeshProUGUI>();
        TextDst = GameObject.Find("DstPlusText").GetComponent<TextMeshProUGUI>();
        TextRvs = GameObject.Find("RvsPlusText").GetComponent<TextMeshProUGUI>();
        TextCD = GameObject.Find("CDPlusText").GetComponent<TextMeshProUGUI>();

        TextHP.text = $"LVL {PlayerPrefs.GetInt("HPBoost")}";
        TextCoin.text = $"LVL {PlayerPrefs.GetInt("CoinBoost")}";
        TextXP.text = $"LVL {PlayerPrefs.GetInt("XPBoost")}";
        TextDst.text = $"LVL {PlayerPrefs.GetInt("DstBoost")}";
        TextRvs.text = $"LVL {PlayerPrefs.GetInt("RvsBoost")}";
        TextCD.text = $"LVL {PlayerPrefs.GetInt("CDBoost")}";
        
    }

    // Update is called once per frame
    void Update()
    {
                // Access to mode text
        TextHP = GameObject.Find("HPPlusText").GetComponent<TextMeshProUGUI>();
        TextCoin = GameObject.Find("CoinPlusText").GetComponent<TextMeshProUGUI>();
        TextXP = GameObject.Find("XPPlusText").GetComponent<TextMeshProUGUI>();
        TextDst = GameObject.Find("DstPlusText").GetComponent<TextMeshProUGUI>();
        TextRvs = GameObject.Find("RvsPlusText").GetComponent<TextMeshProUGUI>();
        TextCD = GameObject.Find("CDPlusText").GetComponent<TextMeshProUGUI>();

        TextHP.text = $"LVL {PlayerPrefs.GetInt("HPBoost")}";
        TextCoin.text = $"LVL {PlayerPrefs.GetInt("CoinBoost")}";
        TextXP.text = $"LVL {PlayerPrefs.GetInt("XPBoost")}";
        TextDst.text = $"LVL {PlayerPrefs.GetInt("DstBoost")}";
        TextRvs.text = $"LVL {PlayerPrefs.GetInt("RvsBoost")}";
        TextCD.text = $"LVL {PlayerPrefs.GetInt("CDBoost")}";
        
        //Debug.Log(PlayerPrefs.GetInt("CDBoost"));
    }
}
