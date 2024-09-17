using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider timeSlider;
    public WaveManager waveManager;

    private void Start()
    {
        if (waveManager != null && timeSlider != null)
        {
            timeSlider.maxValue = waveManager.TimePerWave;
            timeSlider.value = waveManager.TimePerWave;
        }
    }

    private void Update()
    {
        if (waveManager != null && timeSlider != null)
        {
            timeSlider.value = waveManager.TimeLeft;
        }
    }
}
