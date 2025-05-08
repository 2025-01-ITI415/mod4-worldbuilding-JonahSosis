using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // Reference to the cube
    public Vector3 offset = new Vector3(0f, 10f, -10f); // 45° above and behind
    public bool lockRotation = true;

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;

            if (lockRotation)
            {
                transform.rotation = Quaternion.Euler(45f, 0f, 0f); // Lock at 45 degrees
            }
        }
    }
}
