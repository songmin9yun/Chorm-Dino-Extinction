using UnityEngine;

public class ParticleOff : MonoBehaviour
{
    public ParticleSystem particle1;
    public ParticleSystem particle2;
    void Awake()
    {
        particle1 = transform.GetChild(0).GetComponent<ParticleSystem>();
        particle2 = transform.GetChild(1).GetComponent<ParticleSystem>();
    }

    public void particleOff()
    {
        particle1.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        particle2.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }

    public void particleOn()
    {
        particle1.Play();
        particle2.Play();
    }
}
