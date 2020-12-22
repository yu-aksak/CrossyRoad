using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Pool : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    private List<GameObject> objects = new List<GameObject>();
    public static int count = 20;
    [SerializeField] private Transform holder;

    private void Start()
    {
        objects = new List<GameObject>();
        for (int i = 0; i < count; i++)
        {
            GameObject obj = Instantiate(_object, new Vector3(0, 0, 0), Quaternion.identity, holder);
            obj.SetActive(false);
            objects.Add(obj);
        }
    }

    public GameObject GetObject()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (!objects[i].activeInHierarchy)
            {
                return objects[i];
            }
        }
        /*GameObject obj = (GameObject) Instantiate(_object, new Vector3(0, 0, 0), Quaternion.identity, holder);
        obj.SetActive(false);
        objects.Add(obj);
        count++;
        return obj;*/
        return null;
    }

    public GameObject Get(int i)
    {
        return objects[i];
    }
}