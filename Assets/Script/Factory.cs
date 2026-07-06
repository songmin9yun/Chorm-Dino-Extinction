using UnityEngine;
using Random = UnityEngine.Random;

public class Factory : MonoBehaviour
{
    [field: SerializeField] public float spawnTime = 0.35f;
    [field: SerializeField] public float maxSpawnTime = 0.1f;
    [SerializeField] private float currentTime;
    public int Heartcount = 1;

    void Update()
    {
        if (ColorChange.isclicked == true)
        {
            if (currentTime >= spawnTime)
            {
                GameObject newPoop = ObjectPool.Instance.WifiGet();
                if (newPoop != null)
                {
                    newPoop.transform.position = new Vector3(Random.Range(-17.2f, 7.5f), 25f); // 코루틴 Coroutines
                }
                currentTime = 0;
            }
        

            if (Timer.score >= Heartcount * 100)
            {
                GameObject newHeart = ObjectPool.Instance.HeartGet();
            
                if (newHeart != null)
                {
                    newHeart.transform.position = new Vector3(Random.Range(-17.2f, 7.5f), 15f);
                    Heartcount++;
                }
            
            }
        }
    }

    void FixedUpdate()
    {
        if (ColorChange.isclicked == true)
        {
            currentTime += Time.fixedDeltaTime/1.5f;
        
            if (spawnTime > maxSpawnTime)
            {
                spawnTime -= 0.00003f;
            }
        }
    }
}
