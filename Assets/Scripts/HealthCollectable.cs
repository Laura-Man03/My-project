using UnityEngine;

public class HeatlCollectable : MonoBehaviour
{
    //---- Health Collectable ----
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
    
        if (controller != null)
        {
            controller.ChangeHealth(10);
            Destroy(gameObject);
        }
    }
    
}
