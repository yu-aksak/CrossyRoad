using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectMove : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    public bool isLog;
    [SerializeField] private float time;

    void Update()
    {
        transform.Translate(Vector3.forward * speed);
        if(Player.isAlive == false)
            Destroy(gameObject);
        Destroy(gameObject, time);
    }
}
