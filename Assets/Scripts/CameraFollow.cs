using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [HideInInspector] public Transform target;
    

    private void LateUpdate()
    {
        // if we have target then only move
        if (target == null)
            return;

        // restrict minimal horizontal movement after initial position
        if (target.position.x < 0.195f)
            return;

        Vector3 cameraPosition = transform.position;
        cameraPosition.x = target.position.x;
        transform.position = cameraPosition;
    }
}
