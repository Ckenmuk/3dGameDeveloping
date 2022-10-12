using System.Collections;
using UnityEngine;
using UnityEditor;

public class MyGUILayout : MonoBehaviour
{
    private float sliderValue; //значение слайдера


    void OnGUI()
    {
        // кнопки с авто размером и положением
        GUILayout.Button("Automatic Layout Button");

        GUILayout.Button("I am not inside an Area");

        //создаем группу слайдеров в заданном месте и заданным размером
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, 300, 300));
        GUILayout.Button("I am inside an Area"); //кнопка внутри с авто размером и положением

        GUILayout.BeginHorizontal(); // начало строчного хаполнения

        GUILayout.BeginVertical(); // начало столбцового заполнения

        if (GUILayout.RepeatButton("Min"))
            sliderValue = 0.0f;
        if (GUILayout.RepeatButton("Max"))
            sliderValue = 10.0f;


        GUILayout.Button("Overridden Button", GUILayout.Width(120));

        GUILayout.EndVertical(); // конец столбцового заполнения

        GUILayout.BeginVertical(); // начало столбцового заполнения
        GUILayout.Label("Some slider: ");
        sliderValue = GUILayout.HorizontalSlider(sliderValue, 0.0f, 10.0f);
        GUILayout.EndVertical(); // конец столбцового заполнения

        GUILayout.EndHorizontal(); // конец строчного заполнения

        GUILayout.EndArea();

    }

}
