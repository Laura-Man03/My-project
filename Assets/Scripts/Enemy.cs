using System;
using Unity.Cinemachine;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public float enemySpeed = 3f;
   public Transform[] targets;
   private int currentIndex = 0;

   private void Update()
   {
      // Where we're supposed to be moving
      Transform target = targets[currentIndex];
      transform.position = Vector3.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);

      if (Vector3.Distance(transform.position, target.position) < 0.1f)
      {
         currentIndex = (currentIndex + 1) % targets.Length;
      }
   }
}
