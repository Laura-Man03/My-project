using System;
using TMPro;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {
           
          controller. AddScore(1);
            Destroy(other.gameObject);
        }
    }
    
}
