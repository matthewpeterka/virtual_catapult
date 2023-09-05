using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PinElevationBolt : MonoBehaviour
{

    
    //
    [SerializeField] float pinElevationBoltTopLimit;
    [SerializeField] float pinElevationBoltBottomLimit;
    [SerializeField] GameObject valuePointsObj;
    [SerializeField] int totalPinPoints;
    [SerializeField] TextMeshPro pinValueText;


    private void OnEnable()
    {
        valuePointsObj.SetActive(false);

        // 
        StartCoroutine(InitialiseElevationBolt());
    }

    // initialising so we have default value at startup
    IEnumerator InitialiseElevationBolt()
    {
        yield return new WaitForSeconds(0.1f);
        MoveElevationBolt(transform.position);
    }

    // bolt movement code
    public void MoveElevationBolt(Vector2 touchPosition)
    {
        touchPosition = transform.parent.InverseTransformPoint(touchPosition);
        //UnityEditor.TransformWorldPlacementJSON:{ "position":{ "x":1.9549999237060547,"y":-1.6799999475479127,"z":0.0},"rotation":{ "x":0.0,"y":0.0,"z":0.0,"w":1.0},"scale":{ "x":1.0,"y":1.0,"z":1.0} }
        //UnityEditor.TransformWorldPlacementJSON:{ "position":{ "x":1.9549999237060547,"y":0.6000000238418579,"z":0.0},"rotation":{ "x":0.0,"y":0.0,"z":0.0,"w":1.0},"scale":{ "x":1.0,"y":1.0,"z":1.0} }

        Vector2 elevationBoltPosition = transform.localPosition;
        elevationBoltPosition.y = Mathf.Clamp(touchPosition.y, pinElevationBoltBottomLimit, pinElevationBoltTopLimit);

        transform.localPosition = elevationBoltPosition;
        CalculatePointerValue(elevationBoltPosition.y);

    }

    // change y value based on our range of values
    private void CalculatePointerValue(float pinYValue)
    {
        float differencePinLimit = pinElevationBoltTopLimit - pinElevationBoltBottomLimit;
        float eachPartPinLimit = differencePinLimit / totalPinPoints;

        float pinDistanceFromBottom = pinYValue - pinElevationBoltBottomLimit;
        float pinValue = (pinDistanceFromBottom / eachPartPinLimit);

        pinValueText.text = Mathf.RoundToInt(pinValue).ToString();
        CatapultSettingsDialog.Instance.UpdatePinElevationText(Mathf.RoundToInt(pinValue));
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
