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

    public GameObject polaroidL;
    public GameObject polaroidR;
    public TextMeshProUGUI MugText;
    public GameObject tasks;
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
        tasks.SetActive(false);
        MugText.gameObject.SetActive(false);
        MugSprite.gameObject.SetActive(false);
        GlovesText.gameObject.SetActive(false);
        GlovesSprite.gameObject.SetActive(false);
        CoatText.gameObject.SetActive(false);
        CoatSprite.gameObject.SetActive(false);
    }

    public void OpenJournal()
    {
        Debug.Log("AAAA");
        if (!InventoryHUD.activeInHierarchy)
        {
            ItemsTab();
            InventoryHUD.SetActive(true);
            Debug.Log("inventory should be open :)");
        }
        else if (InventoryHUD.activeInHierarchy)
        {
            InventoryHUD.SetActive(false);
            Debug.Log("inventory should be closed :)");
        }
    }
    void Start()
    {
        InventoryHUD.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        checkForCollected();
    }

    public void TasksTab()
    {
        tasks.SetActive(true);
        Debug.Log("on tasks pages");
        polaroidL.SetActive(false);
        polaroidR.SetActive(false);
        MugText.gameObject.SetActive(false);
        MugSprite.gameObject.SetActive(false);
        GlovesText.gameObject.SetActive(false);
        GlovesSprite.gameObject.SetActive(false);
        CoatText.gameObject.SetActive(false);
        CoatSprite.gameObject.SetActive(false);
    }

    public void ItemsTab()
    {
        checkForCollected();
        Debug.Log("on items pages");
        polaroidL.SetActive(true);
        polaroidR.SetActive(true);
        if (MugCollected == true)
        {
            MugText.gameObject.SetActive(true);
            MugSprite.gameObject.SetActive(true);
        }

        if (GlovesCollected == true)
        {
            GlovesText.gameObject.SetActive(true);
            GlovesSprite.gameObject.SetActive(true);
        }

        if (CoatCollected == true)
        {
            CoatText.gameObject.SetActive(true);
            CoatSprite.gameObject.SetActive(true);
            Debug.Log("this else if ran");
        }
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
