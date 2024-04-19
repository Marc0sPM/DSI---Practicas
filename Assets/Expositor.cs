using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class Expositor : MonoBehaviour
{
    public event Action Cambio;
    VisualElement expositorRoot;

    public VisualElement Imagen
    {
        get { return expositorRoot; }
        set {
            if (value != expositorRoot)
            {
                expositorRoot = value;
                Cambio?.Invoke();
            }
        }
    }

    public Expositor(VisualElement expositorRoot)
    {
        this.expositorRoot = expositorRoot;
    }
}
