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
    VisualElement nombre3;
    VisualElement nombre4;
    VisualElement saveButton;

    BaseDatos baseDatos = new BaseDatos();

    Expositor personaje;
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        saveButton = root.Q<VisualElement>("SaveButton");

        nombre1 = root.Q<VisualElement>("MarioIcon");
        Sprite sprite = Resources.Load<Sprite>("Images/1ceed098558380f5c4739bb878bd7bce");
        nombre1.style.backgroundImage = new StyleBackground(sprite);

        nombre2 = root.Q<VisualElement>("PacmanIcon");
        sprite = Resources.Load<Sprite>("Images/580b57fcd9996e24bc43c351");
        nombre2.style.backgroundImage = new StyleBackground(sprite); 
        
        nombre3 = root.Q<VisualElement>("FoxIcon");
        sprite = Resources.Load<Sprite>("Images/84364ea4123d7fba8329624698643f8c-removebg-preview");
        nombre3.style.backgroundImage = new StyleBackground(sprite); 
        
        nombre4 = root.Q<VisualElement>("KirbyIcon");
        sprite = Resources.Load<Sprite>("Images/Kirby_KSSU-removebg-preview");
        nombre4.style.backgroundImage = new StyleBackground(sprite);

        personaje = new Expositor(root.Q<VisualElement>("Personaje"));
        personaje.Imagen.style.backgroundImage = baseDatos.getData();

        saveButton.RegisterCallback<ClickEvent>(GuardarIcono);
        nombre1.RegisterCallback<ClickEvent>(CambiarIcono);
        nombre2.RegisterCallback<ClickEvent>(CambiarIcono);
        nombre3.RegisterCallback<ClickEvent>(CambiarIcono);
        nombre4.RegisterCallback<ClickEvent>(CambiarIcono);

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
