using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public int maxObject = 30;
    private List<GameObject> pool;

    public Transform parent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < maxObject; i++)
        {
            GameObject obj = Instantiate(prefab,parent);    
            obj.SetActive(false);
            pool.Add(obj);
        }
}

    public GameObject Get()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        return null;
    }
}
