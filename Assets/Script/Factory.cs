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
        if (currentTime >= spawnTime)
        {
            GameObject newPoop = ObjectPool.Instance.PoopGet();
            if (newPoop != null)
            {
                newPoop.transform.position = new Vector3(Random.Range(-17.2f, 7.5f), 15f); // 코루틴 Coroutines
            }
            currentTime = 0;
        }
        

        if (Timer.score >= Heartcount * 200)
        {
            GameObject newHeart = ObjectPool.Instance.HeartGet();
            if (newHeart != null)
            {
                newHeart.transform.position = new Vector3(Random.Range(-17.2f, 7.5f), 15f);
            }
            Heartcount++;
        }
    }

    void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime/2;
        
        if (spawnTime > maxSpawnTime)
        {
            spawnTime -= 0.00004f;
        }
    }
}
