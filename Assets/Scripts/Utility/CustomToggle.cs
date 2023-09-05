
using UnityEngine;


/// <summary>
/// custom class to handle toggle buttons in Unity
/// </summary>
public class CustomToggle : MonoBehaviour
{
    bool isOn;
    //
    [SerializeField] GameObject onStateObj;
    [SerializeField] GameObject offStateObj;

    private void OnEnable()
    {
        isOn = false;
        onStateObj.SetActive(false);
        offStateObj.SetActive(true);
    }


    public void OnToggleButtonClick()
    {

        if (isOn)
        {
            // make this off
            isOn = false;
            onStateObj.SetActive(false);
            offStateObj.SetActive(true);
        }
        else
        {
            // make this on
            isOn = true;
            onStateObj.SetActive(true);
            offStateObj.SetActive(false);
        }
    }

}
