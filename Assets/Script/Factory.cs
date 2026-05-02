using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class Factory : MonoBehaviour
{
    [SerializeField] private float maxTime;
    [SerializeField] private float a;
    [SerializeField] private float currentTime;
    [SerializeField] private GameObject shitObject;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= maxTime)
        {
            Instantiate(shitObject, new Vector3(Random.Range(-18f, 18f), 15f), quaternion.identity);
            currentTime = 0;
        }

        if (maxTime > a)
        {
            maxTime -= 0.00001f;
        }
    }
}
