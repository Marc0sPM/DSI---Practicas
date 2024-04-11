using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Lab5 : MonoBehaviour
{
    VisualElement nombre1;
    VisualElement nombre2;
    VisualElement personaje;
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        nombre1 = root.Q<VisualElement>("3DIcon");
        nombre2 = root.Q<VisualElement>("16BitsIcon");
        personaje = root.Q<VisualElement>("Personaje");
        nombre1.RegisterCallback<ClickEvent>(CambiarIcono);
        nombre2.RegisterCallback<ClickEvent>(CambiarIcono);
    }

    void CambiarIcono(ClickEvent evn)
    {
        VisualElement target = evn.target as VisualElement;
        personaje.style.backgroundImage = target.style.backgroundImage;
    }
}
