using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Button shoot;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float time;
    [SerializeField] private Transform holder;
    
    private void Start()
    {
        shoot.GetComponent<Button>().onClick.AddListener(Shoot);
    }

    public void Shoot()
    {
        GameObject obj = Instantiate(bullet, spawnPos.position, Quaternion.identity, holder);
        Destroy(obj, time);
    }
}
