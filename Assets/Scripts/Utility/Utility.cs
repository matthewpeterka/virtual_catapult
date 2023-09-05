using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// all common useful methods placed here
/// </summary>
public static class Utility 
{

    // shuffle list items
    public static void Shuffle(IList<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            string temp = list[i];
            int randomIndex = UnityEngine.Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    // convert supplied number into time format
    public static string ConvertNumberToTimeFormat(int numberOfSeconds)
    {
        TimeSpan result = TimeSpan.FromSeconds(numberOfSeconds);
        return  result.ToString("mm':'ss");
    }

    // set same layerId to whole gameobject tree structure
    public static void SetLayerRecursively(this GameObject obj, int layer)
    {
        obj.layer = layer;

        foreach (Transform child in obj.transform)
        {
            child.gameObject.SetLayerRecursively(layer);
        }
    }

    // get layerNumber for supplied layerMask
    public static int GetLayerNumber(LayerMask _mask)
    {
        var bitmask = _mask.value;
        int result = bitmask > 0 ? 0 : 31;
        while (bitmask > 1)
        {
            bitmask = bitmask >> 1;
            result++;
        }
        return result;
    }

    // return angle between 0 to 360 degrees
    public static float Clamp0360(float eulerAngles)
    {
        float result = eulerAngles - Mathf.CeilToInt(eulerAngles / 360f) * 360f;
        if (result < 0)
        {
            result += 360f;
        }
        return result;
    }

    public static bool IsValueTrueFromRandomNumbers()
    {
        int value = UnityEngine.Random.Range(0, 2);
        return value == 1 ? true : false;
    }

    public static bool IsImageURL(string resourceURL)
    {
        if (resourceURL.Contains(".png") || resourceURL.Contains(".jpg") || resourceURL.Contains(".jpeg"))
            return true;

        return false;
    }

    // get full culture info
    public static void DisplayCultureInfoList()
    {
        foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.NeutralCultures))
        {
            Debug.Log("name: " + ci.Name + "- ISO language name: " + ci.TwoLetterISOLanguageName + "- 3 letters ISO language name: " + ci.ThreeLetterISOLanguageName
                + "- 3 letters windows language name: " + ci.ThreeLetterWindowsLanguageName + "- display name: " + ci.DisplayName + "- english name: " + ci.EnglishName);
        }
    }

    //
    public static string ToCamelCase(this string str)
    {
        if (!string.IsNullOrEmpty(str) && str.Length > 1)
        {
            return char.ToLowerInvariant(str[0]) + str.Substring(1);
        }
        return str.ToLowerInvariant();
    }

    public static string TitleCaseString(string s)
    {
        if (s == null) return s;

        string[] words = s.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length == 0) continue;

            char firstChar = char.ToUpper(words[i][0]);
            string rest = "";
            if (words[i].Length > 1)
            {
                rest = words[i].Substring(1).ToLower();
            }
            words[i] = firstChar + rest;
        }
        return string.Join(" ", words);
    }

    // retun common elements from two lists
    public static List<T> FindCommons<T>(List<T> pFirstList, List<T> pSecondList)
    {
        List<T> lstCommons = new List<T>();

        foreach (T item in pFirstList)
        {
            if (pSecondList.IndexOf(item) != -1)
            {
                lstCommons.Add(item);
            }
        }

        return lstCommons;
    }

    // detect touch is on any UI object
    public static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    // check animation state exist or not
    public static bool IsAnimationStateExist(Animation animation, string stateName)
    {
        foreach (AnimationState state in animation)
        {
            if (state.name == stateName)
                return true;
        }

        return false;
    }
}
