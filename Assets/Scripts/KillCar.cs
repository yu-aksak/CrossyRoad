using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MovePlayer>() != null)
        {
            MovePlayer.isAlive = false;
        }
    }
}
