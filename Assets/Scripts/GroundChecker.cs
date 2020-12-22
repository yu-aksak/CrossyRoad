using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private MovePlayer player;
    [SerializeField] private LayerMask groundLayer;
    private void OnTriggerEnter(Collider other)
    {
        if (1 << other.gameObject.layer == groundLayer.value)
        {
            player.IsGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (1 << other.gameObject.layer == groundLayer.value)
        {
            player.IsGrounded = false;
        }
    }
}
