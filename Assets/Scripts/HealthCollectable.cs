using UnityEngine;

public class HeatlCollectable : MonoBehaviour
{
    //health collection  
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
    
        if (controller != null)
        {
            //this will only activate if the playercontroller is active different health collectable
            controller.ChangeHealth(1);
            Destroy(gameObject);
        }
    }
    
}
