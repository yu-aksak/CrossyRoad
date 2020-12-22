using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
   private GameObject player;
   
   private void Start()
   {
       player = GameObject.Find("Player");
       Transform transform1 = player.transform;
       if (Math.Abs(transform1.rotation.y + +0.7f) < 0.1)
       {
           var position = transform1.position;
           transform.DOMove(new Vector3(position.x, position.y, position.z + 1), 1 );
       }
       else if (Math.Abs(transform1.rotation.y - 0.7f) < 0.1)
       {
           var position = transform1.position;
           transform.DOMove(new Vector3(position.x, position.y, position.z - 1), 1 );
       }
       else if (Math.Abs(transform1.rotation.y - 0) < 0.1)
       {
           var position = transform1.position;
           transform.DOMove(new Vector3(position.x + 1, position.y, position.z), 1 );
       }
       else if (Math.Abs(transform1.rotation.y - 1) < 0.1)
       {
           var position = transform1.position;
           transform.DOMove(new Vector3(position.x - 1, position.y, position.z), 1);
       }
   }
   private void OnTriggerEnter(Collider other)
   {
       Debug.Log("qwertyuiop[poiuytrewq");
       if (other.transform.CompareTag("Car"))
       {
           other.gameObject.SetActive(false);
           Destroy(gameObject);
       }
   }
}
