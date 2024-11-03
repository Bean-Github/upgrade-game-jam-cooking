using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed;
    public float yOffset;
    
    private void Update()
    {
        Vector2 targetPosition = new Vector2(player.position.x, player.position.y + yOffset);
        //Vector2 dampSpeed = Vector2.zero;
        //Vector2 newPosition = Vector2.SmoothDamp(new Vector2(transform.position.x, transform.position.y),
            //targetPosition, ref dampSpeed, smoothSpeed * Time.deltaTime);
            Vector2 newPosition = Vector2.Lerp(new Vector2(transform.position.x, transform.position.y), targetPosition,
                smoothSpeed * Time.deltaTime);
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
    }
}
