using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class ChestAnim : MonoBehaviour
{
    private Animator anim;
    public TextMeshProUGUI NtfText;
    public GameObject NtfElement;
    public NewMovement playerMovement;
    
    private bool neverDone = true;
    public GameObject Player;

    private int HPBoost, CoinBoost, XPBoost, DstBoost, RvsBoost, CDBoost;

    public float distance, playerMovementSpeed;

    public int ChestOpen, BoostCheck;
    // Start is called before the first frame update
    void Start()
    {
        BoostCheck = Random.Range(1, 4);
        anim = GetComponent<Animator>();
        playerMovementSpeed = playerMovement.playerSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        int distance = (int)Vector3.Distance(Player.transform.position, transform.position); 
        anim.SetInteger("Distance", distance);
        if (distance < 10 && neverDone)
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
                NtfText.text = $"Heal boost LVL UP";
                HPBoost += 1;
                PlayerPrefs.SetInt("HPBoost", HPBoost);
            }
            else if (BoostCheck == 2)
            {
                NtfText.text = $"Coin boost LVL UP";
                CoinBoost += 1;
                PlayerPrefs.SetInt("CoinBoost", CoinBoost);
            }
            else if (BoostCheck == 3)
            {
                NtfText.text = $"Crystal boost LVL UP";
                XPBoost += 1;
                PlayerPrefs.SetInt("XPBoost", XPBoost);
            }
            else if (BoostCheck == 4)
            {
                NtfText.text = $"Destroy boost LVL UP";
                DstBoost += 1;
                PlayerPrefs.SetInt("DstBoost", DstBoost);
            }        
            else if (BoostCheck == 5){
                NtfText.text = $"Resurrection boost LVL UP";
                RvsBoost += 1;
                PlayerPrefs.SetInt("RvsBoost", RvsBoost);
            }
            else if (BoostCheck == 6){
                NtfText.text = $"Cooldown boost LVL UP";
                CDBoost += 1;
                PlayerPrefs.SetInt("CDBoost", CDBoost);
            }
            ChestOpen = 1;
            neverDone = false;
            StopMove();
            Invoke("StartMove", (float)4);
            Invoke("FadeOutNtf", (float)5);
        }
    }


    void StopMove()
    {
        playerMovement.playerSpeed = 1;
    }

    void StartMove()
    {
        gameObject.SetActive(false);
        playerMovement.playerSpeed = playerMovementSpeed;
        ChestOpen = 0;
        NtfElement.SetActive(true);
        neverDone = true;
    }

    void FadeOutNtf()
    {
        NtfElement.SetActive(false);
    }
}
