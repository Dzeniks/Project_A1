using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class Way_Main : MonoBehaviour
{
    public GameObject shortWall, mediumWall, longWall, GCoin, XPStar, Hearth, Way, EndLine, Chest;
    public List<GameObject> walls = new List<GameObject>();
    public List<int> wallPosts = new List<int>();
    public List<int> coinPosts = new List<int>();
    public List<int> XPPosts = new List<int>();
    
    public int playerDifficulty;
    public int PlayerCoins; 
    public int PlayerCoinsEnd;
    public int XPpStar, nXPstar;
    
    public int HPBoost, CoinBoost, XPBoost, DstBoost;
    
    private System.Random random;
    private int randomPosX, randomPosZ, playerDistance, randomPosXCoin, randomPosZCoin, randomPosZXP, randomPosXXP, DiffWayLenght, AllWayLenght, randomPosZChest;
    internal double XPdisK;
    private string Difficulty = "Easy", Mode = "Race";
    private Vector3 playerPosition;
    private GameObject randomWall;

    // Balance count and position of walls


    // Start is called before the first frame update
    void Awake()
    {
        walls.Add(shortWall);
        walls.Add(mediumWall);
        walls.Add(longWall);
        playerPosition = GameObject.Find("Player").transform.position;
        playerDifficulty = 800;
        playerDistance = (int)(playerPosition.z + 25);

    }


    void Start()
    {
        GameObject theplayer = GameObject.Find("Player");
        Player_Main playerScript = theplayer.GetComponent<Player_Main>();
        Difficulty = PlayerPrefs.GetString("Difficulty");
        Mode = PlayerPrefs.GetString("Mode");
        
        HPBoost = PlayerPrefs.GetInt("HPBoost");
        CoinBoost = PlayerPrefs.GetInt("CoinBoost");
        XPBoost = PlayerPrefs.GetInt("XPBoost");
        DstBoost = PlayerPrefs.GetInt("DstBoost");

        if (Mode == "Race")

    {
            //Difficulty choose and mode
            if (Difficulty == "Easy")
            {
                playerScript.playerLife = 8 + HPBoost;
                XPpStar = 500;
                XPdisK = 1;
                nXPstar = 4;
                DiffWayLenght = 600;
                playerDifficulty = 550;
                PlayerCoins = 90;
                PlayerCoinsEnd = PlayerPrefs.GetInt("AllCoins")/100;

            }
            else if (Difficulty == "Medium")
            {
                playerScript.playerLife = 5 + HPBoost;
                XPpStar = 1000;
                XPdisK = 1.1;
                nXPstar = 6;
                DiffWayLenght = 700;
                playerDifficulty = 750;
                PlayerCoins = 100;
                PlayerCoinsEnd = PlayerPrefs.GetInt("AllCoins")/100 *3;
            }
            else if (Difficulty == "Hard")
            {
                playerScript.playerLife = 3 + HPBoost;
                XPpStar = 1500;
                XPdisK = 1.2;
                nXPstar = 8;
                DiffWayLenght = 800;
                playerDifficulty = 950;
                PlayerCoins = 110;
                PlayerCoinsEnd = PlayerPrefs.GetInt("AllCoins")/100 * 5;
            }
            else if (Difficulty == "Ballin")
            {
                playerScript.playerLife = 1 + HPBoost;
                XPpStar = 3000;
                XPdisK = 1.3;
                nXPstar = 10;
                DiffWayLenght = 1000;
                playerDifficulty = 1400;
                PlayerCoins = 140;
                PlayerCoinsEnd = PlayerPrefs.GetInt("AllCoins")/100 * 8;
            }

            AllWayLenght = DiffWayLenght + 100;
            Way.transform.localScale = new Vector3(Way.transform.localScale.x, Way.transform.localScale.y, AllWayLenght);
            Way.transform.position = new Vector3(0,0,(AllWayLenght/2));

            // Wall generator
            for (int c = 0; c < playerDifficulty; c++)
            {
                randomWall = walls[Random.Range(0, 3)];
                randomPosX = Random.Range(-3, 3);
                randomPosZ = Random.Range(playerDistance + 10, DiffWayLenght);
                if (randomPosZ % 10 == 0 && !wallPosts.Contains(randomPosZ))
                {
                    // spawn wall on position
                    Instantiate(randomWall, new Vector3(randomPosX, 2, randomPosZ),
                        Quaternion.Euler(new Vector3(0, 0, 0))).tag = "WallClone";
                    wallPosts.Add(randomPosZ);
                }
                else
                {
                    // change randomPosZ
                    randomPosZ = Random.Range(playerDistance, DiffWayLenght);
                }
            }
            // Coin generator
            for (int j = 0; j < PlayerCoins; j++)
            {
                randomPosX = Random.Range(-3, 3);
                randomPosZ = Random.Range(playerDistance + 10, DiffWayLenght);
                while (wallPosts.Contains(randomPosZ) && coinPosts.Contains(randomPosZ))
                {
                    randomPosZ = Random.Range(playerDistance + 10, DiffWayLenght);
                }
                if (!wallPosts.Contains(randomPosZ) && !coinPosts.Contains(randomPosZ))
                { 
                    Instantiate(GCoin, new Vector3(randomPosX, (float)2.5, randomPosZ),
                        Quaternion.Euler(new Vector3(0, 90, 0))).tag = "GCoinClone";
                    coinPosts.Add(randomPosZ);
                }
            }
            // XP generator //
            for (int j = 0; j < nXPstar; j++)
            {
                randomPosXXP = Random.Range(-3, 3);
                randomPosZXP = Random.Range(playerDistance + 10, DiffWayLenght);
                while (wallPosts.Contains(randomPosZXP) && coinPosts.Contains(randomPosZXP) && XPPosts.Contains(randomPosZXP))
                {
                    randomPosZXP = Random.Range(playerDistance + 10, DiffWayLenght);
                }
                if (!wallPosts.Contains(randomPosZXP) && !coinPosts.Contains(randomPosZXP) && !XPPosts.Contains(randomPosZXP))
                { 
                    Instantiate(XPStar, new Vector3(randomPosX, (float)1, randomPosZXP),
                        Quaternion.Euler(new Vector3(0, 90, 0))).tag = "XPStarClone";
                    coinPosts.Add(randomPosZXP);
                }
            }
            // Create End line
            Instantiate(EndLine, new Vector3(0, (float)0.52, (AllWayLenght-20)),
                Quaternion.Euler(new Vector3(0, 0, 0))).tag = "EndLineClone";
            // Create Chest
            Instantiate(Chest, new Vector3(0, 1, (AllWayLenght-50)),
                Quaternion.Euler(new Vector3(0, 0, 0))).tag = "ChestClone";
            
        }
        else if (Mode == "Infinite")
        {
            playerScript.playerLife = 5 + HPBoost;
            XPpStar = 1500;
            InvokeRepeating("WayExtender", 1f,1f);
        }
        else
        {
            playerScript.playerLife = 5 + HPBoost;
            Mode = "Infinite";
            XPpStar = 1500;
            playerScript.playerLife = 5 + HPBoost;
            InvokeRepeating("WayExtender", 1f,1f); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Mode == "Infinite")
        {
            if (GameObject.Find("Player"))
            {
                playerPosition = GameObject.Find("Player").transform.position;
                playerDistance = (int)(playerPosition.z + 25);
                // Wall generator
                randomWall = walls[Random.Range(0, 3)];
                randomPosX = Random.Range(-3, 3);
                randomPosZ = Random.Range(playerDistance + 10, playerDistance + 100);
                if (randomPosZ % 10 == 0 && !wallPosts.Contains(randomPosZ))
                {
                    // spawn wall on position
                    Instantiate(randomWall, new Vector3(randomPosX, 2, randomPosZ),
                        Quaternion.Euler(new Vector3(0, 0, 0))).tag = "WallClone";
                    wallPosts.Add(randomPosZ);
                }
                else
                {
                    // change randomPosZ
                    randomPosZ = Random.Range(playerDistance + 10, playerDistance + 100);
                }
                // XP generator //
                randomPosXXP = Random.Range(-3, 3);
                randomPosZXP = Random.Range(playerDistance + 10, playerDistance + 100);
                if  (randomPosZXP % 251 == 0 && !wallPosts.Contains(randomPosZXP) && !coinPosts.Contains(randomPosZXP) && !XPPosts.Contains(randomPosZXP))
                {
                    // spawn XP on position
                    Instantiate(XPStar, new Vector3(randomPosXXP, (float)1, randomPosZXP),
                        Quaternion.Euler(new Vector3(0, 90, 0))).tag = "XPStarClone";
                    XPPosts.Add(randomPosZXP);
                }
                else
                {
                    // change randomPosZXP
                    randomPosZXP = Random.Range(playerDistance + 10, playerDistance + 100);
                }


                // Coin generator //
                randomPosXCoin = Random.Range(-3, 3);
                randomPosZCoin = Random.Range(playerDistance + 10, playerDistance + 100);
                if  (randomPosZCoin % 8 == 0 && !wallPosts.Contains(randomPosZCoin) && !coinPosts.Contains(randomPosZCoin))
                {
                    // spawn coin on position
                    Instantiate(GCoin, new Vector3(randomPosXCoin, (float)2.5, randomPosZCoin),
                        Quaternion.Euler(new Vector3(0, 90, 0))).tag = "GCoinClone";
                    coinPosts.Add(randomPosZCoin);
                }
                else
                {
                    // change randomPosZCoin
                    randomPosZCoin = Random.Range(playerDistance + 10, playerDistance + 100);
                }
                // Chest Generator //
                randomPosZChest = Random.Range(playerDistance + 10, playerDistance + 100);
                if  (randomPosZChest % 500 == 0 && !wallPosts.Contains(randomPosZChest) && !coinPosts.Contains(randomPosZChest) && !XPPosts.Contains(randomPosZChest))
                {
                    // spawn XP on position
                    Instantiate(Chest, new Vector3(0, (float)1, randomPosZChest),
                        Quaternion.Euler(new Vector3(0, 0, 0))).tag = "ChestClone";
                    XPPosts.Add(randomPosZChest);
                }
                else
                {
                    // change randomPosZXP
                    randomPosZChest = Random.Range(playerDistance + 10, playerDistance + 100);
                }
            }
        }
        // Destroy every GCoinClone behind player
        foreach (GameObject GCC in GameObject.FindGameObjectsWithTag("GCoinClone"))
        {
            if (((int)GCC.transform.position.z + 25)< (int)GameObject.Find("Player").transform.position.z)
            {
                Destroy(GCC);
            }
        }
        // Destroy every WallClone behind player
        foreach (GameObject WC in GameObject.FindGameObjectsWithTag("WallClone"))
        {
            if (((int)WC.transform.position.z + 25)< (int)GameObject.Find("Player").transform.position.z)
            {
                Destroy(WC);
            }
        }
        // All GCoinClones moving up, down and rotating
        float y = Mathf.PingPong(Time.time, (float)1.5) + (float)1.25;
        foreach (var GCc in GameObject.FindGameObjectsWithTag("GCoinClone"))
        {
            GCc.transform.position = new Vector3(GCc.transform.position.x, y, GCc.transform.position.z);
            GCc.transform.Rotate(0, (float)0.1, 0);
        }
    }


    private void WayExtender()
    {
        // Way extender
        Way.transform.localScale += new Vector3(0, 0, 36);
    }
}