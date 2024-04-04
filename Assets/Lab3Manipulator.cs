using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;
using System.Diagnostics;
using Unity.VisualScripting;

public class Lab3Manipulator : MouseManipulator
{

    protected override void RegisterCallbacksOnTarget()
    {
        target.RegisterCallback<MouseLeaveEvent>(OnMouseLeave);
        target.RegisterCallback<MouseEnterEvent>(OnMouseEnter);
    }

    protected override void UnregisterCallbacksFromTarget()
    {
        target.UnregisterCallback<MouseLeaveEvent>(OnMouseLeave);
        target.UnregisterCallback<MouseEnterEvent>(OnMouseEnter);
    }

    private void OnMouseEnter(MouseEnterEvent evn)
    {
        VisualElement root = target.ElementAt(0);
        root.visible = true;
        evn.StopPropagation();
    }
    private void OnMouseLeave(MouseLeaveEvent evn)
    {
        VisualElement root = target.ElementAt(0);
        root.visible = false;
        evn.StopPropagation();
    }
}
