using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coin;

    private void Start()
    {
        StartCoroutine(SpawnCar());

    }

    private IEnumerator SpawnCar()
    {
        float posX = transform.position.x;

        float posZ = Random.Range(-5, 5);
        while (true)
        {

            yield return new WaitForSeconds(4);
            GameObject obj = Instantiate(coin, new Vector3(posX, 1, posZ), Quaternion.identity);

        }
    }
}
