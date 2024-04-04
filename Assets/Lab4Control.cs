using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Lab4Control : VisualElement
{
    List<VisualElement> vidas = new List<VisualElement>();

    int estado;

    public int Estado
    {
        get => estado;
        set
        {
            estado = value;
            Fade();
        }
    }

    void Fade()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < Estado)
            {
                
                vidas[i].style.opacity = 1f;
            }
            else
            {
                vidas[i].style.opacity = 0.5f;
            }
        }
    }

    public Lab4Control()
    {
        for (int i = 0; i < 5; i++)
        {
            VisualElement v = new VisualElement();
            v.style.width = 75;
            v.style.height = 75;
            v.style.backgroundImage = Resources.Load<Texture2D>("Images/corazon-rojo_511393-683-removebg-preview");
            styleSheets.Add(Resources.Load<StyleSheet>("Templates/Vidas"));
            v.AddToClassList("Vidas");
            hierarchy.Add(v);
            vidas.Add(v);
        }
    }
    public new class UxmlFactory : UxmlFactory<Lab4Control, UxmlTraits> { };

    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlIntAttributeDescription myVidas = new UxmlIntAttributeDescription { name = "vidas", defaultValue = 3 };

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            var semaforo = ve as Lab4Control;
            semaforo.Estado = myVidas.GetValueFromBag(bag, cc);
        }
    }
}
