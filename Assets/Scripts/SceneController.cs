using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.IO;

public class SceneController : MonoBehaviour
{
    public static bool is2DScene = false;
    public GameObject exitScreen;

    void Start()
    {
        exitScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "StartMenu") {
            exitScreen.SetActive(true);
        }
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

    public void YesExit() {
        Application.Quit();
    }

    public void NoExit() {
        exitScreen.SetActive(false);
    }
}