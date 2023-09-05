using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// LockPin - 
/// </summary>
public class LockPin : MonoBehaviour
{

    //
    public float releaseBarMinimumAngle;
    [SerializeField] float releaseBarMaximumAngle;
    [SerializeField] GameObject valuePointsObj;
    [SerializeField] int totalPinPoints;
    [SerializeField] Transform releaseAngleBar;
    [SerializeField] Transform frontWoodSupport;
    [HideInInspector] public float lockPinAngle;
    [SerializeField] TextMeshPro pinValueText;
    //

    private void Start()
    {
        lockPinAngle = releaseBarMinimumAngle -90f;
    }

    private void OnEnable()
    {
        valuePointsObj.SetActive(false);
        // 
        StartCoroutine(InitialiseFollowPointByLockPin());
    }

    // initialising so we have default value at startup
    IEnumerator InitialiseFollowPointByLockPin()
    {
        yield return new WaitForSeconds(0.1f);
        RotateFollowPointByLockPin(transform.position);
    }

    public void OnTouchDownLockPin()
    {
        transform.SetParent(releaseAngleBar);
        EnableValuePointer();
    }

    public void OnTouchDragLockPin(Vector2 targetPoint2D)
    {
        RotateFollowPointByLockPin(targetPoint2D);
    }

    public void OnTouchUpLockPin()
    {
        transform.SetParent(frontWoodSupport);
        DisableValuePointer();
    }

    // rotate lock pin code
    public void RotateFollowPointByLockPin(Vector2 targetPoint2D)
    {
        Vector2 position2D = new Vector2(releaseAngleBar.parent.position.x, releaseAngleBar.parent.position.y);
        float angle = Vector2.Angle(Vector2.right, targetPoint2D - position2D);

        if (targetPoint2D.y < position2D.y)
            angle *= -1;

        float reformedAngle = Utility.Clamp0360(angle);
        reformedAngle = Mathf.Clamp(reformedAngle, releaseBarMinimumAngle, releaseBarMaximumAngle) - 90f;

        lockPinAngle = reformedAngle;
        releaseAngleBar.parent.eulerAngles = new Vector3(0, 0, reformedAngle);
        CalculatePointerValue(reformedAngle);
    }

    // converting actual angle value to our range of angle values
    private void CalculatePointerValue(float pinAngleValue)
    {
        float differencePinLimit = releaseBarMaximumAngle - releaseBarMinimumAngle;
        float eachPartPinLimit = differencePinLimit / totalPinPoints;

        float pinAngleFromStart = pinAngleValue - releaseBarMinimumAngle;
        float pinValue = 180f + (pinAngleFromStart / eachPartPinLimit);

        pinValueText.text = Mathf.RoundToInt(pinValue).ToString();
        CatapultSettingsDialog.Instance.UpdateFiringAngleText(Mathf.RoundToInt(pinValue));
        CatapultSettingsDialog.Instance.UpdateReleaseAngleText(Mathf.RoundToInt(pinValue));

    }

    private void EnableValuePointer()
    {
        valuePointsObj.SetActive(true);
    }

    private void DisableValuePointer()
    {
        valuePointsObj.SetActive(false);
    }

}
