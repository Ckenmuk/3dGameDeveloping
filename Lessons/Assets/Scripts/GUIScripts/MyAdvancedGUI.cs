using UnityEngine;

public class MyAdvancedGUI : MonoBehaviour
{
    [SerializeField]
    [Header("Отладочная переменная")]
    [Range(0, 100)]
    [Tooltip("Значение находится в диапазоне от 0 до 100")]
    private float _float = 1.0f; // положение пользовательского слайдера
    [SerializeField][TextArea(5, 6)] private string _text;
    [SerializeField] private int _int = 1;

    public Color myColor; // градиент цвета
    public MeshRenderer GO; // ссылка на рендер объекта

    void OnGUI()
    {
        _float = LabelSlider(new Rect(10, 10, 200, 20), _float, 5.0f, "My Slider"); // отрисовка пользовательского слайдера
        myColor = RGBSlider(new Rect(10, 30, 200, 20), myColor); // отрисовка пользовательского набора слайдеров
        GO.material.color = myColor; //покраска объекта
    }

    float LabelSlider(Rect screenRect, float sliderValue, float sliderMaxValue, string labelText) // добавить MinValue
    {
        //создаем прямоугольник с координатами в пространстве и заданной шириной и высотой
        Rect labelRect = new Rect(screenRect.x, screenRect.y, screenRect.width / 2, screenRect.height);

        GUI.Label(labelRect, labelText); //создаем Label на экране

        Rect sliderRect = new Rect(screenRect.x + screenRect.width / 2, screenRect.y, screenRect.width / 2, screenRect.height);
        sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, sliderMaxValue, sliderMaxValue);
        return sliderValue; //возвращаем значение слайдера
    }

    // отриовка тройной слайдер группы, каждый слайдер отвечает за свой цвет
    Color RGBSlider(Rect screenRect, Color rgb)
    {
        // используя пользовательский слайдер, создаем его
        rgb.r = LabelSlider(screenRect, rgb.r, 1.0f, "Red");
        screenRect.y += 20; //промежуток между слайдерами

        rgb.g = LabelSlider(screenRect, rgb.g, 1.0f, "Green");
        screenRect.y += 20;

        rgb.b = LabelSlider(screenRect, rgb.b, 1.0f, "Blue");
        screenRect.y += 20;

        rgb.a = LabelSlider(screenRect, rgb.a, 1.0f, "alpha");

        return rgb;
    }


}

