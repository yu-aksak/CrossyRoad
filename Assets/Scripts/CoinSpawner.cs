using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    private Pool pool;
    private void Start()
    {
        pool = GameObject.Find("PoolCoins").GetComponent<Pool>();
        SpawnCoin();
    }
    private void SpawnCoin()
    {
        float posX = transform.position.x;
        float posZ = Random.Range(-5, 5);
        GameObject obj = pool.GetObject();
        obj.SetActive(true);
        obj.transform.position = new Vector3(posX, 1, posZ);
    }
}
