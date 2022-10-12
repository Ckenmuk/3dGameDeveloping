using UnityEngine;

public class myGUI : MonoBehaviour
{
    private string _message;
    public GUISkin test;
    private Rect buttonRect;

    public Texture2D _icon;

#if UNITY_EDITOR
    private void OnGUI()
    {
        buttonRect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 70, 200, 140);

        GUI.skin = test;
        //отрисовка панели с текстом
        GUI.Box(buttonRect, "Main menu");

        //отрисовка кнопок с выводом сообщений
        if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 35, 180, 30), "Open"))
            _message = "Open";

        if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 0, 180, 30), "Save"))
            _message = "Save";

        if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 35, 180, 30), "Load"))
            _message = "Load";

        GUI.Label(new Rect(220, 10, 100, 30), _message);

        //угловые панели
        GUI.Box(new Rect(0, 0, 100, 50), "Top-Left");
        GUI.Box(new Rect(Screen.width - 100, 0, 100, 50), "Top-Right");
        GUI.Box(new Rect(0, Screen.height - 50, 100, 50), "Bottom-Left");
        GUI.Box(new Rect(Screen.width - 100, Screen.height - 50, 100, 50), "Bottom-Right");

        //иконка в панели
        GUI.Box(new Rect(10, Screen.height / 2 - 125, 100, 100), _icon);

        //иконка в панели с текстом
        GUI.Box(new Rect(10, Screen.height / 2, 100, 100), new GUIContent("Text", _icon));

        //группа GUI
        GUI.BeginGroup(new Rect(Screen.width / 2 - 25, 10, 200, 200));
        GUI.Label(new Rect(0, 0, 50, 20), "Hello,");
        GUI.Label(new Rect(0, 25, 50, 20), "World!");
        GUI.EndGroup();
    }
#endif
}