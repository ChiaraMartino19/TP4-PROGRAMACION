using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject[] objectPrefabs;
    [SerializeField] private List<GameObject> objectList;
    [SerializeField] private int poolSize;

    public static ObjectPool Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        AddObjectsToPool(poolSize);
    }

    private void AddObjectsToPool(int amount)
    {
        for (int p = 0; p < objectPrefabs.Length; p++)
        {
            GameObject objPrefab = objectPrefabs[p];

            for (int i = 0; i < amount; i++)
            {
                GameObject obj = Instantiate(objPrefab);
                obj.SetActive(false);
                objectList.Add(obj);
                obj.transform.parent = transform;
            }
        }
    }

    public GameObject RequestObject(int prefabIndex)
    {
        if (prefabIndex >= 0 && prefabIndex < objectPrefabs.Length)
        {
            for (int i = 0; i < objectList.Count; i++)
            {
                if (objectList[i] == objectPrefabs[prefabIndex] && !objectList[i].activeSelf)
                {
                    objectList[i].SetActive(true);
                    return objectList[i];
                }
            }

            GameObject newObj = Instantiate(objectPrefabs[prefabIndex]);
            newObj.SetActive(true);
            newObj.transform.parent = transform;
            objectList.Add(newObj);
            return newObj;
        }
        else
        {
            Debug.LogWarning("Índice de prefab fuera de rango");
            return null;
        }
    }

}
