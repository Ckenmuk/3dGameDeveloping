using UnityEngine;

public class HPGUI : MonoBehaviour
{
    private Rect rect;
    private GUIStyle style = new GUIStyle();

    public int hp = 100;

    private void Start()
    {
        style.fontSize = 50;
        style.font = (Font)Resources.Load("Bangers-Regular");
        style.normal.textColor = Color.white;
    }

    private void OnGUI()
    {
        rect = new Rect(20, Screen.height - 60, 200, 140);

        GUI.Label(rect, "♥ " + hp.ToString(), style);
    }
}
