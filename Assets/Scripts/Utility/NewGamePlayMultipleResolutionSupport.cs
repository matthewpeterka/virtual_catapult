
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// calculation to add support for multiple resolutions within the game
/// </summary>

public class NewGamePlayMultipleResolutionSupport : MonoBehaviour
{

    //
    [SerializeField] Camera gameCamera;
    [SerializeField] CanvasScaler uiCanvasScaler;

    //
    private double EPSILON = 0.01;

    void Awake()
    {
        DoResolutionSettings();
    }

    // detecting aspect ratio through mathemaical calculation
    private void DoResolutionSettings()
    {

        if (IsIPad())
        {
            uiCanvasScaler.matchWidthOrHeight = 0f;
            gameCamera.fieldOfView = 64f;
        }
        else if (Is16To10AspectRatio())
        {
            uiCanvasScaler.matchWidthOrHeight = 0.5f;
            gameCamera.fieldOfView = 55f;
        }
        else if (Is16To9AspectRatio())
        {
            uiCanvasScaler.matchWidthOrHeight = 0.5f;
            gameCamera.fieldOfView = 50f;
        }
        else if (IsIPhoneX())
        {
            uiCanvasScaler.matchWidthOrHeight = 1f;
            gameCamera.fieldOfView = 50f;
        }
        else if (Is2To1AspectRatio())
        {
            uiCanvasScaler.matchWidthOrHeight = 0.8f;
            gameCamera.fieldOfView = 53f;
        }
        else if (IsSamsungSSeriesAspectRatio())
        {
            uiCanvasScaler.matchWidthOrHeight = 0.8f;
            gameCamera.fieldOfView = 53f;
        }
        else if (IsSamsungNote10SeriesAspectRatio())
        {
            uiCanvasScaler.matchWidthOrHeight = 0.9f;
            gameCamera.fieldOfView = 53f;
        }
        else if (IsIPhone4SAspectRatio())
        {
            uiCanvasScaler.matchWidthOrHeight = 0f;
            gameCamera.fieldOfView = 53f;
        }
    }


    bool IsIPhone4SAspectRatio()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float baseWidth = 960f;
        float baseHeight = 640f;

        double screenRoundOff = Math.Round(screenWidth / screenHeight, 2);
        double baseRoundOff = Math.Round(baseWidth / baseHeight, 2);

        if (Math.Abs(screenRoundOff - baseRoundOff) <= EPSILON)
        {
            return true;
        }

        return false;
    }

    bool IsSamsungNote10SeriesAspectRatio()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float baseWidth = 2280f;
        float baseHeight = 1080f;

        double screenRoundOff = Math.Round(screenWidth / screenHeight, 2);
        double baseRoundOff = Math.Round(baseWidth / baseHeight, 2);

        if (Math.Abs(screenRoundOff - baseRoundOff) <= EPSILON)
        {
            return true;
        }

        return false;
    }

    bool IsSamsungSSeriesAspectRatio()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float baseWidth = 2960f;
        float baseHeight = 1440f;

        double screenRoundOff = Math.Round(screenWidth / screenHeight, 2);
        double baseRoundOff = Math.Round(baseWidth / baseHeight, 2);

        if (Math.Abs(screenRoundOff - baseRoundOff) <= EPSILON)
        {
            return true;
        }

        return false;
    }

    bool Is2To1AspectRatio()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float baseWidth = 2160f;
        float baseHeight = 1080f;

        double screenRoundOff = Math.Round(screenWidth / screenHeight, 2);
        double baseRoundOff = Math.Round(baseWidth / baseHeight, 2);

        if (Math.Abs(screenRoundOff - baseRoundOff) <= EPSILON)
        {
            return true;
        }

        return false;
    }

    bool IsIPad()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float baseWidth = 1024f;
        float baseHeight = 768f;

        double screenRoundOff = Math.Round(screenWidth / screenHeight, 2);
        double baseRoundOff = Math.Round(baseWidth / baseHeight, 2);

        if (Math.Abs(screenRoundOff - baseRoundOff) <= EPSILON)
        {
            return true;
        }

        return false;
    }

    bool Is16To10AspectRatio()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float baseWidth = 1280f;
        float baseHeight = 800f;

        double screenRoundOff = Math.Round(screenWidth / screenHeight, 2);
        double baseRoundOff = Math.Round(baseWidth / baseHeight, 2);

        if (Math.Abs(screenRoundOff - baseRoundOff) <= EPSILON)
        {
            return true;
        }

        return false;
    }

    bool Is16To9AspectRatio()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float baseWidth = 800f;
        float baseHeight = 480f;

        double screenRoundOff = Math.Round(screenWidth / screenHeight, 2);
        double baseRoundOff = Math.Round(baseWidth / baseHeight, 2);

        if (Math.Abs(screenRoundOff - baseRoundOff) <= EPSILON)
        {
            return true;
        }

        return false;
    }

    bool IsIPhoneX()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float baseWidth = 2436f;
        float baseHeight = 1125f;

        double screenRoundOff = Math.Round(screenWidth / screenHeight, 2);
        double baseRoundOff = Math.Round(baseWidth / baseHeight, 2);

        if (Math.Round(Math.Abs(screenRoundOff - baseRoundOff), 2) <= EPSILON)
        {
            return true;
        }

        return false;
    }

}
