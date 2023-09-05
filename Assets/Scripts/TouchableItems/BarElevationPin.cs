using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarElevationPin : MonoBehaviour
{


    //
    [SerializeField] float barElevationPinTopLimit;
    [SerializeField] float barElevationPinBottomLimit;
    [SerializeField] GameObject valuePointsObj;
    [SerializeField] int totalPinPoints;
    [SerializeField] TextMeshPro pinValueText;

    private void OnEnable()
    {
        valuePointsObj.SetActive(false);
        //
        StartCoroutine(InitialiseBarElevationPin());
    }

    // initialising so we have default value at startup
    IEnumerator InitialiseBarElevationPin()
    {
        yield return new WaitForSeconds(0.1f);
        MoveElevationPin(transform.position);
    }

    public void MoveElevationPin(Vector2 touchPosition)
    {
        touchPosition = transform.parent.InverseTransformPoint(touchPosition);
        //UnityEditor.TransformWorldPlacementJSON:{ "position":{ "x":-1.4500000476837159,"y":3.9749999046325685,"z":0.0},"rotation":{ "x":0.0,"y":0.0,"z":0.0,"w":1.0},"scale":{ "x":1.0,"y":1.0,"z":1.0} }
        //UnityEditor.TransformWorldPlacementJSON:{ "position":{ "x":-1.4500000476837159,"y":1.9249999523162842,"z":0.0},"rotation":{ "x":0.0,"y":0.0,"z":0.0,"w":1.0},"scale":{ "x":1.0,"y":1.0,"z":1.0} }

        Vector2 elevationPinPosition = transform.localPosition;
        elevationPinPosition.y = Mathf.Clamp(touchPosition.y, barElevationPinBottomLimit, barElevationPinTopLimit);

        transform.localPosition = elevationPinPosition;
        CalculatePointerValue(elevationPinPosition.y);
    }

    // coverting position value to our range of values
    private void CalculatePointerValue(float pinYValue)
    {
        float differencePinLimit = barElevationPinTopLimit - barElevationPinBottomLimit;
        float eachPartPinLimit = differencePinLimit / totalPinPoints;

        float pinDistanceFromBottom = pinYValue - barElevationPinBottomLimit;
        float pinValue = (pinDistanceFromBottom / eachPartPinLimit);

        //pinValueText.text = (totalPinPoints - Mathf.RoundToInt(pinValue)).ToString();
        pinValueText.text =  Mathf.RoundToInt(pinValue).ToString();
        //CatapultSettingsDialog.Instance.UpdateBarElevationText((totalPinPoints - Mathf.RoundToInt(pinValue)));
        CatapultSettingsDialog.Instance.UpdateBarElevationText(Mathf.RoundToInt(pinValue));
    }

    public void EnableValuePointer()
    {
        valuePointsObj.SetActive(true);
    }

    public void DisableValuePointer()
    {
        valuePointsObj.SetActive(false);
    }

}
