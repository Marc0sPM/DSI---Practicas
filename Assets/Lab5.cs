using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

public class Lab5 : MonoBehaviour
{
    VisualElement nombre1;
    VisualElement nombre2;
    VisualElement saveButton;

    BaseDatos baseDatos = new BaseDatos();

    Expositor personaje;
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        saveButton = root.Q<VisualElement>("SaveButton");

        nombre1 = root.Q<VisualElement>("3DIcon");
        Sprite sprite = Resources.Load<Sprite>("Images/580b57fcd9996e24bc43c351");
        nombre1.style.backgroundImage = new StyleBackground(sprite);

        nombre2 = root.Q<VisualElement>("16BitsIcon");
        sprite = Resources.Load<Sprite>("Images/descarga-Photoroom.png-Photoroom");
        nombre2.style.backgroundImage = new StyleBackground(sprite);

        personaje = new Expositor(root.Q<VisualElement>("Personaje"));
        personaje.Imagen.style.backgroundImage = baseDatos.getData();

        saveButton.RegisterCallback<ClickEvent>(GuardarIcono);
        nombre1.RegisterCallback<ClickEvent>(CambiarIcono);
        nombre2.RegisterCallback<ClickEvent>(CambiarIcono);

    }

    void CambiarIcono(ClickEvent evn)
    {
        VisualElement target = evn.target as VisualElement;
        personaje.Imagen.style.backgroundImage = target.style.backgroundImage;
    }

    void GuardarIcono(ClickEvent evn)
    {
        baseDatos.saveData(AssetDatabase.GetAssetPath(personaje.Imagen.style.backgroundImage.value.sprite));
    }
}
