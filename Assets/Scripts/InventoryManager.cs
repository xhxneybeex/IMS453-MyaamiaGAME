using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Playables;

public class InventoryManager : MonoBehaviour
{
    //OFFICIAL EXTERIOR IS TOWN_EXTERIOR

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject InventoryHUD;
    public GameObject Notif;
    public UI ui;

    public GameObject left;
    public GameObject right;
    public GameObject polaroidL;
    public GameObject polaroidR;
    //public TextMeshProUGUI MugText;
    public GameObject tasks;

    public GameObject itemJournal;
    //public Image MugSprite;

    //public TextMeshProUGUI GlovesText;
    //public Image GlovesSprite;

    //public TextMeshProUGUI CoatText;
    // public Image CoatSprite;

    // public GameObject PlayGloves;

    //public GameObject PlayCoat;

    //public GameObject gloveAud;

    //public GameObject coatAud;

    //public AudioSource gloves;
    //public AudioSource coat;

    public static InventoryManager Instance;

    public List<Item> Items = new List<Item>();

    public static int currentTwoPages = 1;

    public static bool CoffeeCollected = false;
    public static bool GlovesCollected = false;

    public static bool CoatCollected = false;
    public static bool ChairCollected = false;
    public static bool HammerCollected = false;
    public static bool KeysCollected = false;
    public static bool RugCollected = false;
    public static bool BlanketCollected = false;
    public static bool SaltCollected = false;
    public static bool PepperCollected = false;
    public static bool ShoeCollected = false;
    public static bool BallCollected = false;
    public static bool CornCollected = false;
    public static bool PlatesCollected = false;
    public static bool ForksCollected = false;
    public static bool SpoonsCollected = false;
    public static bool BrushCollected = false;
    public static bool StickCollected = false;
    public static bool SoapCollected = false;
    public static bool TowelCollected = false;

    public static bool TableCollected = false;
    public static bool StoveCollected = false;
    public static bool RefridgeratorCollected = false;
    public static bool LampCollected = false;


    //public InventoryItemController iic;

    public void Add(Item item)
    {
        Items.Add(item);
    }

    private void Awake()
    {
        checkForCollected();
        Instance = this;
        tasks.SetActive(false);
        SetUIItemsFalse();
    }

    /*public void OpenJournal()
     {
         Debug.Log("AAAA");
         if (!InventoryHUD.activeInHierarchy)
         {
             ItemsTab();
             InventoryHUD.SetActive(true);
             Debug.Log("inventory should be open :)");

             if (currentTwoPages == 1 && UI.journalActive == true)
             {
                 Debug.Log("should be showing gloves and/or coat rn");
                 GlovesPolaroid();
                 CoatPolaroid();
             }

             if (Notif.activeInHierarchy)
             {
                 Notif.gameObject.SetActive(false);
             }
         }
         else if (InventoryHUD.activeInHierarchy)
         {
             InventoryHUD.SetActive(false);
             Debug.Log("inventory should be closed :)");
         }
     } */
    public void OpenJournal()
    {
        checkForCollected();
        ActivateCorrectPage();
        Debug.Log("AAAA");
        if (!InventoryHUD.activeInHierarchy)
        {
            InventoryHUD.SetActive(true);
            Debug.Log("inventory should be open :)");

            if (Notif.activeInHierarchy)
            {
                Notif.gameObject.SetActive(false);
                Debug.Log("Notification icon dissappears when inventory opens.");
                TasksTab();
            }
        }

        else if (InventoryHUD.activeInHierarchy)
        {
            InventoryHUD.SetActive(false);
            if (Notif.activeInHierarchy)
            {
                Notif.gameObject.SetActive(false);
                Debug.Log("Notification icon should dissappear when inventory closes.");
            }
            Debug.Log("inventory should be closed :)");
        }

        else
        {
            ItemsTab();
            ActivateCorrectPage();
        }
    }



    void Start()
    {
        InventoryHUD.SetActive(false);
        ui = GetComponent<UI>();
    }

    // Update is called once per frame
    void Update()
    {
        checkForCollected();

        if (UI.journalActive == true)
        {
            ActivateCorrectPage();
        }


        Debug.Log("two current pages are set: " + currentTwoPages);


    }

    public void TasksTab()
    {
        tasks.SetActive(true);
        Debug.Log("on tasks pages");
        polaroidL.SetActive(false);
        polaroidR.SetActive(false);
        left.SetActive(false);
        right.SetActive(false);
        SetUIItemsFalse();
    }


    public void SetUIItemsFalse()
    {
        itemJournal.transform.GetChild(0).gameObject.SetActive(false); //gloves entry
        itemJournal.transform.GetChild(1).gameObject.SetActive(false); //coat entry
        itemJournal.transform.GetChild(2).gameObject.SetActive(false); //coffee entry
        itemJournal.transform.GetChild(3).gameObject.SetActive(false); //keys entry
        itemJournal.transform.GetChild(4).gameObject.SetActive(false); //rug entry
        itemJournal.transform.GetChild(5).gameObject.SetActive(false); //salt entry
        itemJournal.transform.GetChild(6).gameObject.SetActive(false); //pepper entry
        itemJournal.transform.GetChild(7).gameObject.SetActive(false); //hairbrush entry
        itemJournal.transform.GetChild(8).gameObject.SetActive(false); //blanket entry
        itemJournal.transform.GetChild(9).gameObject.SetActive(false); //chair entry
        itemJournal.transform.GetChild(10).gameObject.SetActive(false); //hammer entry
        itemJournal.transform.GetChild(11).gameObject.SetActive(false); //shoe entry
        itemJournal.transform.GetChild(12).gameObject.SetActive(false); //ball entry
        itemJournal.transform.GetChild(13).gameObject.SetActive(false); //stick entry
        itemJournal.transform.GetChild(14).gameObject.SetActive(false); //soap entry
        itemJournal.transform.GetChild(15).gameObject.SetActive(false); //towel entry
        itemJournal.transform.GetChild(16).gameObject.SetActive(false); //corn entry
        itemJournal.transform.GetChild(17).gameObject.SetActive(false); //plates entry
        itemJournal.transform.GetChild(18).gameObject.SetActive(false); //forks entry
        itemJournal.transform.GetChild(19).gameObject.SetActive(false); //spoons entry
    }

    public void ItemsTab()
    {
        tasks.SetActive(false);
        checkForCollected();
        Debug.Log("on items pages");
        polaroidL.SetActive(true);
        polaroidR.SetActive(true);
        left.SetActive(true);
        right.SetActive(true);
        ActivateCorrectPage();
        // CoffeePolaroid();
    }


    void checkForCollected()
    {
        foreach (Item i in Items)
        {
            if (i.id == 5)
            {
                CoffeeCollected = true;
                Debug.Log("mug was collected");
            }

            if (i.id == 6)
            {
                GlovesCollected = true;
                Debug.Log("gloves were collected"); //it's running this when the coat is collected...?
            }

            if (i.id == 7)
            {
                CoatCollected = true;
                Debug.Log("coat was collected");
            }
        }
    }

    public void PlayGloveAudio()
    {
        itemJournal.transform.GetChild(0).gameObject.GetComponentInChildren<AudioSource>().Play();

        // PlayGloves.SetActive(true);
        // gloves.Play();
        Debug.Log("playing glove sound");
    }

    public void PlayCoatAudio()
    {
        itemJournal.transform.GetChild(1).gameObject.GetComponentInChildren<AudioSource>().Play();

        // coat.Play();
        Debug.Log("playing coat sound");
    }

    public void PlayCoffeeAudio()
    {
        itemJournal.transform.GetChild(2).gameObject.GetComponentInChildren<AudioSource>().Play();

        Debug.Log("playing coffee sound");
    }

    public void PlayKeysAudio()
    {
        itemJournal.transform.GetChild(3).gameObject.GetComponentInChildren<AudioSource>().Play();

        Debug.Log("playing keys sound");
    }

    public void PlayRugAudio()
    {
        itemJournal.transform.GetChild(4).gameObject.GetComponentInChildren<AudioSource>().Play();

        Debug.Log("playing rug sound");
    }

    public void PlaySaltAudio()
    {
        itemJournal.transform.GetChild(5).gameObject.GetComponentInChildren<AudioSource>().Play();

        Debug.Log("playing salt sound");
    }

    public void PlayPepperAudio()
    {
        itemJournal.transform.GetChild(6).gameObject.GetComponentInChildren<AudioSource>().Play();

        Debug.Log("playing pepper sound");
    }

    public void PlayHairAudio()
    {
        itemJournal.transform.GetChild(7).gameObject.GetComponentInChildren<AudioSource>().Play();

        Debug.Log("playing hair sound");
    }

    public void PlayBlanketAudio()
    {
        itemJournal.transform.GetChild(8).gameObject.GetComponentInChildren<AudioSource>().Play();

        Debug.Log("playing blanket sound");
    }

    public void PlayChairAudio()
    {
        itemJournal.transform.GetChild(9).gameObject.GetComponentInChildren<AudioSource>().Play();

        Debug.Log("playing chair sound");
    }

    public void PlayHammerAudio()
    {
        itemJournal.transform.GetChild(10).gameObject.GetComponentInChildren<AudioSource>().Play();

        Debug.Log("playing hammer sound");
    }

    public void PlayShoeAudio()
    {
        itemJournal.transform.GetChild(11).gameObject.GetComponentInChildren<AudioSource>().Play();

        Debug.Log("playing shoe sound");
    }

    public void PlayBallAudio()
    {
        itemJournal.transform.GetChild(12).gameObject.GetComponentInChildren<AudioSource>().Play();

        Debug.Log("playing ball sound");
    }

    public void PlayStickAudio()
    {
        itemJournal.transform.GetChild(13).gameObject.GetComponentInChildren<AudioSource>().Play();

        Debug.Log("playing stick sound");
    }

    public void PlaySoapAudio()
    {
        itemJournal.transform.GetChild(14).gameObject.GetComponentInChildren<AudioSource>().Play();

        Debug.Log("playing soap sound");
    }

    public void PlayTowelAudio()
    {
        itemJournal.transform.GetChild(15).gameObject.GetComponentInChildren<AudioSource>().Play();

        Debug.Log("playing towel sound");
    }

    public void PlayCornAudio()
    {
        itemJournal.transform.GetChild(16).gameObject.GetComponentInChildren<AudioSource>().Play();

        Debug.Log("playing corn sound");
    }

    public void PlayPlatesAudio()
    {
        itemJournal.transform.GetChild(17).gameObject.GetComponentInChildren<AudioSource>().Play();

        Debug.Log("playing plates sound");
    }

    public void PlayForksAudio()
    {
        itemJournal.transform.GetChild(18).gameObject.GetComponentInChildren<AudioSource>().Play();

        Debug.Log("playing forks sound");
    }

    public void PlaySpoonsAudio()
    {
        itemJournal.transform.GetChild(19).gameObject.GetComponentInChildren<AudioSource>().Play();

        Debug.Log("playing spoons sound");
    }

    public void PreviousPage()
    {
        if (currentTwoPages > 1)
        {
            currentTwoPages--;
        }

        ActivateCorrectPage();
    }

    public void NextPage()
    {
        currentTwoPages++;
        if (currentTwoPages > 1 && currentTwoPages < 11)
        {
            ActivateCorrectPage();
        }
    }

    public void ActivateCorrectPage()
    {
        if (currentTwoPages == 1)
        {
            GlovesPolaroid();
            CoatPolaroid();
            CoffeeOff();
            KeysOff();
            RugOff();
            SaltOff();
            PepperOff();
            HairOff();
            BlanketOff();
            ChairOff();
            HammerOff();
            ShoeOff();
            BallOff();
            StickOff();
            SoapOff();
            TowelOff();
            CornOff();
            PlatesOff();
            ForksOff();
            SpoonsOff();
        }
        else if (currentTwoPages == 2)
        {
            GlovesOff();
            CoatOff();
            RugOff();
            SaltOff();
            CoffeePolaroid();
            KeysPolaroid();
            PepperOff();
            HairOff();
            BlanketOff();
            ChairOff();
            HammerOff();
            ShoeOff();
            BallOff();
            StickOff();
            SoapOff();
            TowelOff();
            CornOff();
            PlatesOff();
            ForksOff();
            SpoonsOff();
        }
        else if (currentTwoPages == 3)
        {
            RugPolaroid();
            SaltPolaroid();
            GlovesOff();
            CoatOff();
            CoffeeOff();
            KeysOff();
            PepperOff();
            HairOff();
            BlanketOff();
            ChairOff();
            HammerOff();
            ShoeOff();
            BallOff();
            StickOff();
            SoapOff();
            TowelOff();
            CornOff();
            PlatesOff();
            ForksOff();
            SpoonsOff();
        }
        else if (currentTwoPages == 4)
        {
            PepperPolaroid();
            HairPolaroid();
            GlovesOff();
            CoatOff();
            CoffeeOff();
            KeysOff();
            SaltOff();
            RugOff();
            BlanketOff();
            ChairOff();
            HammerOff();
            ShoeOff();
            BallOff();
            StickOff();
            SoapOff();
            TowelOff();
            CornOff();
            PlatesOff();
            ForksOff();
            SpoonsOff();
        }
        else if (currentTwoPages == 5)
        {
            BlanketPolaroid();
            ChairPolaroid();
            GlovesOff();
            CoatOff();
            CoffeeOff();
            KeysOff();
            SaltOff();
            RugOff();
            PepperOff();
            HairOff();
            HammerOff();
            ShoeOff();
            BallOff();
            StickOff();
            SoapOff();
            TowelOff();
            CornOff();
            PlatesOff();
            ForksOff();
            SpoonsOff();
        }
        else if (currentTwoPages == 6)
        {
            HammerPolaroid();
            ShoePolaroid();
            GlovesOff();
            CoatOff();
            CoffeeOff();
            KeysOff();
            SaltOff();
            RugOff();
            PepperOff();
            HairOff();
            BlanketOff();
            ChairOff();
            BallOff();
            StickOff();
            SoapOff();
            TowelOff();
            CornOff();
            PlatesOff();
            ForksOff();
            SpoonsOff();
        }
        else if (currentTwoPages == 7)
        {
            BallPolaroid();
            StickPolaroid();
            GlovesOff();
            CoatOff();
            CoffeeOff();
            KeysOff();
            SaltOff();
            RugOff();
            PepperOff();
            HairOff();
            BlanketOff();
            ChairOff();
            HammerOff();
            ShoeOff();
            SoapOff();
            TowelOff();
            CornOff();
            PlatesOff();
            ForksOff();
            SpoonsOff();
        }
        else if (currentTwoPages == 8)
        {
            SoapPolaroid();
            TowelPolaroid();
            GlovesOff();
            CoatOff();
            CoffeeOff();
            KeysOff();
            SaltOff();
            RugOff();
            PepperOff();
            HairOff();
            BlanketOff();
            ChairOff();
            HammerOff();
            ShoeOff();
            BallOff();
            StickOff();
            CornOff();
            PlatesOff();
            ForksOff();
            SpoonsOff();
        }
        else if (currentTwoPages == 9)
        {
            CornPolaroid();
            PlatesPolaroid();
            GlovesOff();
            CoatOff();
            CoffeeOff();
            KeysOff();
            SaltOff();
            RugOff();
            PepperOff();
            HairOff();
            BlanketOff();
            ChairOff();
            HammerOff();
            ShoeOff();
            BallOff();
            StickOff();
            SoapOff();
            TowelOff();
            ForksOff();
            SpoonsOff();
        }
        else if (currentTwoPages == 10)
        {
            ForksPolaroid();
            SpoonsPolaroid();
            GlovesOff();
            CoatOff();
            CoffeeOff();
            KeysOff();
            SaltOff();
            RugOff();
            PepperOff();
            HairOff();
            BlanketOff();
            ChairOff();
            HammerOff();
            ShoeOff();
            BallOff();
            StickOff();
            SoapOff();
            TowelOff();
            CornOff();
            PlatesOff();
        }
        else
        {
            currentTwoPages = 10;
            PreviousPage();
            /* GlovesOff();
             CoatOff();
             CoffeeOff();
             KeysOff();
             SaltOff();
             RugOff();
             PepperOff();
             HairOff();
             BlanketOff();
             ChairOff();
             HammerOff();
             ShoeOff();
             BallOff();
             StickOff();
             SoapOff();
             TowelOff();
             CornOff();
             PlatesOff();
             ForksOff();
             SpoonsOff(); */
        }

    }

    public void GlovesPolaroid()
    {
        if (GlovesCollected == true)
        {
            itemJournal.transform.GetChild(0).gameObject.SetActive(true); //gloves entry
                                                                          //gloveAud.SetActive(true);
                                                                          //gloves.Stop();
        }
    }

    public void GlovesOff()
    {
        itemJournal.transform.GetChild(0).gameObject.SetActive(false); //gloves entry
    }

    public void CoatPolaroid()
    {
        if (CoatCollected == true)
        {
            itemJournal.transform.GetChild(1).gameObject.SetActive(true); //coat entry
                                                                          //coatAud.SetActive(true);
                                                                          //coat.Stop();

        }
    }

    public void CoatOff()
    {
        itemJournal.transform.GetChild(1).gameObject.SetActive(false); 

    }

    public void CoffeePolaroid()
    {
        if (CoffeeCollected == true)
        {
            itemJournal.transform.GetChild(2).gameObject.SetActive(true);

        }
    }

    public void CoffeeOff()
    {
        itemJournal.transform.GetChild(2).gameObject.SetActive(false); 

    }

    public void KeysPolaroid()
    {
        if (KeysCollected == true)
        {
            itemJournal.transform.GetChild(3).gameObject.SetActive(true);

        }
    }

    public void KeysOff()
    {
        itemJournal.transform.GetChild(3).gameObject.SetActive(false); 

    }

    public void RugPolaroid()
    {
        if (RugCollected == true)
        {
            itemJournal.transform.GetChild(4).gameObject.SetActive(true);

        }
    }

    public void RugOff()
    {
        itemJournal.transform.GetChild(4).gameObject.SetActive(false); 

    }

    public void SaltPolaroid()
    {
        if (SaltCollected == true)
        {
            itemJournal.transform.GetChild(5).gameObject.SetActive(true);

        }
    }

    public void SaltOff()
    {
        itemJournal.transform.GetChild(5).gameObject.SetActive(false); 

    }

    public void PepperPolaroid()
    {
        if (PepperCollected == true)
        {
            itemJournal.transform.GetChild(6).gameObject.SetActive(true);

        }
    }

    public void PepperOff()
    {
        itemJournal.transform.GetChild(6).gameObject.SetActive(false); 

    }

    public void HairPolaroid()
    {
        if (BrushCollected == true)
        {
            itemJournal.transform.GetChild(7).gameObject.SetActive(true);

        }
    }

    public void HairOff()
    {
        itemJournal.transform.GetChild(7).gameObject.SetActive(false); 

    }

    public void BlanketPolaroid()
    {
        if (BlanketCollected == true)
        {
            itemJournal.transform.GetChild(8).gameObject.SetActive(true);

        }
    }

    public void BlanketOff()
    {
        itemJournal.transform.GetChild(8).gameObject.SetActive(false); 

    }

    public void ChairPolaroid()
    {
        if (ChairCollected == true)
        {
            itemJournal.transform.GetChild(9).gameObject.SetActive(true);

        }
    }

    public void ChairOff()
    {
        itemJournal.transform.GetChild(9).gameObject.SetActive(false); 

    }

    public void HammerPolaroid()
    {
        if (HammerCollected == true)
        {
            itemJournal.transform.GetChild(10).gameObject.SetActive(true);

        }
    }

    public void HammerOff()
    {
        itemJournal.transform.GetChild(10).gameObject.SetActive(false); 

    }

    public void ShoePolaroid()
    {
        if (ShoeCollected == true)
        {
            itemJournal.transform.GetChild(11).gameObject.SetActive(true);

        }
    }

    public void ShoeOff()
    {
        itemJournal.transform.GetChild(11).gameObject.SetActive(false); 

    }

    public void BallPolaroid()
    {
        if (BallCollected == true)
        {
            itemJournal.transform.GetChild(12).gameObject.SetActive(true);

        }
    }

    public void BallOff()
    {
        itemJournal.transform.GetChild(12).gameObject.SetActive(false); 

    }

    public void StickPolaroid()
    {
        if (StickCollected == true)
        {
            itemJournal.transform.GetChild(13).gameObject.SetActive(true);

        }
    }

    public void StickOff()
    {
        itemJournal.transform.GetChild(13).gameObject.SetActive(false);

    }

    public void SoapPolaroid()
    {
        if (SoapCollected == true)
        {
            itemJournal.transform.GetChild(14).gameObject.SetActive(true);

        }
    }

    public void SoapOff()
    {
        itemJournal.transform.GetChild(14).gameObject.SetActive(false); 

    }

    public void TowelPolaroid()
    {
        if (TowelCollected == true)
        {
            itemJournal.transform.GetChild(15).gameObject.SetActive(true);

        }
    }

    public void TowelOff()
    {
        itemJournal.transform.GetChild(15).gameObject.SetActive(false); 

    }

    public void CornPolaroid()
    {
        if (CornCollected == true)
        {
            itemJournal.transform.GetChild(16).gameObject.SetActive(true);

        }
    }

    public void CornOff()
    {
        itemJournal.transform.GetChild(16).gameObject.SetActive(false); 

    }

    public void PlatesPolaroid()
    {
        if (PlatesCollected == true)
        {
            itemJournal.transform.GetChild(17).gameObject.SetActive(true);

        }
    }

    public void PlatesOff()
    {
        itemJournal.transform.GetChild(17).gameObject.SetActive(false);

    }

    public void ForksPolaroid()
    {
        if (ForksCollected == true)
        {
            itemJournal.transform.GetChild(18).gameObject.SetActive(true);

        }
    }

    public void ForksOff()
    {
        itemJournal.transform.GetChild(18).gameObject.SetActive(false);

    }

    public void SpoonsPolaroid()
    {
        if (SpoonsCollected == true)
        {
            itemJournal.transform.GetChild(19).gameObject.SetActive(true);

        }
    }

    public void SpoonsOff()
    {
        itemJournal.transform.GetChild(19).gameObject.SetActive(false); 

    }
}

