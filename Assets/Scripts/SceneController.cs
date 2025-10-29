using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static bool is2DScene = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter()
    {
        Debug.Log("AAAAA");
        if (this.name == "Door")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("LarryHouseInterior");
            is2DScene = true;

        }

        if (this.name == "Rug Door")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
            is2DScene = false;
        }
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}