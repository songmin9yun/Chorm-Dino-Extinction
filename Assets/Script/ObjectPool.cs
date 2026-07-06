using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public GameObject WifiPrefab;
    public GameObject HeartPrefab;
    //public GameObject BurstPrefab;
    
    public int maxObject = 30;
    public int maxObject2 = 5;
    
    public List<GameObject> WifiPool;
    public List<GameObject> HeartPool; //딕셔너리 Dictionary로 List 하나로 만들고 Key룰 주고 가져오기
    //public List<GameObject> BurstPool;
    
    public static ObjectPool Instance = null;

    public Transform parent;
    void Awake()
    {
        
        
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        WifiPool = new List<GameObject>();
        HeartPool = new List<GameObject>();
        //BurstPool = new List<GameObject>();
        
        for (int i = 0; i < maxObject; i++)
        {
                GameObject obj = Instantiate(WifiPrefab,parent);    
            obj.SetActive(false);
            WifiPool.Add(obj);
        }
        
        for (int i = 0; i < maxObject2; i++)
        {
            GameObject obj = Instantiate(HeartPrefab,parent);    
            obj.SetActive(false);
            HeartPool.Add(obj);
        }
        
        // for (int i = 0; i < maxObject; i++)
        // {
        //     GameObject obj = Instantiate(BurstPrefab,parent);    
        //     obj.SetActive(false);
        //     BurstPool.Add(obj);
        // }
    }

    public GameObject WifiGet()
    {
        foreach (GameObject obj in WifiPool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        return null;
    }
    
    public GameObject HeartGet()
    {
        foreach (GameObject obj in HeartPool) // 한도가 초과되면 오브젝트풀 한도 늘리기에 추가해서 
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        return null;
    }

    // public GameObject BurstGet()
    // {
    //     foreach (GameObject obj in BurstPool)
    //     {
    //         if (!obj.activeInHierarchy)
    //         {
    //             obj.SetActive(true);
    //             return obj;
    //         }
    //     }
    //     return null;
    // }
}