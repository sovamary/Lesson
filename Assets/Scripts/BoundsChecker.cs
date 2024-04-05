using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsChecker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float radius = 2f;
    public bool keepOnScreen = true;

    [Header("Set Dynamically")]
    public float cameraHeight, cameraWidth;
    public bool isOnScreen = true;

    [HideInInspector]
    public bool right, left, up, down;

    void Awake()
    {
         cameraHeight = Camera.main.orthographicSize;
         cameraWidth = cameraHeight * Camera.main.aspect;
    }

    void LateUpdate()
    {
        isOnScreen = true;
        Vector3 position = transform.position;
        right = left = up = down;
        if(position.x > cameraWidth - radius)
        {
            position.x = cameraWidth - radius;
            right = true;
        }
        if (position.x < -cameraWidth + radius)
        {
            position.x = -cameraWidth + radius;
            left = true;
        }

        if (position.y > cameraHeight - radius)
        {
            position.y = cameraHeight - radius;
            up = true;
        }

        if (position.y < -cameraHeight + radius)
        {
            position.y = -cameraHeight + radius;
            down = true;
        }
        isOnScreen = !(right || left || up || down);
        if (keepOnScreen && !isOnScreen)
        {
            transform.position = position;
            isOnScreen = true;
            right = left = up = down = false;
        }
        transform.position = position;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
