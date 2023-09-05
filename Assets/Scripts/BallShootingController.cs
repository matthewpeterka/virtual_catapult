using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShootingController : MonoBehaviour
{

    public static BallShootingController Instance { private set; get; }
    //
    [SerializeField] GameObject shootingBallPref;
    [SerializeField] Transform shootingBallParent;

    //
    GameObject ballObj;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GenerateShootingBall();
    }

    private void GenerateShootingBall()
    {
        ballObj = Instantiate(shootingBallPref, shootingBallParent);
    }

    public void ShootTheBall(Vector2 ballVelocity)
    {
        Rigidbody2D ballRigidbody = ballObj.GetComponent<Rigidbody2D>();
        ballRigidbody.isKinematic = false;
        ballRigidbody.velocity = ballVelocity;

    }

}
