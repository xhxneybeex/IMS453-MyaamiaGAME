using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject InventoryHUD;

    public TextMeshProUGUI MugText;
    public Image MugSprite;

    public TextMeshProUGUI GlovesText;
    public Image GlovesSprite;

      public TextMeshProUGUI CoatText;
    public Image CoatSprite;


    public static InventoryManager Instance;

    public List<Item> Items = new List<Item>();

    public bool MugCollected = false;
    public bool GlovesCollected = false;

    public bool CoatCollected = false;

    //public InventoryItemController iic;

    public void Add(Item item)
    {
        Items.Add(item);
    }

    private void Awake()
    {
        checkForCollected();
        Instance = this;
        MugText.gameObject.SetActive(false);
        MugSprite.gameObject.SetActive(false);
        GlovesText.gameObject.SetActive(false);
        GlovesSprite.gameObject.SetActive(false);
        CoatText.gameObject.SetActive(false);
        CoatSprite.gameObject.SetActive(false);
    }

    public void OpenInventory()
    {
        Debug.Log("AAAA");
        checkForCollected();
        if (InventoryHUD.activeInHierarchy)
        {
            InventoryHUD.SetActive(false);
            MugText.gameObject.SetActive(false);
            MugSprite.gameObject.SetActive(false);
            GlovesText.gameObject.SetActive(false);
            GlovesSprite.gameObject.SetActive(false);
            CoatText.gameObject.SetActive(false);
            CoatSprite.gameObject.SetActive(false);
            
        } 
        else if (!InventoryHUD.activeInHierarchy)
        {
            InventoryHUD.SetActive(true);
            if (MugCollected == true)
            {
                MugText.gameObject.SetActive(true);
                MugSprite.gameObject.SetActive(true);
            }

            else if (GlovesCollected == true)
            {
                GlovesText.gameObject.SetActive(true);
                GlovesSprite.gameObject.SetActive(true);
            }

            else if (CoatCollected == true)
            {
                CoatText.gameObject.SetActive(true);
                CoatSprite.gameObject.SetActive(true);
            }
        }


    }
    void Start()
    {
        InventoryHUD.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void checkForCollected()
    {
        foreach (Item i in Items)
        {
            if (i.id == 5)
            {
                MugCollected = true;
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
}
