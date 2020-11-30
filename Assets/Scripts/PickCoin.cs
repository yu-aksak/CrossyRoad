using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickCoin : MonoBehaviour
{
    [SerializeField] private AudioClip coinCollectSound;

    private void Start()
    {
        Destroy(gameObject,4);
    }

    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(coinCollectSound, transform.position);
        Player._coins++;
        Destroy(gameObject);
    }
}