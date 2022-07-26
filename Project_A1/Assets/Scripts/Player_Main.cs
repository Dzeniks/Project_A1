using System;
using System.Threading;
using System.Timers;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static System.TimeSpan;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Timer = System.Timers.Timer;
using Vector3 = UnityEngine.Vector3;
using TMPro;

public class Player_Main : MonoBehaviour
{
    public ReviveAd ReviveAd; 
    private AudioSource PlayerAudio;
    public AudioClip GCoinTake, XPTake, WallHit, Dead, WinRace;

    public AudioVolume AudioVolume;
    public MusicVolume MusicVolume;

    public TextMeshProUGUI ScoreText;
    public bool DeathBool;
    public int playerCoins = 0, AllCoins, playerLife = 1000, AllXP, StarXP, DisXP, HPBoost, CoinBoost, XPBoost, DstBoost, RvsBoost;
    public ParticleSystem WallHitParticle;
    public GameObject Trail;
    public Way_Main WayMain;
    public NewMovement PlayerMovement;
    public UIaHub UIaHubs;
    public Material DefMat, BlueMat, PurpleMat, GolfMat, CubeMat, DonutMat, ConeMat, CylinderMat, CharacMaterial;
    public Mesh Sphere, Golf, Cube, Donut, Cone, Cylinder;
    private int Score;
    private TrailRenderer tr;
    private string Mode, charac, abbilt;
    private Vector3 WayPos;

    public Vector3 PlayerDeathPos;
    private GameObject TrailClone;

    // Start is called before the first frame update

    private void Awake()
    {
        
        DeathBool = false;
        charac = PlayerPrefs.GetString("PlayChar");
         if (charac == "DefChar"){
            CharacMaterial = DefMat;
            GetComponent<MeshRenderer> ().material = DefMat;
            GetComponent<MeshFilter>().mesh = Sphere;
        }
        else if (charac == "PurpleChar"){
            CharacMaterial = PurpleMat;
            GetComponent<MeshRenderer> ().material = PurpleMat;
            GetComponent<MeshFilter>().mesh = Sphere;
        }
        else if (charac == "BlueChar"){
            CharacMaterial = BlueMat;
            GetComponent<MeshRenderer> ().material = BlueMat;
            GetComponent<MeshFilter>().mesh = Sphere;
        }
        else if (charac == "GolfChar"){
            CharacMaterial = GolfMat;
            GetComponent<MeshRenderer> ().material = GolfMat;
            GetComponent<MeshFilter>().mesh = Golf;}
        else if (charac == "CubeChar"){
            CharacMaterial = CubeMat;
            GetComponent<MeshRenderer> ().material = CubeMat;
            GetComponent<MeshFilter>().mesh = Cube;
        }
        else if (charac == "DonutChar"){
            CharacMaterial = DonutMat;
            GetComponent<MeshRenderer> ().material = DonutMat;
            GetComponent<MeshFilter>().mesh = Donut;
        }
        else if (charac == "ConeChar")
        {
            CharacMaterial = ConeMat;
            GetComponent<MeshRenderer> ().material = ConeMat;
            GetComponent<MeshFilter>().mesh = Cone;
        }
        else if (charac == "CylidnerChar")
        {
            CharacMaterial = CylinderMat;
            GetComponent<MeshRenderer> ().material = CylinderMat;
            GetComponent<MeshFilter>().mesh = Cylinder;
        }
        else
        {
            CharacMaterial = DefMat;
            GetComponent<MeshRenderer> ().material = DefMat;
            GetComponent<MeshFilter>().mesh = Sphere;
        }
        
        HPBoost = PlayerPrefs.GetInt("HPBoost");
        CoinBoost = PlayerPrefs.GetInt("CoinBoost");
        XPBoost = PlayerPrefs.GetInt("XPBoost");
        DstBoost = PlayerPrefs.GetInt("DstBoost");
        RvsBoost = PlayerPrefs.GetInt("RvsBoost");

        AllCoins = PlayerPrefs.GetInt("AllCoins");
        AllXP = PlayerPrefs.GetInt("AllXP");
        Mode = PlayerPrefs.GetString("Mode");
    }

    void Start()
    {
        PlayerAudio = GetComponent<AudioSource>();
        if (Mode == "Race")
        {
            GameObject Way = GameObject.Find("Way");
            Way_Main WayMain = Way.GetComponent<Way_Main>(); 
        }

        tr = Trail.GetComponent<TrailRenderer>();
        tr.material = new Material(Shader.Find("Sprites/Default"));
        WayPos = GameObject.Find("Way").transform.position;
        
        Instantiate(Trail, new Vector3(transform.position.x, (float)0.51, transform.position.z),
            Quaternion.Euler(new Vector3(90, 0, 0))).tag = "TrailClone";
        TrailClone = GameObject.Find("Trail(Clone)");
    }

    void Update()
    {
        if(UIaHubs.DieTab){
            
        }
        if(DeathBool){
            Score = (int)PlayerDeathPos.z;
        }
        else{
            Score = (int)transform.position.z;
        }
        ScoreText.text = $"{Score}";
        if (gameObject)
        {
            WallHitParticle.transform.position = transform.position;

            if (PlayerMovement.isGrounded == false && (PlayerMovement.jumpTime+0.68) <= Time.time )
            {
                Destroy(TrailClone);
            }
            else if (PlayerMovement.isGrounded == true)
            {
                TrailClone = GameObject.Find("Trail(Clone)");
                if (TrailClone == null)
                {
                    Instantiate(Trail, new Vector3(transform.position.x, (float)0.51, transform.position.z),
                            Quaternion.Euler(new Vector3(90, 0, 0))).tag = "TrailClone";
                        TrailClone = GameObject.Find("Trail(Clone)");
                }

                TrailClone.transform.rotation = new Quaternion(90, 0, 0, 90);
                TrailClone.transform.position = new Vector3(transform.position.x, (float)0.51, transform.position.z);
            }

            // Kill player if he jump out of way
            if ((WayPos.y - 5) > transform.position.y && DeathBool == false){
                playerLife = 0;
                Death();
            }
            if (Mode == "Race")
            {
                // When player cross End Line + Coins
                if (GameObject.FindWithTag("EndLineClone").transform.position.z + 5 < transform.position.z)
                {
                    PlayerAudio.clip = WinRace;
                    PlayerAudio.Play();
                    playerCoins += WayMain.PlayerCoinsEnd;
                    SaveStats();
                    Destroy(gameObject);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                }
            }
        }
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        // Kill player if he doesnt have lifes
        if (collision.gameObject.tag == "WallClone")
        {
            if (UIaHubs.Unkill == 1 || UIaHubs.DashAct == 1) {
            PlayerAudio.clip = WallHit;
            PlayerAudio.Play();
            WallHitParticle.Play();
            Destroy(collision.collider.gameObject);
            }
            else{
                
                int DstChance = Random.Range(0, 1000);
                if (DstChance < DstBoost){}
                else
                {
                    playerLife -= 1;
                }
            }
            PlayerAudio.clip = WallHit;
            PlayerAudio.Play();
            WallHitParticle.Play();
            Destroy(collision.collider.gameObject);
            if (playerLife <= 0 && DeathBool == false)
            {
                Death();
            }
            
        }
        else if (collision.gameObject.tag == "GCoinClone")
        {
            if (UIaHubs.CoinBonus == 1)
            {
                playerCoins += (25 + (CoinBoost * 2));
            }
            else if (UIaHubs.DashAct == 1)
            {
                playerCoins += (50 + (CoinBoost * 2));
            }
            else
            {
                playerCoins += (2 + (CoinBoost * 2));
            }
            Destroy(collision.collider.gameObject);
            PlayerAudio.clip = GCoinTake;
            PlayerAudio.Play();
        }
        else if (collision.gameObject.tag == "XPStarClone")
        {
            if (UIaHubs.XpBonus == 1)
            {
                playerCoins += (WayMain.XPpStar + 5_000 + (XPBoost * 4));
            }
            else if (UIaHubs.DashAct == 1)
            {
                playerCoins += (WayMain.XPpStar + 10_000 + (XPBoost * 4));
            }
            else
            {
                playerCoins += (WayMain.XPpStar + (XPBoost * 4));
            }
            Destroy(collision.collider.gameObject);
            PlayerAudio.clip = XPTake;
            PlayerAudio.Play();
        }
    }

    void Death()
    {
        RvsCheck();
        
        PlayerDeathPos = transform.position;
        PlayerAudio.clip = Dead;
        PlayerAudio.Play();
        PlayerMovement.playerSpeed = 0;
        
        DeathBool = true;
        transform.position = new Vector3(-100,0,0);
        if(ReviveAd.secondChance){
            EndD();
        }
        else if(playerLife <= 0)
        {   
            UIaHubs.DieTab.SetActive(true);
            Invoke("CheckEnd", 5);
        }
    }
    
    public void EndD()
    {
        SaveStats();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
    // Every game i have another count of all XP 
    void RvsCheck(){
        int RvsChance = Random.Range(0, 1000);
        if (RvsChance < RvsBoost)
        {
            playerLife += 1;
            UIaHubs.Unk();
            transform.position = new Vector3(0, 20, PlayerDeathPos.z - 15);
            UIaHubs.DieTab.SetActive(false);
            DeathBool = false;
            PlayerMovement.playerSpeed = 10;
        }
    }

    public void Rvs(){
            playerLife += 1;
            UIaHubs.Unk();
            transform.position = new Vector3(0, 20, PlayerDeathPos.z - 15);
            UIaHubs.DieTab.SetActive(false);
            DeathBool = false;
            PlayerMovement.playerSpeed = 10;
    }

    void CheckEnd(){
        if((DeathBool && ReviveAd.StartedAD == false) || ReviveAd.secondChance){
            EndD();
        }
    }
    void SaveStats()
    {
        AllCoins += playerCoins;
        if (Score > PlayerPrefs.GetFloat("BestScore")){
            PlayerPrefs.SetInt("BestScore", Score);
        }
        PlayerPrefs.SetInt("AllCoins", AllCoins);
        PlayerPrefs.Save();
    }
}
