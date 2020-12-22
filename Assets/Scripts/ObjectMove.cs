using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = System.Random;

public class ObjectMove : MonoBehaviour
{
    [SerializeField] private float speed;
    public float posZ;
    public bool isLog;
    public float duration;
    private GameObject _gameObject;
    [SerializeField] private AudioClip carMoveSound;

    private void Start()
    {
        _gameObject = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed);
        /*if (gameObject.activeInHierarchy)
        {
            Vector3 pos = transform.position;
            transform.DOMove(new Vector3(pos.x, pos.y, posZ), duration);
        }*/
        if (MovePlayer.isAlive == false)
            gameObject.SetActive(false);
        if (Math.Abs(_gameObject.transform.position.z - transform.position.z) > 20 ||
            Math.Abs(_gameObject.transform.position.x - transform.position.x) > 12)
            gameObject.SetActive(false);
        if (!isLog)
            AudioSource.PlayClipAtPoint(carMoveSound, transform.position);
    }
}