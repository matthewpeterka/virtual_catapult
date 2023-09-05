using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VirtualCatapultController : MonoBehaviour
{

    public static VirtualCatapultController Instance;
    //
    public float BallDistance { private set; get; }
    //
    const float HEIGHT = 1.5f;
    const float GRAVITY = -20f;
    //const float GRAVITY = -9.81f;
    const float BASE_STAND_WIDTH = 5.93f;
    const float OBJECTS_GAP = 0.25f;

    private void Awake()
    {
        Instance = this;
        Physics2D.gravity = Vector2.up * GRAVITY;
    }

    // formula calculation exist here
    // 
    public void CalculateBallDistance()
    {
        NormalDistribution normalDistribution = new NormalDistribution(0, 10);

        float equationPart1 = 80f * ((ValuesManager.releaseAngle - 140f) / 50f);
        float equationPart2 = 20f * ((ValuesManager.firingAngle - 115f) / 25f);
        float equationPart3 = 40f * ((ValuesManager.cupElevation - 5f) / 5f);
        float equationPart4 = 35f * ((ValuesManager.pinElevation - 50f) / 50f);
        float equationPart5 = 40f * (((ValuesManager.releaseAngle - 140f) / 50f) * ((ValuesManager.firingAngle - 115f) / 25f));
        float equationPart6 = 100f * ((ValuesManager.barElevation - 5f) / 5f);

        BallDistance = 150f + equationPart1 + equationPart2 + equationPart3 + equationPart4 + equationPart5 + equationPart6 + (2f * ((float)normalDistribution.Sample(new System.Random())));

        // we don't need negative values
        BallDistance = BallDistance < 0f ? 0f : BallDistance;

        GameHUDPanel.Instance.UpdateBallDistanceText(BallDistance);
        Debug.Log("Ball Distance: " + BallDistance);

        // if ball distance value more than 0 then only shoot the ball
        if (BallDistance > 0f && Mathf.Abs(ValuesManager.firingAngle - ValuesManager.releaseAngle) > 10f)
            CalculateBallVelocity();

    }

    private void CalculateBallVelocity()
    {

        GameObject ballObj = GameObject.FindGameObjectWithTag(GameConstants.TAG_BALL);
        Vector3 ballPosition = ballObj.transform.position;

        const float TARGET_Y_POSITION = -5.3f;
        float TARGET_X_POSITION = (BallDistance * 0.1f) + (BASE_STAND_WIDTH * 0.5f) + OBJECTS_GAP;
        float BALL_Y_POSITION = ballPosition.y;
        float BALL_X_POSITION = ballPosition.x;

        float displacementY = TARGET_Y_POSITION - BALL_Y_POSITION;
        Vector3 displacementXZ = new Vector3(TARGET_X_POSITION - BALL_X_POSITION, 0f, 0f);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2f * GRAVITY * HEIGHT);
        Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2f * HEIGHT / GRAVITY) + Mathf.Sqrt(2f * (displacementY - HEIGHT) / GRAVITY));

        BallShootingController.Instance.ShootTheBall(velocityXZ + velocityY);
    }

}
