using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour
{
    private Func<Vector3> GetCameraFollowPositionFunc;
    public void Setup(Func<Vector3> GetCameraFollowPositionFunc)
    {
        this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
    }

    public void SetGetCameraFollowPositionFunc(Func<Vector3> GetCameraFollowPositionFunc)
    {
        this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
    }    
    void Update()
    {
        
        Vector3 cameraFollowPosition = GetCameraFollowPositionFunc();
        //==== fixing camera to stay fized only moving up?
        //     when I changed it to x it stayed fixed but then collectable removed everything ====
        cameraFollowPosition.z = transform.position.z;
        // cameraFollowPosition.x = transform.position.x;
        
        Vector3 cameraMoveDir = (cameraFollowPosition - transform.position).normalized;
        float distance = Vector3.Distance(cameraFollowPosition, transform.position);
        float cameraMoveSpeed = 2f;

        if (distance > 0)
        {
            //so that camera target doesn't jump back and forth on a low frame rate
            Vector3 newCameraPosition = transform.position + cameraMoveDir * distance * cameraMoveSpeed * Time.deltaTime;
            
            float distanceAfterMoving = Vector3.Distance(newCameraPosition, cameraFollowPosition);

            if (distanceAfterMoving > distance)
            {
                //overshot the target
                newCameraPosition = cameraFollowPosition;
            }
            
            transform.position = newCameraPosition;
        }
    }
}
