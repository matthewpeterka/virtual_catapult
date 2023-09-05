using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CatapultSettingsDialog : MonoBehaviour
{


    public static CatapultSettingsDialog Instance { private set; get; }
    //
    [SerializeField] TextMeshProUGUI releaseAngleText;
    [SerializeField] TextMeshProUGUI firingAngleText;
    [SerializeField] TextMeshProUGUI cupElevationText;
    [SerializeField] TextMeshProUGUI barElevationText;
    [SerializeField] TextMeshProUGUI pinElevationText;
    [SerializeField] TextMeshProUGUI bungeePositionText;
    //

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateReleaseAngleText(int value) {
        ValuesManager.releaseAngle = value;
        releaseAngleText.text = ValuesManager.releaseAngle.ToString("D2");
    }

    public void UpdateFiringAngleText(int value)
    {
        ValuesManager.firingAngle = value;
        firingAngleText.text = ValuesManager.firingAngle.ToString("D2");
    }

    public void UpdateCupElevationText(int value)
    {
        ValuesManager.cupElevation = value;
        cupElevationText.text = ValuesManager.cupElevation.ToString("D2");
    }

    public void UpdateBarElevationText(int value)
    {
        ValuesManager.barElevation = value;
        barElevationText.text = ValuesManager.barElevation.ToString("D2");
    }

    public void UpdatePinElevationText(int value)
    {
        ValuesManager.pinElevation = value;
        pinElevationText.text = ValuesManager.pinElevation.ToString("D2");
    }

    public void UpdateBungeePositionText(int value)
    {
        ValuesManager.bungeePosition = value;
        bungeePositionText.text = ValuesManager.bungeePosition.ToString("D2");
    }

}
