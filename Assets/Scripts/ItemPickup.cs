using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item Item;
    public InventoryManager inventoryM;

    public GameObject player;

    private PlayerController playerController;

    public Camera camera;

    private RaycastHit hit;

    [SerializeField] public static bool thisHasBeenCollected = false;

    //player house
    public bool isGloves;
    public bool isCoat;
    public bool isChair;
    public bool isHammer;

    //larry's house
    public bool isCoffee;

    //drew's house
    public bool isKeys;
    public bool isRug;
    public bool isBlanket;

    //tony's house
    public bool isSalt;
    public bool isPepper;
    public bool isShoe;
    public bool isBall;
    public bool isCorn;
    public bool isPlates;
    public bool isForks;
    public bool isSpoons;

    //judy's house
    public bool isBrush;
    public bool isStick;
    public bool isSoap;
    public bool isTowel;


    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        camera = Camera.main;
        if (InventoryManager.CoatCollected == true && isCoat == true)
        {
            gameObject.SetActive(false);
        }
        else if (InventoryManager.GlovesCollected == true && isGloves == true)
        {
            gameObject.SetActive(false);
        }
        else if (InventoryManager.ChairCollected == true && isChair == true)
        {
            gameObject.SetActive(false);
        }
        else if (InventoryManager.HammerCollected == true && isHammer == true)
        {
            gameObject.SetActive(false);
        }
        else if (InventoryManager.KeysCollected == true && isKeys == true)
        {
            gameObject.SetActive(false);
        }
        else if (InventoryManager.RugCollected == true && isRug == true)
        {
            gameObject.SetActive(false);
        }
        else if (InventoryManager.BlanketCollected == true && isBlanket == true)
        {
            gameObject.SetActive(false);
        }
        else if (InventoryManager.SaltCollected == true && isSalt == true)
        {
            gameObject.SetActive(false);
        }
        else if (InventoryManager.PepperCollected == true && isPepper == true)
        {
            gameObject.SetActive(false);
        }  else if (InventoryManager.ShoeCollected == true && isShoe == true)
        {
            gameObject.SetActive(false);
        }  else if (InventoryManager.BallCollected == true && isBall == true)
        {
            gameObject.SetActive(false);
        } else if (InventoryManager.CornCollected == true && isCorn == true)
        {
            gameObject.SetActive(false);
        } else if (InventoryManager.PlatesCollected == true && isPlates == true)
        {
            gameObject.SetActive(false);
        } else if (InventoryManager.ForksCollected == true && isForks == true)
        {
            gameObject.SetActive(false);
        } else if (InventoryManager.SpoonsCollected == true && isSpoons == true)
        {
            gameObject.SetActive(false);
        } else if (InventoryManager.BrushCollected == true && isBrush == true)
        {
            gameObject.SetActive(false);
        } else if (InventoryManager.StickCollected == true && isStick == true)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }


    void Pickup()
    {
        InventoryManager.Instance.Add(Item);
        thisHasBeenCollected = true;

        if (isGloves)
        {
            InventoryManager.GlovesCollected = true;
            Debug.Log("gloves collected was set to true");
        }
        else if (isCoat)
        {
            InventoryManager.CoatCollected = true;
            Debug.Log("coat collected was set to true");
        }
        else if (isCoffee)
        {
            InventoryManager.CoffeeCollected = true;
            Debug.Log("coffee collected was set to true");
        }
        else if (isChair)
        {
            InventoryManager.ChairCollected = true;
            Debug.Log("chair collected was set to true");
        }
        else if (isHammer)
        {
            InventoryManager.HammerCollected = true;
            Debug.Log("hammer collected was set to true");
        }
        else if (isKeys)
        {
            InventoryManager.KeysCollected = true;
            Debug.Log("hammer collected was set to true");
        }
        else if (isRug)
        {
            InventoryManager.RugCollected = true;
            Debug.Log("hammer collected was set to true");
        }
        else if (isBlanket)
        {
            InventoryManager.BlanketCollected = true;
            Debug.Log("hammer collected was set to true");
        }
        else if (isSalt)
        {
            InventoryManager.SaltCollected = true;
            Debug.Log("salt collected was set to true");
        }
        else if (isPepper)
        {
            InventoryManager.PepperCollected = true;
            Debug.Log("pepper collected was set to true");
        } else if (isShoe)
        {
            InventoryManager.ShoeCollected = true;
            Debug.Log("shoe collected was set to true");
        }  else if (isBall)
        {
            InventoryManager.BallCollected = true;
            Debug.Log("ball collected was set to true");
        }  else if (isCorn)
        {
            InventoryManager.CornCollected = true;
            Debug.Log("corn collected was set to true");
        }  else if (isPlates)
        {
            InventoryManager.PlatesCollected = true;
            Debug.Log("plates collected was set to true");
        } else if (isForks)
        {
            InventoryManager.ForksCollected = true;
            Debug.Log("plates collected was set to true");
        } else if (isSpoons)
        {
            InventoryManager.SpoonsCollected = true;
            Debug.Log("plates collected was set to true");
        } else if (isBrush)
        {
            InventoryManager.BrushCollected = true;
            Debug.Log("plates collected was set to true");
        } else if (isStick)
        {
            InventoryManager.StickCollected = true;
            Debug.Log("plates collected was set to true");
        }


        gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {

        if (inventoryM.InventoryHUD.activeInHierarchy == false)
        {
            Pickup();
            Debug.Log("iT WORKED");
        }
        /*if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.up), out hit, Mathf.Max(5)))
        {
            Pickup();
            Debug.Log("");
        }*/
    }
}
