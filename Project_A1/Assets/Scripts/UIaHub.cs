using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Playables;
using UnityEngine.UI;

public class UIaHub : MonoBehaviour
{
    private string PlayAbl;
    public Player_Main PlayerMain;
    public Way_Main WayMain;
    public GameObject AblBTN, AblBtnHeal, AblBtnSlow, AblBtnUnk, AblBtnCoinUp, AblBtnXpUp, AblBtnDash, AbltBtnDJump, AbltBtnLevitate;
    public GameObject DieTab;
    
    // Temp image
    public Image ImageHeal;

    public int HealUp = 0, Slowed= 0, Unkill = 0, CoinBonus = 0, XpBonus = 0, DashAct = 0, levitateAct = 0, CDBoost;
    private int CountDown, CoolDown35 = 0, CoolDown50 = 0, CoolDown30 = 0, CoolDown20 = 0;

    void BtnShade(GameObject BTN)
    {
        BTN.GetComponent<Image>().color = new Color(BTN.GetComponent<Image>().color.r,BTN.GetComponent<Image>().color.g,BTN.GetComponent<Image>().color.b,0.65f);
    }
    void BtnShow(GameObject BTN)
    {
        BTN.GetComponent<Image>().color = new Color(BTN.GetComponent<Image>().color.r,BTN.GetComponent<Image>().color.g,BTN.GetComponent<Image>().color.b,100);
    }
    // Start is called before the first frame update
    void Start()
    {
        CDBoost = PlayerPrefs.GetInt("CDBoost");
        PlayAbl = PlayerPrefs.GetString("PlayAbl");
        if (PlayAbl == "Heal")
        {
            AblBtnHeal.SetActive(true);
            AblBtnSlow.SetActive(false);
            AblBtnUnk.SetActive(false);
            AblBtnCoinUp.SetActive(false);
            AblBtnXpUp.SetActive(false);
            AblBtnDash.SetActive(false);
            AbltBtnDJump.SetActive(false);
            AbltBtnLevitate.SetActive(false);
            
        }
        else if (PlayAbl == "Slow")
        {
            AblBtnHeal.SetActive(false);
            AblBtnSlow.SetActive(true);
            AblBtnUnk.SetActive(false);
            AblBtnCoinUp.SetActive(false);
            AblBtnXpUp.SetActive(false);
            AblBtnDash.SetActive(false);
            AbltBtnDJump.SetActive(false);
            AbltBtnLevitate.SetActive(false);
        }
        else if (PlayAbl == "Unk")
        {
            AblBtnHeal.SetActive(false);
            AblBtnSlow.SetActive(false);
            AblBtnUnk.SetActive(true);
            AblBtnCoinUp.SetActive(false);
            AblBtnXpUp.SetActive(false);
            AblBtnDash.SetActive(false);
            AbltBtnDJump.SetActive(false);
            AbltBtnLevitate.SetActive(false);
        }
        else if (PlayAbl == "CoinUp")
        {
            AblBtnHeal.SetActive(false);
            AblBtnSlow.SetActive(false);
            AblBtnUnk.SetActive(false);
            AblBtnCoinUp.SetActive(true);
            AblBtnXpUp.SetActive(false);
            AblBtnDash.SetActive(false);
            AbltBtnDJump.SetActive(false);
            AbltBtnLevitate.SetActive(false);
        }
        else if (PlayAbl == "XpUp")
        {
            AblBtnHeal.SetActive(false);
            AblBtnSlow.SetActive(false);
            AblBtnUnk.SetActive(false);
            AblBtnCoinUp.SetActive(false);
            AblBtnXpUp.SetActive(true);
            AblBtnDash.SetActive(false);
            AbltBtnDJump.SetActive(false);
            AbltBtnLevitate.SetActive(false);
        }
        else if (PlayAbl == "Dash")
        {
            AblBtnHeal.SetActive(false);
            AblBtnSlow.SetActive(false);
            AblBtnUnk.SetActive(false);
            AblBtnCoinUp.SetActive(false);
            AblBtnXpUp.SetActive(false);
            AblBtnDash.SetActive(true);
            AbltBtnDJump.SetActive(false);
            AbltBtnLevitate.SetActive(false);
        }
        else if (PlayAbl == "DJump")
        {
            AblBtnHeal.SetActive(false);
            AblBtnSlow.SetActive(false);
            AblBtnUnk.SetActive(false);
            AblBtnCoinUp.SetActive(false);
            AblBtnXpUp.SetActive(false);
            AblBtnDash.SetActive(false);
            AbltBtnDJump.SetActive(true);
            AbltBtnLevitate.SetActive(false);
        }
        else if (PlayAbl == "Levitate")
        {
            AblBtnHeal.SetActive(false);
            AblBtnSlow.SetActive(false);
            AblBtnUnk.SetActive(false);
            AblBtnCoinUp.SetActive(false);
            AblBtnXpUp.SetActive(false);
            AblBtnDash.SetActive(false);
            AbltBtnDJump.SetActive(false);
            AbltBtnLevitate.SetActive(true);
        }
        else if (PlayAbl == null)
        {
            AblBTN.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void PauseGame ()
    {
        GameObject Player = GameObject.Find("Player"); 
        Time.timeScale = 0;
        Player.GetComponent<NewMovement>().stopRun = false;
    }

    public void ResumeGame ()
    {
        GameObject Player = GameObject.Find("Player"); 
        Time.timeScale = 1;
        Player.GetComponent<NewMovement>().stopRun = true;
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);   
    }

    /// <summary>
    /// Abblities
    /// </summary>
    
    public void Heal()
    {
        if (CoolDown35 == 0)
        {
            CoolDown35 = 1;
            HealUp = 1;
            BtnShade(AblBtnHeal);
            PlayerMain.playerLife += 1;
            //PlayerMain.AllXP += 50; 
            double CDHeal = (35-(CDBoost*0.035));
            Invoke("ResetHeal", (float)CDHeal);
            Invoke("SetCountDown35",(float)CDHeal);
            Invoke("ImageHealReset", (float)CDHeal);
        }
    }

    public void Slow()
    {
        if (CoolDown30 == 0)
        {
            CoolDown30 = 1;
            Time.timeScale = 0.65f;
            //PlayerMain.AllXP += 100;
            
            BtnShade(AblBtnSlow);
            //PlayerMain.PlayerMovement.playerSpeed = 5f;
            double CDSlow = (30-(CDBoost*0.03));
            Invoke("ResetSlow", 10);
            Invoke("SetCountDown30", (float)CDSlow);
            Invoke("ImageSlowReset", (float)CDSlow);
        }
    }

    public void Unk()
    {
        if (CoolDown50 == 0)
        {
            CoolDown50 = 1;
            Unkill = 1;
            //PlayerMain.AllXP += 100;
            
            BtnShade(AblBtnUnk);
            double CDUnk = (50-(CDBoost*0.05));
            Invoke("ResetUnk",5);
            Invoke("SetCountDown50", (float)CDUnk);
            Invoke("ImageUnkReset", (float)CDUnk);
        }
    }

    public void CoinUp()
    {
        if (CoolDown30 == 0)
        {
            CoolDown30 = 1;
            CoinBonus = 1;
            //PlayerMain.AllXP += 200;
            BtnShade(AblBtnCoinUp);
            double CDCoinUp = (30-(CDBoost*0.03));
            Invoke("ResetCoinUp", 15);
            Invoke("SetCountDown30", (float)CDCoinUp);
            Invoke("ImageCoinUpReset", (float)CDCoinUp);
        } 
    }
    
    public void XpUp()
    {
        if (CoolDown30 == 0)
        {
            CoolDown30 = 1;
            XpBonus = 1;
            //PlayerMain.AllXP += 200;
            BtnShade(AblBtnXpUp);
            double CDXpUp = (30-(CDBoost*0.03));
            Invoke("ResetXpUp", 15);
            Invoke("SetCountDown30", (float)CDXpUp);
            Invoke("ImageXpUpReset", (float)CDXpUp);
        } 
    }

    public void Dash()
    {
        if (CoolDown30 == 0)
        {
            CoolDown30 = 1;
            DashAct = 1;
            GameObject Player = GameObject.Find("Player");
            Rigidbody rg = Player.GetComponent<Rigidbody>();
            Player.transform.rotation = Quaternion.identity;
            Vector3 direction = Player.transform.position - transform.position;
            rg.AddForceAtPosition(direction.normalized, transform.position, ForceMode.Impulse);
            rg.AddForce(Player.transform.forward * 100000);
            PlayerMain.playerCoins += 5;
            //PlayerMain.AllXP += 300;
            BtnShade(AblBtnDash);
            double CDDash = (30-(CDBoost*0.03));
            Invoke("ResetDash", (float)1.2);
            Invoke("SetCountDown30", (float)CDDash);
            Invoke("ImageDashReset", (float)CDDash); 
        }
    }

    public void DJump()
    {
        if (CoolDown20 == 0)
        {
            CoolDown20 = 1;
            Unk();
            GameObject Player = GameObject.Find("Player");
            Rigidbody rg = Player.GetComponent<Rigidbody>();
            rg.AddForce(0, 2500f, 0, ForceMode.Impulse);
            //PlayerMain.AllXP += 300;
            BtnShade(AbltBtnDJump);
            double CDDJump = (20-(CDBoost*0.02));
            Invoke("SetCountDown20", (float)CDDJump);
            Invoke("ImageDJumpReset", (float)CDDJump); 
        } 
    }
    
    public void Levitate()
    {
        if (CoolDown35 == 0)
        {
            CoolDown35 = 1;
            GameObject Player = GameObject.Find("Player");
            Rigidbody rg = Player.GetComponent<Rigidbody>();
            rg.AddForce(0,2500f , 0, ForceMode.Impulse);
            rg.AddForce(0,-2500f,0, ForceMode.Impulse);
            LevitateUp();
            levitateAct = 1;
            Invoke("LevitateDown", (float)1.2);
            //PlayerMain.AllXP += 400;
            BtnShade(AbltBtnDJump);
            double CDLevitate = (35-(CDBoost*0.035));
            Invoke("SetCountDown20", (float)CDLevitate);
            Invoke("ImageLevitateReset", (float)CDLevitate); 
            Invoke("LevitateReset", (float)CDLevitate);
        } 
    }

    /// <summary>
    /// Resets
    /// </summary>
    private void ResetHeal()
    {
        HealUp = 0;
    }

    private void ResetCoinUp()
    {
        CoinBonus = 0;
    }
    
    private void ResetXpUp()
    {
        XpBonus = 0;
    }

    private void ResetSlow()
    {
        Time.timeScale = 1;
        //PlayerMain.PlayerMovement.playerSpeed = 10f;
    }

    private void ResetUnk()
    {
        Unkill = 0;
    }

    private void ResetDash()
    {
        DashAct = 0;
    }

    private void ImageHealReset()
    {
        BtnShow(AblBtnHeal);
    }

    private void ImageSlowReset()
    {
        BtnShow(AblBtnSlow);
    }

    private void ImageUnkReset()
    {
        BtnShow(AblBtnUnk);
    }
    
    private void ImageCoinUpReset()
    {
        BtnShow(AblBtnCoinUp);
    }
    
    private void ImageXpUpReset()
    {
        BtnShow(AblBtnXpUp);
    }

    private void ImageDashReset()
    {
        BtnShow(AblBtnDash);
    }
    
    private void ImageDJumpReset()
    {
        BtnShow(AbltBtnDJump);
    }

    private void LevitateReset()
    {
        levitateAct = 0;
    }
    
    private void ImageLevitateReset()
    {
        BtnShow(AbltBtnLevitate);
    }

    private void LevitateUp()
    {
        GameObject Player = GameObject.Find("Player");
        Rigidbody rg = Player.GetComponent<Rigidbody>();
        rg.AddForce(0,2500f , 0, ForceMode.Impulse);
    }

    private void LevitateDown()
    {
        GameObject Player = GameObject.Find("Player");
        Rigidbody rg = Player.GetComponent<Rigidbody>();
        rg.AddForce(0,-2500f , 0, ForceMode.Impulse);
    }
    /// <summary>
    /// Cooldowns
    /// </summary>
    private void SetCountDown35()
    {
        CoolDown35 = 0;
    }
    
    private void SetCountDown20()
    {
        CoolDown20 = 0;
    }

    private void SetCountDown30()
    {
        CoolDown30 = 0;
    }
    
    private void SetCountDown50()
    {
        CoolDown50 = 0;
    }

}
