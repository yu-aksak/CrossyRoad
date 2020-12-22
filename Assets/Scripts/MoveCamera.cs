using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public float cameraFollowSpeed;
    public Vector3 offset;
    private Camera _camera;
    private Vector3 prevPosPlayer = new Vector3(0,0,0);
    private Rigidbody rb;
 
    
    private void Start()
    {
        offset = transform.position - player.transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void Update ()
    {
        if (player.activeInHierarchy)
        {
            rb.velocity = new Vector3(cameraFollowSpeed, 0, 0);

            var position1 = transform.position;
            Vector3 newCameraPosition = position1;
            var position = player.transform.position;
            if (prevPosPlayer.x <= position.x)
            {
                newCameraPosition.z = position.z + offset.z;
                if (transform.position.x + 5 > player.transform.position.x)
                {
                    transform.position = position1;
                    prevPosPlayer = position;
                }
                else
                {
                    newCameraPosition.x = position.x + offset.x;
                    position1 = Vector3.Lerp(position1, newCameraPosition,
                        Time.deltaTime);
                    transform.position = position1;
                    prevPosPlayer = position;
                }
            }
            if (transform.position.x - 1 > player.transform.position.x)
            {
                MovePlayer.isAlive = false;
            }
        }
    }
}