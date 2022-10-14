using UnityEngine;

public class MyAdvancedGUI : MonoBehaviour
{
    [SerializeField]
    [Header("���������� ����������")]
    [Range(0, 100)]
    [Tooltip("�������� ��������� � ��������� �� 0 �� 100")]
    private float _float = 1.0f; // ��������� ����������������� ��������
    [SerializeField][TextArea(5, 6)] private string _text;
    [SerializeField] private float minValue = .1f;

    public Color myColor; // �������� �����
    public MeshRenderer GO; // ������ �� ������ �������

    void OnGUI()
    {
        _float = LabelSlider(new Rect(10, 10, 200, 20), _float, minValue, 5.0f, "My Slider"); // ��������� ����������������� ��������
        myColor = RGBSlider(new Rect(10, 30, 200, 20), myColor); // ��������� ����������������� ������ ���������
        GO.material.color = myColor; //�������� �������
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

