using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Lab4 : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Label estados = root.Q<Label>("TituloEstados");
        Label equipamiento = root.Q<Label>("TituloEquipamiento");
        estados.text = @"<gradient=""dosColores""> ESTADOS </gradient>";
        equipamiento.text = @"<gradient=""dosColores""> EQUIPAMIENTO </gradient>";

        VisualElement vidas = root.Q<VisualElement>("Vidas");

        VisualTreeAsset template = Resources.Load<VisualTreeAsset>("Templates/Vidas");
        vidas.Add(template.Instantiate());
    }
}
