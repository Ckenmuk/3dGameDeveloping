using System.Collections;
using UnityEngine;

public class MyIMGUI : MonoBehaviour
{
    //переменные хранения текста полей
    private string[] textMass = { "Hello, World", "Hello, World" };

    //переключатель
    private bool toggleBool = true;

    //выбранный тулбар, имена тулбаров
    private int toolbarInt = 0;
    private string[] toolbarStrings = { "Toolbar1", "Toolbar2", "Toolbar3" };

    //многострочный тулбар, имена тулбаров
    private int selectionGridInt = 0;
    private string[] selectionStrings = { "Grid 1", "Grid 2", "Grid 3", "Grid 4" };

    //значения горизонтального и вертикального слайдеров
    private float hSliderValue = 0.0f;
    private float vSliderValue = 0.0f;

    //значения горизонтального и вертикального скроллеров
    private float hScrollbarValue = 0.0f;
    private float vScrollbarVallue = 0.0f;

    //размер скроллящегося окна и его содержимое
    private Vector2 scrollViewVector = Vector2.zero;
    private string innerText = "I am inside the ScrollView";

    //отрисовка окошка
    private Rect windowRect = new Rect(Screen.width / 2 - 90, Screen.height / 2 - 100, 180, 175);

    //выбранный тулбар
    private int selectedToolbar = 0;

    void OnGUI()
    {
        //пока нажата, выводит какое-то
        if (GUI.RepeatButton(new Rect(25, 20, 100, 30), "RepeatButton"))
            print("Button pressed right now");

        //записывание в массив и отрисовка текста
        textMass[0] = GUI.TextField(new Rect(25, 55, 100, 30), textMass[0]);
        textMass[1] = GUI.TextArea(new Rect(25, 90, 100, 30), textMass[1]);

        //записывание и отрисовка переключателя
        toggleBool = GUI.Toggle(new Rect(25, 150, 100, 30), toggleBool, "Toggle");

        //отрисовка и запись тулбара и многострочного тулбара
        toolbarInt = GUI.Toolbar(new Rect(150, 25, 250, 30), toolbarInt, toolbarStrings);
        selectionGridInt = GUI.SelectionGrid(new Rect(550, 25, 300, 60), selectionGridInt, selectionStrings, 2);

        //отрисовка и запись вертикального и горизонтального слайдеров
        hSliderValue = GUI.HorizontalSlider(new Rect(25, 190, 100, 30), hSliderValue, 0.0f, 10.0f);
        vSliderValue = GUI.VerticalSlider(new Rect(130, 190, 100, 30), vSliderValue, 10.0f, 0.0f);

        //отрисовка и запись вертикального и горизонтального сроллеров


        //отрисовка и запись скроллвью
        scrollViewVector = GUI.BeginScrollView(new Rect(25, 300, 100, 100), scrollViewVector, new Rect(0, 0, 400, 400));
        hScrollbarValue = GUI.HorizontalScrollbar(new Rect(25, 250, 100, 30), hScrollbarValue, 1.0f, 0.0f, 10.0f);
        vScrollbarVallue = GUI.VerticalScrollbar(new Rect(130, 250, 100, 30), vScrollbarVallue, 1.0f, 10.0f, 0.0f);
        innerText = GUI.TextArea(new Rect(0, 0, 400, 400), innerText);
        GUI.EndScrollView();

        windowRect = GUI.Window(0, windowRect, WindowFunction, "Pause");

        //отрисовка и запись выбранного тулбара с обратной связью
        selectedToolbar = GUI.Toolbar(new Rect(550, 300, 200, 30), selectedToolbar, toolbarStrings);

        //вывод сообщений
        if (GUI.changed)
        {
            Debug.Log("GUI was changed");

            if (selectedToolbar == 0)
                Debug.Log("First button was active");
            else if (selectedToolbar == 1)
                Debug.Log("Second button was active");
            else if (selectedToolbar == 2)
                Debug.Log("Third button was active");
        }
    }


    //отрисовка панели с кнопками и выводом сообщений
    void WindowFunction(int windowID)
    {
        if (GUI.Button(new Rect(windowRect.width / 2 - 80, 30, 160, 30), "Continue"))
            print("Continue");
        if (GUI.Button(new Rect(windowRect.width / 2 - 80, 65, 160, 30), "Restart"))
            print("Restart");
        if (GUI.Button(new Rect(windowRect.width / 2 - 80, 100, 160, 30), "Settings"))
            print("Settings");
        if (GUI.Button(new Rect(windowRect.width / 2 - 80, 135, 160, 30), "Exit"))
            print("Exit");
    }
}
