using UnityEngine;
using UnityEditor;

public class Window : EditorWindow
{
    public Color myColor; // �������� �����
    public MeshRenderer GO; // ������ �� ������ �������

    public Material newMaterial;
    private Transform mainCamera;

    [SerializeField] private float minValue = .1f;

    [MenuItem("Instruments / Windows / Prefab Generator")]
    public static void ShowMyWindow()
    {
        GetWindow(typeof(Window), false, "Prefab Generator");
    }


    void OnGUI()
    {
        GO = EditorGUILayout.ObjectField("Mesh", GO, typeof(MeshRenderer), true) as MeshRenderer;
        newMaterial = EditorGUILayout.ObjectField("Material", newMaterial, typeof(Material), true) as Material;
        if (GO)
        {
            myColor = RGBSlider(new Rect(150, 50, 200, 20), myColor); // ��������� ����������������� ������ ���������
            GO.sharedMaterial.color = myColor; //�������� �������
        }
        else
        {
            if(GUI.Button(new Rect(10, 60, 100, 30), "Create Object"))
            {
                mainCamera = Camera.main.transform;

                GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
                MeshRenderer GORenderer = temp.GetComponent<MeshRenderer>();
                GORenderer.sharedMaterial = newMaterial;
                temp.transform.position = new Vector3(mainCamera.position.x, mainCamera.position.y, mainCamera.position.z - 10f);

                GO = GORenderer;
            }
        }

        if (GUI.Button(new Rect(10, 160, 100, 30), "Delete"))
        {
            DestroyImmediate(GO.gameObject);
            GO = null;
        }


    }

    float LabelSlider(Rect screenRect, float sliderValue, float sliderMinValue, float sliderMaxValue, string labelText) // �������� MinValue
    {
        //������� ������������� � ������������ � ������������ � �������� ������� � �������
        Rect labelRect = new Rect(screenRect.x, screenRect.y, screenRect.width / 2, screenRect.height);

        GUI.Label(labelRect, labelText); //������� Label �� ������

        Rect sliderRect = new Rect(screenRect.x + screenRect.width / 2, screenRect.y, screenRect.width / 2, screenRect.height);
        sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, sliderMinValue, sliderMaxValue);
        return sliderValue; //���������� �������� ��������
    }

    // �������� ������� ������� ������, ������ ������� �������� �� ���� ����
    Color RGBSlider(Rect screenRect, Color rgb)
    {
        // ��������� ���������������� �������, ������� ���
        rgb.r = LabelSlider(screenRect, rgb.r, minValue, 1.0f, "Red");
        screenRect.y += 20; //���������� ����� ����������

        rgb.g = LabelSlider(screenRect, rgb.g, minValue, 1.0f, "Green");
        screenRect.y += 20;

        rgb.b = LabelSlider(screenRect, rgb.b, minValue, 1.0f, "Blue");
        screenRect.y += 20;

        rgb.a = LabelSlider(screenRect, rgb.a, minValue, 1.0f, "alpha");

        return rgb;
    }

}
