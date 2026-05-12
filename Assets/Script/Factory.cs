using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class Factory : MonoBehaviour
{
    [SerializeField] private float maxTime;
    [SerializeField] private float a;
    [SerializeField] private float currentTime;

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= maxTime)
        {
            GameObject newPoop = GetComponent<ObjectPool>().Get();
            if (newPoop != null)
            {
                newPoop.transform.position = new Vector3(Random.Range(-18f, 18f), 15f);
            }
            //Instantiate(PoopObject, new Vector3(Random.Range(-18f, 18f), 15f), quaternion.identity);
            currentTime = 0;
        }

        if (maxTime > a)
        {
            maxTime -= 0.00001f;
        }
    }
}
