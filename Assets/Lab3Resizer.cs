using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;
using System.Diagnostics;

public class Lab3Resizer : Manipulator
{
    float diff = 1;

    protected override void RegisterCallbacksOnTarget()
    {
        target.RegisterCallback<WheelEvent>(OnWheel);
    }

    protected override void UnregisterCallbacksFromTarget()
    {
        target.RegisterCallback<WheelEvent>(OnWheel);
    }

    private void OnWheel(WheelEvent evn)
    {
        diff -= evn.mouseDelta.y / 10;
        if(diff > 0 && diff < 1)
            target.ElementAt(1).style.scale = new Scale(new Vector3(diff, diff, 1));
        else
            diff += evn.mouseDelta.y / 10;
    }
}
