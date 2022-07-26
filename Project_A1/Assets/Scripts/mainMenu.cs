using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class mainMenu : MonoBehaviour
{
    public Rigidbody rbPlayer, rbCam;

    public InvMenu InvMenu;
    public string AccDifficulty = "Easy", AccMode = "Race", Diffs, Modes;
    public Image LVLBar;
    public GameObject GMainMenu, GShopMenu, GInvMenu;

    public AudioVolume AudioVolume;
    public MusicVolume MusicVolume;
    public TextMeshProUGUI ScoreTextMenu; 
    private int i = -1, j = -1, AllCoins, AllCurrs, AllXP, LVL, XPToLVLuP, BestScore;
    private string[] difficulties = { "Easy", "Medium", "Hard", "Ballin" }, mods = {"Race", "Infinite"};

    private GameObject DifferenceText, ModeText, CoinText, LVLText;
    private TextMeshProUGUI TextDiff, TextMode, TextCoin, TextLVL;
    
    private string CoinsText, CurrsText, charac, abbilt;
    private int Coins;
    
    private Transform PlayerPos, CamPos;
    private Vector3 StartPos;

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        
        charac = PlayerPrefs.GetString("PlayChar");
        abbilt = PlayerPrefs.GetString("PlayAbl");
    }

    private void Start()
    {
        GameObject Player = GameObject.Find("Player"); 
        //PlayerPrefs.SetInt("AllXP", 999_999_999);
        //PlayerPrefs.SetInt("AllCoins", 1_000_999);
        //Debug.Log(PlayerPrefs.GetInt("AllCoins"));
        BestScore = PlayerPrefs.GetInt("BestScore");
        ScoreTextMenu.text = $"{BestScore}";
        
        
        rbPlayer = GameObject.Find("Player").GetComponent<Rigidbody>();
        rbCam = GameObject.Find("MenuCam").GetComponent<Rigidbody>();

        // Access to Difficoulty text
        DifferenceText = GameObject.Find("DiffText");
        TextDiff = DifferenceText.GetComponent<TextMeshProUGUI>();
        
        // Access to mode text
        ModeText = GameObject.Find("ModeText");
        TextMode = ModeText.GetComponent<TextMeshProUGUI>();
        
        // Access to game coin text
        CoinText = GameObject.Find("CoinText");
        TextCoin = CoinText.GetComponent<TextMeshProUGUI>();

        //LVLText = GameObject.Find("LVLText");
        //TextLVL = LVLText.GetComponent<TextMeshProUGUI>();


        

        
        
        // Lvl system;
        
        //AllXP = PlayerPrefs.GetInt("AllXP");
        //LVL = PlayerPrefs.GetInt("LVL");
        //XPToLVLuP = (int)(LVL * 800 + ((LVL * 800 * 0.35) / (LVL * 400)));
        //while (AllXP > XPToLVLuP)
        //{
        //    AllXP = PlayerPrefs.GetInt("AllXP");
        //    LVL = PlayerPrefs.GetInt("LVL");
        //    XPToLVLuP = (int)(LVL * 800 + ((LVL * 800 * 0.35) / (LVL * 400)));
        //    LVL += 1;
        //    AllXP -= XPToLVLuP;
        //}
        //PlayerPrefs.SetInt("LVL", LVL);
        //PlayerPrefs.SetInt("AllXP", AllXP); 
        //PlayerPrefs.Save();
        // Lvl bar func
        //LVLBar.fillAmount = (float)AllXP/XPToLVLuP;

        Coins = PlayerPrefs.GetInt("AllCoins");
        
        CoinsText = $"{Coins}";
        // Write Stats
        TextCoin.text = CoinsText;
        TextMode.text = $"{PlayerPrefs.GetString("Mode")}";
        TextDiff.text = $"{PlayerPrefs.GetString("Difficulty")}";
        //TextLVL.text = $"{PlayerPrefs.GetInt("LVL")}";

        // Used char load
        if (charac == "DefChar")
        {
            Player.GetComponent<MeshRenderer>().material = InvMenu.DefMat;
            Player.GetComponent<MeshFilter>().mesh = InvMenu.Sphere;
        }
        else if (charac == "PurpleChar")
        {
            Player.GetComponent<MeshRenderer>().material = InvMenu.PurpleMat;
            Player.GetComponent<MeshFilter>().mesh = InvMenu.Sphere;

        }
        else if (charac == "BlueChar")
        {
            Player.GetComponent<MeshRenderer>().material = InvMenu.BlueMat;
            Player.GetComponent<MeshFilter>().mesh = InvMenu.Sphere;
        }
        else if (charac == "GoldChar")
        {
            Player.GetComponent<MeshRenderer>().material = InvMenu.GolfMat;
            Player.GetComponent<MeshFilter>().mesh = InvMenu.Golf;
        }
        else if (charac == "CylidnerChar")
        {
            Player.GetComponent<MeshRenderer>().material = InvMenu.CylinderMat;
            Player.GetComponent<MeshFilter>().mesh = InvMenu.Cylinder;
        }
        else if (charac == "CubeChar")
        {
            Player.GetComponent<MeshRenderer>().material = InvMenu.CubeMat;
            Player.GetComponent<MeshFilter>().mesh = InvMenu.Cube;
        }
        else if (charac == "DonutChar")
        {
            Player.GetComponent<MeshRenderer>().material = InvMenu.DonutMat;
            Player.GetComponent<MeshFilter>().mesh = InvMenu.Donut;
        }
        else if (charac == "ConeChar")
        {
            Player.GetComponent<MeshRenderer>().material = InvMenu.ConeMat;
            Player.GetComponent<MeshFilter>().mesh = InvMenu.Cone;
        }
        else
        {
            Player.GetComponent<MeshRenderer>().material = InvMenu.DefMat;
            Player.GetComponent<MeshFilter>().mesh = InvMenu.Sphere;
        }
    }

    private void Update()
    {
        if (TextCoin.text != $"{PlayerPrefs.GetInt("AllCoins")}")
        {
            Coins = PlayerPrefs.GetInt("AllCoins");
            CoinsText = $"{Coins}";
            TextCoin.text = CoinsText;
        }

        if (ScoreTextMenu.text != $"{PlayerPrefs.GetInt("BestScore")}"){
            BestScore = PlayerPrefs.GetInt("BestScore");
        }
    }

    public void PlayGame()
    {
        if (PlayerPrefs.GetString("Mode") != null || PlayerPrefs.GetString("Difficulty") != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   
        }
    }

    public void MainBTN()
    {
        if (GMainMenu.activeSelf == false)
        {
            GMainMenu.SetActive(true);
            GShopMenu.SetActive(false);
            GInvMenu.SetActive(false);
        }
    }
    
    public void ShopBTN()
    {
        if (GShopMenu.activeSelf == false)
        {
            GMainMenu.SetActive(false);
            GShopMenu.SetActive(true);
            GInvMenu.SetActive(false);
        }
    }

    public void InvBTN()
    {
        if (GInvMenu.activeSelf == false)
        {
            GMainMenu.SetActive(false);
            GShopMenu.SetActive(false);
            GInvMenu.SetActive(true);
        }
    }

    public void Mod()
    {
        j += 1;
        // def Difficult
        if (j >= 2)
        {
            j = 0;
        }
        AccMode = mods[j];
        // TextMode.text = $"{mods[j]}";
        PlayerPrefs.SetString("Mode", mods[j]);
        PlayerPrefs.Save();
        TextMode.text = $"{PlayerPrefs.GetString("Mode")}";
    }

    public void Difficult()
    {
        i += 1;
        // def Difficult
        if (i >= 4)
            {
                i = 0;
            }

        AccDifficulty = difficulties[i];
        //TextDiff.text = $"{difficulties[i]}";
        PlayerPrefs.SetString("Difficulty", difficulties[i]);
        PlayerPrefs.Save();
        TextDiff.text = $"{PlayerPrefs.GetString("Difficulty")}"; 
    }
    
}
