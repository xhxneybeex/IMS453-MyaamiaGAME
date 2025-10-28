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

    public TextMeshProUGUI LampText;

    public static InventoryManager Instance;

    public List<Item> Items = new List<Item>();

    bool LampCollected = false;

    //public InventoryItemController iic;

    public void Add(Item item)
    {
        Items.Add(item);
    }

    private void Awake()
    {
        Instance = this;
        LampText.gameObject.SetActive(false);
    }

    public void OpenInventory()
    {
        checkForCollected();
        if (InventoryHUD.activeInHierarchy)
        {
            InventoryHUD.SetActive(false);
            LampText.gameObject.SetActive(false);
            
        } 
        else if (!InventoryHUD.activeInHierarchy)
        {
            InventoryHUD.SetActive(true);
            if (LampCollected == true)
            {
                LampText.gameObject.SetActive(true);
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
            if (i.id == 0)
            {
                LampCollected = true;
            }
        }
    }
}
