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
    [SerializeField] private bool rotation;
    private void Start()
    {
        StartCoroutine(SpawnCar());
        
    }

    private IEnumerator SpawnCar()
    {
        while (true)
        {

            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            GameObject obj = Instantiate(_object, spawnPos.position, Quaternion.identity);
            if (!rotation)
            {
                obj.transform.Rotate(new Vector3(0, 180, 0));
            }
        }
    }
}
