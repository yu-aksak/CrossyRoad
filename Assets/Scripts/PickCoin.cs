using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickCoin : MonoBehaviour
{
    [SerializeField] private AudioClip coinCollectSound;
    [SerializeField] GameObject player;
    private GameObject _gameObject;

    private void Start()
    {
        _gameObject = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        player = _gameObject;
        if (gameObject.activeInHierarchy)
        {
            if (player.transform.position.x - transform.position.x > 7)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(coinCollectSound, transform.position);
        MovePlayer._coins++;
        gameObject.SetActive(false);
    }
}