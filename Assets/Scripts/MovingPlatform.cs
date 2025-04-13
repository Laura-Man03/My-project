using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
   public float platformSpeed = 3f;
   public Transform[] targets;
   private int currentIndex = 0;

   private void Update()
   {
      // using array index storing them in order
      Transform target = targets[currentIndex];
      transform.position = Vector3.MoveTowards(transform.position, target.position, platformSpeed * Time.deltaTime);

      if (Vector3.Distance(transform.position, target.position) < 0.1f)
      {
         currentIndex = (currentIndex + 1) % targets.Length;
      }
   }
}
