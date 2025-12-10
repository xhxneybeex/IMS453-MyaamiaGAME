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

    private void OnTriggerEnter()
    {
        Debug.Log("AAAAA");
        SceneManager.LoadScene(sceneToLoad);
        is2DScene = to2DScene;
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