using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBall : MonoBehaviour
{


    private void Start()
    {
        Camera.main.GetComponent<CameraFollow>().target = transform;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(GameConstants.TAG_MEASURE_LINE))
        {
            Destroy(GetComponent<Rigidbody2D>());
        }
    }


}
