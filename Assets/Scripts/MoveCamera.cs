using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCamera : MonoBehaviour
{

 
    [SerializeField] private GameObject player;
    public float cameraFollowSpeed;
    public float offset; 
    public bool isSmoothFollow = true;

    void Update ()
    {
        if (player)
        {
            Vector3 newCameraPosition = transform.position;
            newCameraPosition.x = player.transform.position.x * cameraFollowSpeed;
            newCameraPosition.z = player.transform.position.z - offset;
 
            if (!isSmoothFollow)
            {
                transform.position = newCameraPosition;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, newCameraPosition, cameraFollowSpeed * Time.deltaTime);
            }
        }
    }}
