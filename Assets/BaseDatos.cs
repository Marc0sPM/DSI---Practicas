using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UIElements;
using System.IO;
using UnityEditor;

public class BaseDatos
{
    public string data = "Images/580b57fcd9996e24bc43c351";

    public int vidas = 2;

    string path = "Assets/Resources/save.json";

    public StyleBackground getData()
    {
        StreamReader reader = new StreamReader(path);
        if(reader == null)
            return new StyleBackground(Resources.Load<Sprite>(data));
        this.data = reader.ReadToEnd();
        BaseDatos jsonToBackground = JsonUtility.FromJson<BaseDatos>(this.data);
        this.data = jsonToBackground.data;
        reader.Close();
        this.vidas = jsonToBackground.vidas;
        Lab2.vidasSlider.value = this.vidas;
        return new StyleBackground(AssetDatabase.LoadAssetAtPath<Sprite>(this.data));
    }

    public void saveData(string data)
    {
        this.data = data;
        this.vidas = (int)Lab2.vidasSlider.value;
        StreamWriter writer = new StreamWriter(path);
        string jsonImage = JsonUtility.ToJson(this);
        writer.Write(jsonImage);
        writer.Close();
    }
}
