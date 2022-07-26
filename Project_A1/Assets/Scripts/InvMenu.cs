using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using Image = UnityEngine.UI.Image;

public class InvMenu : MonoBehaviour
{
    // Use material
    public Material DefMat, BlueMat, PurpleMat, GolfMat, CubeMat, DonutMat, ConeMat, CylinderMat;
    // Used char image
    public GameObject BlueBtnImage, DefBtnImage, PurpleBtnImage, GolfBtnImage, CubeBtnImage, DonutBtnImage, ConeBtnImage, CyliderBtnImage;
    // Temp image
    public Mesh Sphere, Golf, Cube, Donut, Cone, Cylinder;
    private Image Timage;
    
    
    // Used abl image
    public GameObject HealBtnImage, SlowBtnImage, UnkBtnImage, CoinUpBtnImage, XpUpBtnImage, DashBtnImage, DJBtnImage, LevitateBtnImage;


    public GameObject Player, CharList, AblList, BoostList;
    // Char list btn
    public GameObject PurpleListCharImg, BlueListCharImg, GolfListCharImg, CubeListCharImg, DonutListCharImg, ConeListCharImg, CylinderListCharImg;
    // Abl list btn
    public GameObject HealListBtn, SlowListBtn, UnkListBtn, CoinUpListBtn, XpUpListBtn, DashListBtn, DJumpListBtn, LevitateListBtn;
    private string charac, abbilt;

    // Have chararacter buy
    private int HaveBlueChar, HavePurpleChar, HaveDefChar, HaveConeChar, HaveCubeChar,HaveDonutChar,HaveCylinderChar,HaveGolfChar;
    
    // Have abllity buy 
    private int HaveHeal, HaveSlow, HaveUnk, HaveCoinUp , HaveXpUp, HaveDash, HaveDJump, HaveMagnet, HaveLevitate;

    // Start is called before the first frame update
    void Start()
    {
        // char
        HavePurpleChar = PlayerPrefs.GetInt("HavePurpleChar");
        HaveDefChar = PlayerPrefs.GetInt("HaveDefChar");
        HaveBlueChar = PlayerPrefs.GetInt("HaveBlueChar");
        HaveConeChar = PlayerPrefs.GetInt("HaveConeChar");
        HaveCubeChar = PlayerPrefs.GetInt("HaveCubeChar");
        HaveDonutChar = PlayerPrefs.GetInt("HaveDonutChar");
        HaveCylinderChar = PlayerPrefs.GetInt("HaveCylinderChar");
        HaveGolfChar = PlayerPrefs.GetInt("HaveGolfChar");
        
        // abl
        HaveHeal = PlayerPrefs.GetInt("HaveHeal");
        HaveSlow = PlayerPrefs.GetInt("HaveSlow");
        HaveUnk = PlayerPrefs.GetInt("HaveUnk");
        HaveCoinUp = PlayerPrefs.GetInt("HaveCoinUp");
        HaveXpUp = PlayerPrefs.GetInt("HaveXpUp");
        HaveDash = PlayerPrefs.GetInt("HaveDash");
        HaveMagnet = PlayerPrefs.GetInt("HaveMagnet");
        HaveDJump = PlayerPrefs.GetInt("HaveDJump");
        HaveLevitate = PlayerPrefs.GetInt("HaveLevitate");
        

        charac = PlayerPrefs.GetString("PlayChar");
        abbilt = PlayerPrefs.GetString("PlayAbl");
        // Used char load
                if (charac == "DefChar")
                {
                    //Player.GetComponent<MeshRenderer>().material = DefMat;
                    DefBtnImage.SetActive(true);
                    PurpleBtnImage.SetActive(false);
                    BlueBtnImage.SetActive(false);
                    GolfBtnImage.SetActive(false);
                    CubeBtnImage.SetActive(false);
                    DonutBtnImage.SetActive(false);
                    ConeBtnImage.SetActive(false);
                    CyliderBtnImage.SetActive(false);

                    
                }
                else if (charac == "PurpleChar")
                {
                    //Player.GetComponent<MeshRenderer>().material = PurpleMat;
                    DefBtnImage.SetActive(false);
                    PurpleBtnImage.SetActive(true);
                    BlueBtnImage.SetActive(false);
                    GolfBtnImage.SetActive(false);
                    CubeBtnImage.SetActive(false);
                    DonutBtnImage.SetActive(false);
                    ConeBtnImage.SetActive(false);
                    CyliderBtnImage.SetActive(false);
                    
                }
                else if (charac == "BlueChar")
                {
                    //Player.GetComponent<MeshRenderer>().material = BlueMat;
                    DefBtnImage.SetActive(false);
                    PurpleBtnImage.SetActive(false);
                    BlueBtnImage.SetActive(true);
                    GolfBtnImage.SetActive(false);
                    CubeBtnImage.SetActive(false);
                    DonutBtnImage.SetActive(false);
                    ConeBtnImage.SetActive(false);
                    CyliderBtnImage.SetActive(false);
                }
                else if (charac == "GoldChar")
                {
                    //Player.GetComponent<MeshRenderer>().material = GolfMat;
                    DefBtnImage.SetActive(false);
                    PurpleBtnImage.SetActive(false);
                    BlueBtnImage.SetActive(false);
                    GolfBtnImage.SetActive(true);
                    CubeBtnImage.SetActive(false);
                    DonutBtnImage.SetActive(false);
                    ConeBtnImage.SetActive(false);
                    CyliderBtnImage.SetActive(false);
                }
                else if (charac == "CylidnerChar")
                {
                    //Player.GetComponent<MeshRenderer>().material = CylinderMat;
                    DefBtnImage.SetActive(false);
                    PurpleBtnImage.SetActive(false);
                    BlueBtnImage.SetActive(false);
                    GolfBtnImage.SetActive(false);
                    CubeBtnImage.SetActive(false);
                    DonutBtnImage.SetActive(false);
                    ConeBtnImage.SetActive(false);
                    CyliderBtnImage.SetActive(true);
                }
                else if (charac == "CubeChar")
                {
                    //Player.GetComponent<MeshRenderer>().material = CubeMat;
                    DefBtnImage.SetActive(false);
                    PurpleBtnImage.SetActive(false);
                    BlueBtnImage.SetActive(false);
                    GolfBtnImage.SetActive(false);
                    CubeBtnImage.SetActive(true);
                    DonutBtnImage.SetActive(false);
                    ConeBtnImage.SetActive(false);
                    CyliderBtnImage.SetActive(false);
                }
                else if (charac == "DonutChar")
                {
                    //Player.GetComponent<MeshRenderer>().material = DonutMat;
                    DefBtnImage.SetActive(false);
                    PurpleBtnImage.SetActive(false);
                    BlueBtnImage.SetActive(false);
                    GolfBtnImage.SetActive(false);
                    CubeBtnImage.SetActive(false);
                    DonutBtnImage.SetActive(true);
                    ConeBtnImage.SetActive(false);
                    CyliderBtnImage.SetActive(false);
                }
                else if (charac == "ConeChar")
                {
                    //Player.GetComponent<MeshRenderer>().material = ConeMat;
                    DefBtnImage.SetActive(false);
                    PurpleBtnImage.SetActive(false);
                    BlueBtnImage.SetActive(false);
                    GolfBtnImage.SetActive(false);
                    CubeBtnImage.SetActive(false);
                    DonutBtnImage.SetActive(false);
                    ConeBtnImage.SetActive(true);
                    CyliderBtnImage.SetActive(false);
                }
        else
        {
            //Player.GetComponent<MeshRenderer>().material = DefMat;
            DefBtnImage.SetActive(true);
            PurpleBtnImage.SetActive(false);
            BlueBtnImage.SetActive(false);
            GolfBtnImage.SetActive(false);
            CubeBtnImage.SetActive(false);
            DonutBtnImage.SetActive(false);
            ConeBtnImage.SetActive(true);
            CyliderBtnImage.SetActive(false);
        }
        
        // Used ablt load
        if (abbilt == "Heal")
        {
            HealBtnImage.SetActive(true);
            SlowBtnImage.SetActive(false);
            UnkBtnImage.SetActive(false);
            CoinUpBtnImage.SetActive(false);
            XpUpBtnImage.SetActive(false);
            DashBtnImage.SetActive(false);
            DJBtnImage.SetActive(false);
            LevitateBtnImage.SetActive(false);
        }
        else if (abbilt == "Slow")
        {
            HealBtnImage.SetActive(false);
            SlowBtnImage.SetActive(true);
            UnkBtnImage.SetActive(false);
            CoinUpBtnImage.SetActive(false);
            XpUpBtnImage.SetActive(false);
            DashBtnImage.SetActive(false);
            DJBtnImage.SetActive(false);
            LevitateBtnImage.SetActive(false);
        }
        else if (abbilt == "Unk")
        {
            HealBtnImage.SetActive(false);
            SlowBtnImage.SetActive(false);
            UnkBtnImage.SetActive(true);
            CoinUpBtnImage.SetActive(false);
            XpUpBtnImage.SetActive(false);
            DashBtnImage.SetActive(false);
            DJBtnImage.SetActive(false);
            LevitateBtnImage.SetActive(false);
        }

        else if (abbilt == "CoinUp")
        {
            HealBtnImage.SetActive(false);
            SlowBtnImage.SetActive(false);
            UnkBtnImage.SetActive(false);
            CoinUpBtnImage.SetActive(true);
            XpUpBtnImage.SetActive(false);
            DashBtnImage.SetActive(false);
            DJBtnImage.SetActive(false);
            LevitateBtnImage.SetActive(false);
        }
        else if (abbilt == "XpUp")
        {
            HealBtnImage.SetActive(false);
            SlowBtnImage.SetActive(false);
            UnkBtnImage.SetActive(false);
            CoinUpBtnImage.SetActive(false);
            XpUpBtnImage.SetActive(true);
            DashBtnImage.SetActive(false);
            DJBtnImage.SetActive(false);
            LevitateBtnImage.SetActive(false);
        }
        
        else if (abbilt == "Dash")
        {
            HealBtnImage.SetActive(false);
            SlowBtnImage.SetActive(false);
            UnkBtnImage.SetActive(false);
            CoinUpBtnImage.SetActive(false);
            XpUpBtnImage.SetActive(false);
            DashBtnImage.SetActive(true);
            DJBtnImage.SetActive(false);
            LevitateBtnImage.SetActive(false);
        }
        
        else if (abbilt == "DJump")
        {
            HealBtnImage.SetActive(false);
            SlowBtnImage.SetActive(false);
            UnkBtnImage.SetActive(false);
            CoinUpBtnImage.SetActive(false);
            XpUpBtnImage.SetActive(false);
            DashBtnImage.SetActive(false);
            DJBtnImage.SetActive(true);
            LevitateBtnImage.SetActive(false);
        }
        
        else if (abbilt == "Magnet")
        {
            HealBtnImage.SetActive(false);
            SlowBtnImage.SetActive(false);
            UnkBtnImage.SetActive(false);
            CoinUpBtnImage.SetActive(false);
            XpUpBtnImage.SetActive(false);
            DashBtnImage.SetActive(false);
            DJBtnImage.SetActive(false);
            LevitateBtnImage.SetActive(true);
        }

    }

    void ListFaded(int HaveChar, GameObject ListCharImg)
    {
        if (HaveChar == 1)
        {
            Timage = ListCharImg.GetComponent<Image>();
            var tempColorB = Timage.color;
            tempColorB.a = 1f;
            Timage.color = tempColorB;

        }
        else
        {
            Timage = ListCharImg.GetComponent<Image>();
            var tempColorB = Timage.color;
            tempColorB.a = 0.35f;
            Timage.color = tempColorB;
        }
    }

    // Update is called once per frame
        void Update()
        {
            // Check what character player have 
            if (HavePurpleChar != PlayerPrefs.GetInt("HaveBlueChar") || HaveDefChar != PlayerPrefs.GetInt("HavePurpleChar") || HaveConeChar != PlayerPrefs.GetInt("HaveConeChar")|| HaveCubeChar != PlayerPrefs.GetInt("HaveCubeChar") || HaveDonutChar != PlayerPrefs.GetInt("HaveDonutChar") || HaveCylinderChar != PlayerPrefs.GetInt("HaveCylinderChar") || HaveGolfChar != PlayerPrefs.GetInt("HaveGolfChar"))
            {
                HavePurpleChar = PlayerPrefs.GetInt("HavePurpleChar");
                HaveDefChar = PlayerPrefs.GetInt("HaveDefChar");
                HaveBlueChar = PlayerPrefs.GetInt("HaveBlueChar");
                HaveConeChar = PlayerPrefs.GetInt("HaveConeChar");
                HaveCubeChar = PlayerPrefs.GetInt("HaveCubeChar");
                HaveDonutChar = PlayerPrefs.GetInt("HaveDonutChar");
                HaveCylinderChar = PlayerPrefs.GetInt("HaveCylinderChar");
                HaveGolfChar = PlayerPrefs.GetInt("HaveGolfChar");
            }

            // Check what ablt player have
            if (HaveHeal != PlayerPrefs.GetInt("HaveHeal") || HaveSlow != PlayerPrefs.GetInt("HaveSlow") || HaveUnk != PlayerPrefs.GetInt("HaveUnk") || HaveCoinUp != PlayerPrefs.GetInt("HaveCoinUp") || HaveXpUp != PlayerPrefs.GetInt("HaveXpUp") || HaveDash != PlayerPrefs.GetInt("HaveDash") ||  HaveDJump != PlayerPrefs.GetInt("HaveDJump") ||  HaveLevitate != PlayerPrefs.GetInt("HaveLevitate") || HaveMagnet != PlayerPrefs.GetInt("HaveMagnet"))
            {
                HaveHeal = PlayerPrefs.GetInt("HaveHeal");
                HaveSlow = PlayerPrefs.GetInt("HaveSlow");
                HaveUnk = PlayerPrefs.GetInt("HaveUnk");
                HaveCoinUp = PlayerPrefs.GetInt("HaveCoinUp");
                HaveXpUp = PlayerPrefs.GetInt("HaveXpUp");
                HaveDash = PlayerPrefs.GetInt("HaveDash");
                HaveMagnet = PlayerPrefs.GetInt("HaveMagnet");
                HaveDJump = PlayerPrefs.GetInt("HaveDJump");
                HaveLevitate = PlayerPrefs.GetInt("HaveLevitate");
            }


            ListFaded(HaveBlueChar, BlueListCharImg);
            ListFaded(HavePurpleChar, PurpleListCharImg);
            ListFaded(HaveConeChar, ConeListCharImg);
            ListFaded(HaveCubeChar, CubeListCharImg);
            ListFaded(HaveDonutChar, DonutListCharImg);
            ListFaded(HaveCylinderChar, CylinderListCharImg);
            ListFaded(HaveGolfChar, GolfListCharImg);
            
            ListFaded(HaveHeal, HealListBtn);
            ListFaded(HaveSlow, SlowListBtn);
            ListFaded(HaveUnk, UnkListBtn);
            ListFaded(HaveXpUp, XpUpListBtn);
            ListFaded(HaveCoinUp, CoinUpListBtn);
            ListFaded(HaveDash, DashListBtn);
            ListFaded(HaveDJump, DJumpListBtn);
            ListFaded(HaveLevitate, LevitateListBtn);

            // Change material after choose another character
            if (charac != PlayerPrefs.GetString("PlayChar"))
            {
                charac = PlayerPrefs.GetString("PlayChar");
                if (charac == "DefChar")
                {
                    //Player.GetComponent<MeshRenderer>().material = DefMat;
                    DefBtnImage.SetActive(true);
                    PurpleBtnImage.SetActive(false);
                    BlueBtnImage.SetActive(false);
                    GolfBtnImage.SetActive(false);
                    CubeBtnImage.SetActive(false);
                    DonutBtnImage.SetActive(false);
                    ConeBtnImage.SetActive(false);
                    CyliderBtnImage.SetActive(false);

                    
                }
                else if (charac == "PurpleChar")
                {
                    //Player.GetComponent<MeshRenderer>().material = PurpleMat;
                    DefBtnImage.SetActive(false);
                    PurpleBtnImage.SetActive(true);
                    BlueBtnImage.SetActive(false);
                    GolfBtnImage.SetActive(false);
                    CubeBtnImage.SetActive(false);
                    DonutBtnImage.SetActive(false);
                    ConeBtnImage.SetActive(false);
                    CyliderBtnImage.SetActive(false);
                    
                }
                else if (charac == "BlueChar")
                {
                    //Player.GetComponent<MeshRenderer>().material = BlueMat;
                    DefBtnImage.SetActive(false);
                    PurpleBtnImage.SetActive(false);
                    BlueBtnImage.SetActive(true);
                    GolfBtnImage.SetActive(false);
                    CubeBtnImage.SetActive(false);
                    DonutBtnImage.SetActive(false);
                    ConeBtnImage.SetActive(false);
                    CyliderBtnImage.SetActive(false);
                }
                else if (charac == "GoldChar")
                {
                    //Player.GetComponent<MeshRenderer>().material = GolfMat;
                    DefBtnImage.SetActive(false);
                    PurpleBtnImage.SetActive(false);
                    BlueBtnImage.SetActive(false);
                    GolfBtnImage.SetActive(true);
                    CubeBtnImage.SetActive(false);
                    DonutBtnImage.SetActive(false);
                    ConeBtnImage.SetActive(false);
                    CyliderBtnImage.SetActive(false);
                }
                else if (charac == "CylidnerChar")
                {
                    //Player.GetComponent<MeshRenderer>().material = CylinderMat;
                    DefBtnImage.SetActive(false);
                    PurpleBtnImage.SetActive(false);
                    BlueBtnImage.SetActive(false);
                    GolfBtnImage.SetActive(false);
                    CubeBtnImage.SetActive(false);
                    DonutBtnImage.SetActive(false);
                    ConeBtnImage.SetActive(false);
                    CyliderBtnImage.SetActive(true);
                }
                else if (charac == "CubeChar")
                {
                    //Player.GetComponent<MeshRenderer>().material = CubeMat;
                    DefBtnImage.SetActive(false);
                    PurpleBtnImage.SetActive(false);
                    BlueBtnImage.SetActive(false);
                    GolfBtnImage.SetActive(false);
                    CubeBtnImage.SetActive(true);
                    DonutBtnImage.SetActive(false);
                    ConeBtnImage.SetActive(false);
                    CyliderBtnImage.SetActive(false);
                }
                else if (charac == "DonutChar")
                {
                    //Player.GetComponent<MeshRenderer>().material = DonutMat;
                    DefBtnImage.SetActive(false);
                    PurpleBtnImage.SetActive(false);
                    BlueBtnImage.SetActive(false);
                    GolfBtnImage.SetActive(false);
                    CubeBtnImage.SetActive(false);
                    DonutBtnImage.SetActive(true);
                    ConeBtnImage.SetActive(false);
                    CyliderBtnImage.SetActive(false);
                }
                else if (charac == "ConeChar")
                {
                    //Player.GetComponent<MeshRenderer>().material = ConeMat;
                    DefBtnImage.SetActive(false);
                    PurpleBtnImage.SetActive(false);
                    BlueBtnImage.SetActive(false);
                    GolfBtnImage.SetActive(false);
                    CubeBtnImage.SetActive(false);
                    DonutBtnImage.SetActive(false);
                    ConeBtnImage.SetActive(true);
                    CyliderBtnImage.SetActive(false);
                }

            }

        }

        // list fce
        public void InvCharBtn()
        {
            CharList.SetActive(true);
            AblList.SetActive(false);
            BoostList.SetActive(false);

        }

        public void InvAblBtn()
        {
            CharList.SetActive(false);
            AblList.SetActive(true);
            BoostList.SetActive(false);
        }

        public void InvBoostBtn()
        {
            CharList.SetActive(false);
            AblList.SetActive(false);
            BoostList.SetActive(true);
        }

        // choose char fce

        public void ChooseCharDef()
        {
            PlayerPrefs.SetString("PlayChar", "DefChar");
            DefBtnImage.SetActive(true);
                    PurpleBtnImage.SetActive(false);
                    BlueBtnImage.SetActive(false);
                    GolfBtnImage.SetActive(false);
                    CubeBtnImage.SetActive(false);
                    DonutBtnImage.SetActive(false);
                    ConeBtnImage.SetActive(false);
                    CyliderBtnImage.SetActive(false);
            Player.GetComponent<MeshRenderer>().material = DefMat;
            Player.GetComponent<MeshFilter>().mesh = Sphere;
        }

        public void ChooseCharPurple()
        {
            if (HavePurpleChar == 1)
            {
                PlayerPrefs.SetString("PlayChar", "PurpleChar");
                PlayerPrefs.Save();
                 DefBtnImage.SetActive(false);
                    PurpleBtnImage.SetActive(true);
                    BlueBtnImage.SetActive(false);
                    GolfBtnImage.SetActive(false);
                    CubeBtnImage.SetActive(false);
                    DonutBtnImage.SetActive(false);
                    ConeBtnImage.SetActive(false);
                    CyliderBtnImage.SetActive(false);
                    
                Player.GetComponent<MeshRenderer>().material = PurpleMat;
                Player.GetComponent<MeshFilter>().mesh = Sphere;
            }

        }

        public void ChooseCharBlue()
        {
            if (HaveBlueChar == 1)
            {
                PlayerPrefs.SetString("PlayChar", "BlueChar");
                PlayerPrefs.Save();
                DefBtnImage.SetActive(false);
                    PurpleBtnImage.SetActive(false);
                    BlueBtnImage.SetActive(true);
                    GolfBtnImage.SetActive(false);
                    CubeBtnImage.SetActive(false);
                    DonutBtnImage.SetActive(false);
                    ConeBtnImage.SetActive(false);
                    CyliderBtnImage.SetActive(false);
                Player.GetComponent<MeshRenderer>().material = BlueMat;
                Player.GetComponent<MeshFilter>().mesh = Sphere;
            }
        }

        public void ChooseCharGolf()
        {
            if (HaveGolfChar == 1)
            {
                PlayerPrefs.SetString("PlayChar", "GoldChar");
                PlayerPrefs.Save();
                DefBtnImage.SetActive(false);
                    PurpleBtnImage.SetActive(false);
                    BlueBtnImage.SetActive(false);
                    GolfBtnImage.SetActive(true);
                    CubeBtnImage.SetActive(false);
                    DonutBtnImage.SetActive(false);
                    ConeBtnImage.SetActive(false);
                    CyliderBtnImage.SetActive(false);
                Player.GetComponent<MeshRenderer>().material = GolfMat;
                Player.GetComponent<MeshFilter>().mesh = Golf;
            }
        }

        public void ChooseCharCylinder()
        {
            if (HaveCylinderChar == 1)
            {
                PlayerPrefs.SetString("PlayChar", "CylidnerChar");
                PlayerPrefs.Save();
                DefBtnImage.SetActive(false);
                    PurpleBtnImage.SetActive(false);
                    BlueBtnImage.SetActive(false);
                    GolfBtnImage.SetActive(false);
                    CubeBtnImage.SetActive(false);
                    DonutBtnImage.SetActive(false);
                    ConeBtnImage.SetActive(false);
                    CyliderBtnImage.SetActive(true);
                Player.GetComponent<MeshRenderer>().material = CylinderMat;
                Player.GetComponent<MeshFilter>().mesh = Cylinder;
            }
        }

        public void ChooseCharCube()
        {
            if (HaveCubeChar == 1)
            {
                PlayerPrefs.SetString("PlayChar", "CubeChar");
                PlayerPrefs.Save();
                DefBtnImage.SetActive(false);
                    PurpleBtnImage.SetActive(false);
                    BlueBtnImage.SetActive(false);
                    GolfBtnImage.SetActive(false);
                    CubeBtnImage.SetActive(true);
                    DonutBtnImage.SetActive(false);
                    ConeBtnImage.SetActive(false);
                    CyliderBtnImage.SetActive(false);
                Player.GetComponent<MeshRenderer>().material = CubeMat;
                Player.GetComponent<MeshFilter>().mesh = Cube;
            }
        }

        public void ChooseCharDonut()
        {
            if (HaveDonutChar == 1)
            {
                PlayerPrefs.SetString("PlayChar", "DonutChar");
                PlayerPrefs.Save();
                DefBtnImage.SetActive(false);
                    PurpleBtnImage.SetActive(false);
                    BlueBtnImage.SetActive(false);
                    GolfBtnImage.SetActive(false);
                    CubeBtnImage.SetActive(false);
                    DonutBtnImage.SetActive(true);
                    ConeBtnImage.SetActive(false);
                    CyliderBtnImage.SetActive(false);
                Player.GetComponent<MeshRenderer>().material = DonutMat;
                Player.GetComponent<MeshFilter>().mesh = Donut;
            }
        }

        public void ChooseCharCone()
        {
            if (HaveConeChar == 1)
            {
                PlayerPrefs.SetString("PlayChar", "ConeChar");
                PlayerPrefs.Save();
                DefBtnImage.SetActive(false);
                    PurpleBtnImage.SetActive(false);
                    BlueBtnImage.SetActive(false);
                    GolfBtnImage.SetActive(false);
                    CubeBtnImage.SetActive(false);
                    DonutBtnImage.SetActive(false);
                    ConeBtnImage.SetActive(true);
                    CyliderBtnImage.SetActive(false);
                Player.GetComponent<MeshRenderer>().material = ConeMat;
                Player.GetComponent<MeshFilter>().mesh = Cone;
            }
        }
        
        // choose abl fce

        public void ChooseAblHeal()
        {
            if (HaveHeal == 1)
            {
                PlayerPrefs.SetString("PlayAbl", "Heal");
                PlayerPrefs.Save();
                HealBtnImage.SetActive(true);
                SlowBtnImage.SetActive(false);
                UnkBtnImage.SetActive(false);
                CoinUpBtnImage.SetActive(false);
                XpUpBtnImage.SetActive(false);
                DashBtnImage.SetActive(false);
                DJBtnImage.SetActive(false);
                LevitateBtnImage.SetActive(false);
            }
        }
        
        public void ChooseAblSlow()
        {
            if (HaveSlow == 1)
            {
                PlayerPrefs.SetString("PlayAbl", "Slow");
                PlayerPrefs.Save();
                HealBtnImage.SetActive(false);
                SlowBtnImage.SetActive(true);
                UnkBtnImage.SetActive(false);
                CoinUpBtnImage.SetActive(false);
                XpUpBtnImage.SetActive(false);
                DashBtnImage.SetActive(false);
                DJBtnImage.SetActive(false);
                LevitateBtnImage.SetActive(false);
            }
        }
        
        public void ChooseAblUnk()
        {
            if (HaveUnk == 1)
            {
                PlayerPrefs.SetString("PlayAbl", "Unk");
                PlayerPrefs.Save();
                HealBtnImage.SetActive(false);
                SlowBtnImage.SetActive(false);
                UnkBtnImage.SetActive(true);
                CoinUpBtnImage.SetActive(false);
                XpUpBtnImage.SetActive(false);
                DashBtnImage.SetActive(false);
                DJBtnImage.SetActive(false);
                LevitateBtnImage.SetActive(false);
            }
        }
        
        public void ChooseAblCoinUp()
        {
            if (HaveCoinUp == 1)
            {
                PlayerPrefs.SetString("PlayAbl", "CoinUp");
                PlayerPrefs.Save();
                HealBtnImage.SetActive(false);
                SlowBtnImage.SetActive(false);
                UnkBtnImage.SetActive(false);
                CoinUpBtnImage.SetActive(true);
                XpUpBtnImage.SetActive(false);
                DashBtnImage.SetActive(false);
                DJBtnImage.SetActive(false);
                LevitateBtnImage.SetActive(false);
            }
        }
        
        public void ChooseAblXpUp()
        {
            if (HaveXpUp == 1)
            {
                PlayerPrefs.SetString("PlayAbl", "XpUp");
                PlayerPrefs.Save();
                HealBtnImage.SetActive(false);
                SlowBtnImage.SetActive(false);
                UnkBtnImage.SetActive(false);
                CoinUpBtnImage.SetActive(false);
                XpUpBtnImage.SetActive(true);
                DashBtnImage.SetActive(false);
                DJBtnImage.SetActive(false);
                LevitateBtnImage.SetActive(false);
            }
        }
        
        public void ChooseAblDash()
        {
            if (HaveDash == 1)
            {
                PlayerPrefs.SetString("PlayAbl", "Dash");
                PlayerPrefs.Save();
                HealBtnImage.SetActive(false);
                SlowBtnImage.SetActive(false);
                UnkBtnImage.SetActive(false);
                CoinUpBtnImage.SetActive(false);
                XpUpBtnImage.SetActive(false);
                DashBtnImage.SetActive(true);
                DJBtnImage.SetActive(false);
                LevitateBtnImage.SetActive(false);
            }
        }
        
        public void ChooseAblDJump()
        {
            if (HaveDJump == 1)
            {
                PlayerPrefs.SetString("PlayAbl", "DJump");
                PlayerPrefs.Save();
                HealBtnImage.SetActive(false);
                SlowBtnImage.SetActive(false);
                UnkBtnImage.SetActive(false);
                CoinUpBtnImage.SetActive(false);
                XpUpBtnImage.SetActive(false);
                DashBtnImage.SetActive(false);
                DJBtnImage.SetActive(true);
                LevitateBtnImage.SetActive(false);
            }
        }
        
        public void ChooseAblLevitate()
        {
            if  (HaveLevitate == 1)
            {
                PlayerPrefs.SetString("PlayAbl", "Levitate");
                PlayerPrefs.Save();
                HealBtnImage.SetActive(false);
                SlowBtnImage.SetActive(false);
                UnkBtnImage.SetActive(false);
                CoinUpBtnImage.SetActive(false);
                XpUpBtnImage.SetActive(false);
                DashBtnImage.SetActive(false);
                DJBtnImage.SetActive(false);
                LevitateBtnImage.SetActive(true);
            }
        }
}
