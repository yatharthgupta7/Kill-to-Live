using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public float speed;
    public float minX, maxX, minY, maxY;
    void Start()
    {
        transform.position = player.position;
    }

    void Update()
    {
        if(player!=null)
        {
            float clampedX = Mathf.Clamp(player.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(player.position.y, minY, maxY);
            transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX,clampedY), speed);
        }
    }
}
