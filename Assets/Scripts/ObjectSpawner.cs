using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;
    public bool rotation;
    private Pool pool;
    public string name_;
    private void Start()
    {
        pool = GameObject.Find(name_).GetComponent<Pool>();
        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        while (true)
        {
            GameObject obj = pool.GetObject();
            obj.SetActive(true);
            obj.transform.position = new Vector3(spawnPos.position.x, spawnPos.position.y, spawnPos.position.z + Random.Range(-2, 2));
            //GameObject obj = Instantiate(_object, spawnPos.position, Quaternion.identity);
            if (!rotation)
            {
                obj.transform.Rotate(new Vector3(0, 180, 0));
            }
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        }
    }
}
