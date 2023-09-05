using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// StringUpdater - based on 3 moveable points, we will continuously update string point values
/// </summary>
public class StringUpdater : MonoBehaviour
{

    LineRenderer myLineRenderer;
    //
    [SerializeField] Transform[] stringPoints;

    private void Start()
    {
        myLineRenderer = GetComponent<LineRenderer>();
        myLineRenderer.positionCount = stringPoints.Length;
        UpdateStringPoints();
    }

    // updating string positions
    private void UpdateStringPoints()
    {
        for (int i = 0; i < stringPoints.Length; i++)
        {
            myLineRenderer.SetPosition(i, stringPoints[i].position);
        }
    }

    private void Update()
    {
        UpdateStringPoints();
    }

}
