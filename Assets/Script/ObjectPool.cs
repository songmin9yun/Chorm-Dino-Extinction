using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class ObjectPool : MonoBehaviour
{
    public GameObject PoopPrefab;
    public GameObject HeartPrefab;
    public int maxObject = 30;
    public int maxObject2 = 5;
    public List<GameObject> PoopPool;
    public List<GameObject> HeartPool; //딕셔너리 Dictionary로 List 하나로 만들고 Key룰 주고 가져오기
    
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
    
    //family == Father And Mother I Love You
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PoopPool = new List<GameObject>();
        HeartPool = new List<GameObject>();
        for (int i = 0; i < maxObject; i++)
        {
            GameObject obj = Instantiate(PoopPrefab,parent);    
            obj.SetActive(false);
            PoopPool.Add(obj);
        }
        
        for (int i = 0; i < maxObject2; i++)
        {
            GameObject obj = Instantiate(HeartPrefab,parent);    
            obj.SetActive(false);
            HeartPool.Add(obj);
        }
    }

    public GameObject PoopGet()
    {
        foreach (GameObject obj in PoopPool)
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
}