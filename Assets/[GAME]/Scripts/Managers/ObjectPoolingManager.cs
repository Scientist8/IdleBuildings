using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    public static ObjectPoolingManager Instance { get; private set; }

    [System.Serializable]
    public class ObjectPoolItem
    {
        public GameObject prefab;
        public int poolSize;
    }

    public List<ObjectPoolItem> objectPoolItems;

    private Dictionary<GameObject, List<GameObject>> objectPools;

    void Awake()
    {
        SingletonThisObject();
    }

    void SingletonThisObject()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        objectPools = new Dictionary<GameObject, List<GameObject>>();

        foreach (ObjectPoolItem item in objectPoolItems)
        {
            CreateObjectPool(item.prefab, item.poolSize);
        }
    }

    void CreateObjectPool(GameObject prefab, int poolSize)
    {
        Transform poolParent = new GameObject(prefab.name + "Pool").transform;
        // poolParent.SetParent(transform);

        List<GameObject> objectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab, poolParent);
            obj.SetActive(false);
            objectPool.Add(obj);
        }

        objectPools.Add(prefab, objectPool);
    }

    public GameObject GetPooledObject(GameObject prefab)
    {
        if (objectPools.ContainsKey(prefab))
        {
            List<GameObject> objectPool = objectPools[prefab];

            foreach (GameObject obj in objectPool)
            {
                if (!obj.activeInHierarchy)
                {
                    return obj;
                }
            }

            GameObject newObj = Instantiate(prefab, objectPool[0].transform.parent);
            newObj.SetActive(false);
            objectPool.Add(newObj);

            return newObj;
        }
        else
        {
            Debug.LogWarning("Prefab not found in the object pool.");
            return null;
        }
    }
}