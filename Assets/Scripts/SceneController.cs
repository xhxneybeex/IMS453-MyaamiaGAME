using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.IO;

public class SceneController : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private bool to2DScene = false;
    public static bool is2DScene = false;
    public GameObject exitScreen;
    public GameObject settingsScreen;

    void Start()
    {
        //exitScreen.SetActive(false);
        //settingsScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("AAAAA");
            SceneManager.LoadScene(sceneToLoad);
            is2DScene = to2DScene;
            if (to2DScene)
            {
                PlayerController.lastEntryPoint = other.transform.position;
                PlayerPrefs.SetFloat("X", PlayerController.lastEntryPoint.x);
                PlayerPrefs.SetFloat("Y", PlayerController.lastEntryPoint.y);
                PlayerPrefs.SetFloat("Z", PlayerController.lastEntryPoint.z);
            }
        }

    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Interior_PlayerHouse");
    }

    public void YesExit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
    }

    public void NoExit()
    {
        exitScreen.SetActive(false);
    }

    public void OpenSettings()
    {
        settingsScreen.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsScreen.SetActive(false);
    }
}