using UnityEngine;
using UnityEngine.Serialization;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource jumpAudio;
    [SerializeField] private AudioSource dieAudio;
    [SerializeField] private AudioSource pointAudio;

    public void jumpAudioPlay()
    {
        jumpAudio.Play();
    }

    public void dieAudioPlay()
    {
        dieAudio.Play();
    }
    
    public void pointAudioPlay()
    {
        pointAudio.Play();
    }
    
    
}