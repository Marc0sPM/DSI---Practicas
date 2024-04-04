using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Lab3 : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        VisualElement personaje = root.Q("PanelCentral").ElementAt(0);
        VisualElement arma = root.Q("ArmaIcono");
        VisualElement escudo = root.Q("EscudoIcono");
        VisualElement armadura = root.Q("ArmaduraIcono");
        VisualElement botas = root.Q("BotasIcono");

        personaje.AddManipulator(new Lab3Resizer());
        arma.AddManipulator(new Lab3Manipulator());
        escudo.AddManipulator(new Lab3Manipulator());
        armadura.AddManipulator(new Lab3Manipulator());
        botas.AddManipulator(new Lab3Manipulator());
    }
}
