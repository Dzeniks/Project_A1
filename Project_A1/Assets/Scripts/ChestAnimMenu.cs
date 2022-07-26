using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChestAnimMenu : MonoBehaviour
{   private Animator anim;

    public TextMeshProUGUI EarnText;

    public bool neverDone;

    public int ClickBtn;

    private int HPBoost, CoinBoost, XPBoost, DstBoost, RvsBoost, CDBoost;

    public int ChestOpen, BoostCheck;
    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponent<Animator>();
        neverDone = true;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("ClickBtn", ClickBtn);
        if (neverDone == true){
            if (ClickBtn == 1)
            {
            BoostCheck = Random.Range(1, 7);
            HPBoost = PlayerPrefs.GetInt("HPBoost");
            CoinBoost = PlayerPrefs.GetInt("CoinBoost");
            XPBoost = PlayerPrefs.GetInt("XPBoost");
            DstBoost = PlayerPrefs.GetInt("DstBoost");
            RvsBoost = PlayerPrefs.GetInt("RvsBoost");
            CDBoost = PlayerPrefs.GetInt("CDBoost");
            if (BoostCheck == 1)
            {
                HPBoost += 1;
                PlayerPrefs.SetInt("HPBoost", HPBoost);
                EarnText.text = $"Heal boost LVL UP";
            }
            else if (BoostCheck == 2)
            {
                CoinBoost += 1;
                PlayerPrefs.SetInt("CoinBoost", CoinBoost);
                EarnText.text = $"Coin boost LVL UP";
            }
            else if (BoostCheck == 3)
            {
                XPBoost += 1;
                PlayerPrefs.SetInt("XPBoost", XPBoost);
                EarnText.text = $"Crystal boost LVL UP";
            }
            else if (BoostCheck == 4)
            {
                DstBoost += 1;
                PlayerPrefs.SetInt("DstBoost", DstBoost);
                EarnText.text = $"Destroy boost LVL UP";
            }
            else if (BoostCheck == 5){
                RvsBoost += 1;
                PlayerPrefs.SetInt("RvsBoost", RvsBoost);
                EarnText.text = $"Resurrection boost LVL UP";
            }
            else if (BoostCheck == 6){
                CDBoost += 1;
                PlayerPrefs.SetInt("CDBoost", CDBoost);
                EarnText.text = $"Cooldown boost LVL UP";
            }
            neverDone = false;
        }
            }
    }
}

