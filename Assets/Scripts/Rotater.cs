using UnityEngine;

public class Rotater : MonoBehaviour
{
    public float speed = 45;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
