using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SocialPlatforms.Impl;

public class Factory : MonoBehaviour
{
    [field: SerializeField] public float spawnTime = 0.35f;
    [field: SerializeField] public float MaxSpawnTime = 0.1f;
    [SerializeField] private float currentTime;
    private int heartcount = 1;
    
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= spawnTime)
        {
            GameObject newPoop = GetComponent<ObjectPool>().PoopGet();
            if (newPoop != null)
            {
                newPoop.transform.position = new Vector3(Random.Range(-18f, 18f), 15f);
            }
            //Instantiate(PoopObject, new Vector3(Random.Range(-18f, 18f), 15f), quaternion.identity);
            currentTime = 0;
        }

        if (spawnTime > MaxSpawnTime)
        {
            spawnTime -= 0.00001f;
        }

        if (Poop.Score / 200 == heartcount)
        {
            GameObject newHeart = GetComponent<ObjectPool>().HeartGet();
            if (newHeart != null)
            {
                newHeart.transform.position = new Vector3(Random.Range(-18f, 18f), -9f);
            }

            heartcount++;
        }
    }
}
