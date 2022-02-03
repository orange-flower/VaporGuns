using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderMove : MonoBehaviour, IMoveHandler, IEndDragHandler
{
    public float step = 1;            // the desired step
    Slider slider;
    float previousSliderValue = 0;

    void Awake()
    {
        slider = GetComponent<Slider>();
        if (slider)
            previousSliderValue = slider.value;
    }

    public void OnMove(AxisEventData eventData)
    {
        // override the slider value using our previousSliderValue and the desired step
        if (Input.GetKeyDown(key: KeyCode.A))
        {
            slider.value = previousSliderValue - step;
        }

        if (Input.GetKeyDown(key: KeyCode.D))
        {
            slider.value = previousSliderValue + step;
        }

        // keep the slider value for future use
        previousSliderValue = slider.value;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // keep the last slider value if the slider was dragged by mouse
        previousSliderValue = slider.value;
    }

    public void Update()
    {
        // override the slider value using our previousSliderValue and the desired step
        if (Input.GetKeyDown(key: KeyCode.A))
        {
            slider.value = previousSliderValue - step;
        }

        if (Input.GetKeyDown(key: KeyCode.D))
        {
            slider.value = previousSliderValue + step;
        }

        // keep the slider value for future use
        previousSliderValue = slider.value;
    }
}
