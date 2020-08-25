using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private Image[] images;
    private Text text;
	
    private void Start()
    {
        slider.enabled = false;

        images = slider.GetComponentsInChildren<Image>();
        text = slider.GetComponentInChildren<Text>();

        text.enabled = false;
        for (int i = 0; i < images.Length; i++)
        {
            images[i].enabled = false;
        }
    }

    public void SetSliderValue(float value)
    {
        
        if (value < slider.minValue)
            return;
        if (value > slider.maxValue)
            return;

        text.enabled = true;
        for (int i = 0; i < images.Length; i++)
        {
            images[i].enabled = true;
        }

        text.text = (((int)value).ToString() + "%");
        slider.value = value;
    }
}
