using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Lab2 : MonoBehaviour
{
    public static Lab4Control vidas;
    public static Slider vidasSlider;

    private void OnEnable()
    {
        UIDocument document = GetComponent<UIDocument>();
        VisualElement rootve = document.rootVisualElement;
        UQueryBuilder<VisualElement> builder = new(rootve);

        VisualElement mslider = rootve.Q<Slider>("Slider");
        Color color = new Color(0, 0, 0, 0.4f);
        mslider.style.backgroundColor = color;

        VisualElement mdragger = rootve.Q<VisualElement>("unity-dragger");
        mdragger.style.backgroundColor = Color.red;

        VisualElement mtracker = rootve.Q<VisualElement>("unity-tracker");
        mtracker.style.backgroundColor = Color.yellow;

        VisualElement menu = rootve.Q<VisualElement>("Menu");
        menu.AddToClassList("Menu");

        vidasSlider = rootve.Q<Slider>("Slider");
        vidasSlider.RegisterCallback<ChangeEvent<float>>(OnChange);
    }

    void OnChange(ChangeEvent<float> evt)
    {
        Slider target = evt.target as Slider;
        if(vidas != null)
            vidas.Estado = (int)target.value;
    }
}
