using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using Unity.Services.Core;
using Unity.Services.Mediation;


public class shopMenu : MonoBehaviour
{

    public Light LightA, LightB;
    public ChestAnimMenu ChestAnimMenu;
    public GameObject SCharList, SAblList, ChestList, Chest, Player, BotMenu;
    private GameObject CoinText, CurrText;
    private TextMeshProUGUI TextCoin, TextCurr;
    public TextMeshProUGUI ChestPriceText;

    public MainMenuPLayer MainMenuPLayer;
    private string CoinsText;
    private int Coins;
    // Start is called before the first frame update
    void Start()
    {
        Coins = PlayerPrefs.GetInt("AllCoins");
        
        // Access to game coin text
        CoinText = GameObject.Find("CoinText");
        TextCoin = CoinText.GetComponent<TextMeshProUGUI>();
        
        CoinsText = $"{Coins}";

        TextCoin.text = CoinsText;

        ChestPriceText.text = $"{PlayerPrefs.GetInt("ChestPrice")}";
    }

    // Update is called once per frame
    void Update()
    {
        if (TextCoin.text != $"{PlayerPrefs.GetInt("AllCoins")}")
        {
            Coins = PlayerPrefs.GetInt("AllCoins");
            CoinsText = $"{Coins}";
            TextCoin.text = CoinsText;
        }
        //if(ChestPriceText.text != $"{PlayerPrefs.GetInt("ChestPrice")}"){
        //}
    }

    public void BuyCharRed()
    {
        if (Coins >= 10_000 && PlayerPrefs.GetInt("HaveRedChar") != 1)
        {
            Coins -= 10_000;
            PlayerPrefs.SetInt("HaveRedChar", 1);
            PlayerPrefs.SetInt("AllCoins", Coins);
            PlayerPrefs.Save();
            //Debug.Log($"Now you buy Blue {PlayerPrefs.GetInt("HaveRedChar")}");
        }
    }

    public void BuyCharBlue()
    {
        if (Coins >= 1000 && PlayerPrefs.GetInt("HaveBlueChar") != 1)
        {
            Coins -= 1000;
            PlayerPrefs.SetInt("HaveBlueChar", 1);
            PlayerPrefs.SetInt("AllCoins", Coins);
            PlayerPrefs.Save();
            //Debug.Log($"Now you buy Blue {PlayerPrefs.GetInt("HaveBlueChar")}");
        }
    }
    
    public void BuyCharPurple()
    {
        if (Coins >= 20_000 && PlayerPrefs.GetInt("HavePurpleChar") != 1)
        {
            Coins -= 20_000;
            PlayerPrefs.SetInt("HavePurpleChar", 1);
            PlayerPrefs.SetInt("AllCoins", Coins);
            PlayerPrefs.Save();
            //Debug.Log($"Now you buy Blue {PlayerPrefs.GetInt("HavePurpleChar")}");
        }
    }

    public void BuyCharCone()
    {
        if (Coins >= 50_000 && PlayerPrefs.GetInt("HaveConeChar") != 1)
        {
            Coins -= 50_000;
            PlayerPrefs.SetInt("HaveConeChar", 1);
            PlayerPrefs.SetInt("AllCoins", Coins);
            PlayerPrefs.Save();
            //Debug.Log($"Now you buy Blue {PlayerPrefs.GetInt("HavePurpleChar")}");
        }
    }

    public void BuyCharCube()
    {
        if (Coins >= 80_000 && PlayerPrefs.GetInt("HaveCubeChar") != 1)
        {
            Coins -= 80_000;
            PlayerPrefs.SetInt("HaveCubeChar", 1);
            PlayerPrefs.SetInt("AllCoins", Coins);
            PlayerPrefs.Save();
            //Debug.Log($"Now you buy Blue {PlayerPrefs.GetInt("HavePurpleChar")}");
        }
    }

    public void BuyCharCylinder()
    {
        if (Coins >= 100_000 && PlayerPrefs.GetInt("HaveCylinderChar") != 1)
        {
            Coins -= 100_000;
            PlayerPrefs.SetInt("HaveCylinderChar", 1);
            PlayerPrefs.SetInt("AllCoins", Coins);
            PlayerPrefs.Save();
            //Debug.Log($"Now you buy Blue {PlayerPrefs.GetInt("HavePurpleChar")}");
        }
    }

    public void BuyCharGolf()
    {
        if (Coins >= 105_000 && PlayerPrefs.GetInt("HaveGolfChar") != 1)
        {
            Coins -= 105_000;
            PlayerPrefs.SetInt("HaveGolfChar", 1);
            PlayerPrefs.SetInt("AllCoins", Coins);
            PlayerPrefs.Save();
            //Debug.Log($"Now you buy Blue {PlayerPrefs.GetInt("HavePurpleChar")}");
        }
    }

    public void BuyCharDonut()
    {
        if (Coins >= 200_000 && PlayerPrefs.GetInt("HaveDonutChar") != 1)
        {
            Coins -= 200_000;
            PlayerPrefs.SetInt("HaveDonutChar", 1);
            PlayerPrefs.SetInt("AllCoins", Coins);
            PlayerPrefs.Save();
            //Debug.Log($"Now you buy Blue {PlayerPrefs.GetInt("HavePurpleChar")}");
        }
    }
    
    // Ablt buy //
    public void BuyAblHeal()
    {
        if (Coins >= 300 && PlayerPrefs.GetInt("HaveHeal") != 1)
        {
            Coins -= 300;
            PlayerPrefs.SetInt("HaveHeal", 1);
            PlayerPrefs.SetInt("AllCoins", Coins);
            PlayerPrefs.Save();
        }
    }
    
    public void BuyAblSlow()
    {
        if (Coins >= 500 && PlayerPrefs.GetInt("HaveSlow") != 1)
        {
            Coins -= 500;
            PlayerPrefs.SetInt("HaveSlow", 1);
            PlayerPrefs.SetInt("AllCoins", Coins);
            PlayerPrefs.Save();
        }
    }
    
    public void BuyAblUnk()
    {
        if (Coins >= 10_000 && PlayerPrefs.GetInt("HaveUnk") != 1)
        {
            Coins -= 10_000;
            PlayerPrefs.SetInt("HaveUnk", 1);
            PlayerPrefs.SetInt("AllCoins", Coins);
            PlayerPrefs.Save();
        }
    }
    
    public void BuyAblCoinUp()
    {
        if (Coins >= 30_000 && PlayerPrefs.GetInt("HaveCoinUp") != 1)
        {
            Coins -= 30_000;
            PlayerPrefs.SetInt("HaveCoinUp", 1);
            PlayerPrefs.SetInt("AllCoins", Coins);
            PlayerPrefs.Save();
        }
    }
    
    public void BuyAblXpUp()
    {
        if (Coins >= 40_000 && PlayerPrefs.GetInt("HaveXpUp") != 1)
        {
            Coins -= 40_000;
            PlayerPrefs.SetInt("HaveXpUp", 1);
            PlayerPrefs.SetInt("AllCoins", Coins);
            PlayerPrefs.Save();
        }
    }
    
    public void BuyDash()
    {
        if (Coins >= 60_000 && PlayerPrefs.GetInt("HaveDash") != 1)
        {
            Coins -= 60_000;
            PlayerPrefs.SetInt("HaveDash", 1);
            PlayerPrefs.SetInt("AllCoins", Coins);
            PlayerPrefs.Save();
        }
    }
    
    public void BuyDJump()
    {
        if (Coins >= 100_000 && PlayerPrefs.GetInt("HaveDJump") != 1)
        {
            Coins -= 100_000;
            PlayerPrefs.SetInt("HaveDJump", 1);
            PlayerPrefs.SetInt("AllCoins", Coins);
            PlayerPrefs.Save();
        }
    }


    
    public void BuyLevitate()
    {
        if (Coins >= 200_000 && PlayerPrefs.GetInt("HaveLevitate") != 1)
        {
            Coins -= 200_000;
            PlayerPrefs.SetInt("HaveLevitate", 1);
            PlayerPrefs.SetInt("AllCoins", Coins);
            PlayerPrefs.Save();
        }
    }
    
    
    // Show fce shop
    public void ShowChar()
    {
        SCharList.SetActive(true); 
        SAblList.SetActive(false);
        ChestList.SetActive(false);
    }
    
    public void ShowAbl()
    {
        SCharList.SetActive(false);
        SAblList.SetActive(true);
        ChestList.SetActive(false);
    }

    public void ShowChest()
    {
        SCharList.SetActive(false);
        SAblList.SetActive(false);
        ChestList.SetActive(true);
    }

    public void BuyChest(){
        if (Coins >= PlayerPrefs.GetInt("ChestPrice"))
        {
            int ChestPrice = PlayerPrefs.GetInt("ChestPrice");

            Coins -= ChestPrice;
            ChestPrice = (int)((ChestPrice*0.1)+ChestPrice+5);
            PlayerPrefs.SetInt("ChestPrice", ChestPrice);
            PlayerPrefs.SetInt("AllCoins", Coins);
            PlayerPrefs.Save();
            StartAnimChest();
            MainMenuPLayer.ChestOpenSound();
        }
        ChestPriceText.text = $"{PlayerPrefs.GetInt("ChestPrice")}";
    }

    private void StartAnimChest(){
        LightA.intensity = (float)1.5;
        LightB.intensity = (float)1;
        gameObject.SetActive(false);
        Player.GetComponent<MeshRenderer>().enabled = false;
        Chest.SetActive(true);
        BotMenu.SetActive(false);
        ChestAnimMenu.ClickBtn = 1;
        //reset
        Invoke("ChestAnimReset", 5);

    } 

    private void ChestAnimReset(){
        LightA.intensity = (float)2.5;
        LightB.intensity = (float)2;
        gameObject.SetActive(true);
        BotMenu.SetActive(true);
        Player.GetComponent<MeshRenderer>().enabled = true;
        Chest.SetActive(false);
        ChestAnimMenu.ClickBtn = 0;
        ChestAnimMenu.neverDone = true;
    }

}