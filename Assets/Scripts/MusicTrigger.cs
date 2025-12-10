using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    [SerializeField] private AudioManager audioMan;
    [SerializeField] private int trackToPlay = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioMan.PlayTrack(trackToPlay);
        }
            
    }
}
