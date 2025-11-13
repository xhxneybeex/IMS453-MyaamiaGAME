using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource sfx;

    [SerializeField] private AudioClip[] musicTracks;
    [SerializeField] private AudioClip[] sfxTracks;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        if (track != -1)
        {
            music.Stop();
            music.clip = musicTracks[track];
            music.Play();
        } else
        {
            // Use -1 to stop
            music.Stop();
        }
        
    }

    public void PlaySFX(int track)
    {
        // TRACKS:
        // 0: Item Get
        // 1: Word Learned
        if (track != -1)
        {
            sfx.clip = sfxTracks[track];
            sfx.Play();
        } else
        {
            // Use -1 to stop
            sfx.Stop();
        }
        
    }
    
}
