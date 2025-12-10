using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource sfx;

    [SerializeField] private AudioClip[] musicTracks;
    [SerializeField] private AudioClip[] sfxTracks;

    [SerializeField] private int trackOnEntry;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "Town_Exterior")
        {
            if (SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "Ending")
            {
                trackOnEntry = 0;
            } else
            {
                trackOnEntry = 3;
            }
                PlayTrack(trackOnEntry);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayTrack(int track)
    {
        // TRACKS:
        // 0: WIP A Town Waiting to Bloom
        // 1: WIP A Town in Bloom
        music.Stop();
        music.clip = musicTracks[track];
        music.Play();
    }

    public void PlaySFX(int track)
    {
        // TRACKS:
        // 0: Item Get
        // 1: Word Learned
        sfx.clip = sfxTracks[track];
        sfx.Play();
    }
}
