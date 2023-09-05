using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReleaseAngleBar : MonoBehaviour
{

    //
    [SerializeField] float releaseBarMinimumAngle;
    [SerializeField] float releaseBarMaximumAngle;
    [SerializeField] GameObject valuePointsObj;
    [SerializeField] int totalPinPoints;
    [SerializeField] LockPin lockPin;
    [SerializeField] TextMeshPro pinValueText;


    private void OnEnable()
    {
        valuePointsObj.SetActive(false);
        //
        StartCoroutine(InitialiseAngleBar());
    }

    // initialising so we have default value at startup
    IEnumerator InitialiseAngleBar()
    {
        yield return new WaitForSeconds(0.1f);
        RotateFollowPoint(transform.position);
    }


    // rotate parent because it is a pivot of whole structure
    //sets the angle of the bar to point in the direction of targetPoint2D
    public void RotateFollowPoint(Vector2 targetPoint2D)
    {
        Vector2 position2D = new Vector2(transform.parent.position.x, transform.parent.position.y);
        float angle = Vector2.Angle(Vector2.right, targetPoint2D - position2D);

        if (targetPoint2D.y < position2D.y)
            angle *= -1;

        float reformedAngle = Utility.Clamp0360(angle);        
        reformedAngle = Mathf.Clamp(reformedAngle, lockPin.lockPinAngle + 90f, releaseBarMaximumAngle) - 90f;

        transform.parent.eulerAngles = new Vector3(0, 0, reformedAngle);
        CalculatePointerValue(reformedAngle);
    }

    // converting angle to range of our values
    private void CalculatePointerValue(float pinAngleValue)
    {
        float differencePinLimit = releaseBarMaximumAngle - releaseBarMinimumAngle;
        float eachPartPinLimit = differencePinLimit / totalPinPoints;

        float pinAngleFromStart = pinAngleValue - releaseBarMinimumAngle;
        float pinValue = 180f + (pinAngleFromStart / eachPartPinLimit);

        pinValueText.text = Mathf.RoundToInt(pinValue).ToString();
        CatapultSettingsDialog.Instance.UpdateReleaseAngleText(Mathf.RoundToInt(pinValue));
    }

    public void EnableValuePointer()
    {
        valuePointsObj.SetActive(true);
    }

    public void DisableValuePointer()
    {
        valuePointsObj.SetActive(false);

        StartCoroutine(ReturnBackToLockPinMinimumAngle());
    }

    // returning back angle bar at default position
    IEnumerator ReturnBackToLockPinMinimumAngle()
    {
        Transform releaseAngleBar = transform.parent;

        Vector3 angleBarEulerAngles;
        while (releaseAngleBar.eulerAngles.z > lockPin.lockPinAngle) {
            angleBarEulerAngles = releaseAngleBar.eulerAngles;
            angleBarEulerAngles.z -= Time.deltaTime * 90f;
            releaseAngleBar.eulerAngles = angleBarEulerAngles;

            if (releaseAngleBar.eulerAngles.z > releaseBarMaximumAngle)
            {
                // if we don't change lock pin position then returning back from here
                VirtualCatapultController.Instance.CalculateBallDistance();
                yield break;
            }

            yield return null;
        }

        angleBarEulerAngles = releaseAngleBar.eulerAngles;
        angleBarEulerAngles.z = lockPin.lockPinAngle;
        releaseAngleBar.eulerAngles = angleBarEulerAngles;

        // when we change lock pin angle, we will return back from here
        VirtualCatapultController.Instance.CalculateBallDistance();

    }

}
