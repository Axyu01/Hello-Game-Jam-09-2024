using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLeftSlider : MonoBehaviour
{
    public Slider timeSlider;
    public WaveManager waveManager;

    private void Start()
    {
        if (waveManager != null && timeSlider != null)
        {
            timeSlider.maxValue = waveManager.TimePerWave;
            timeSlider.value = waveManager.TimePerWave;

            waveManager.WaveEndEvent.AddListener(HideSlider);
            waveManager.WaveStartEvent.AddListener(ShowSlider);
        }
    }

    private void Update()
    {
        if (waveManager != null && timeSlider != null)
        {
            timeSlider.value = waveManager.TimeLeft;
        }
    }

    void HideSlider()
    {
        timeSlider.gameObject.SetActive(false);
    }

    void ShowSlider()
    {
        timeSlider.gameObject.SetActive(true);
        timeSlider.value = waveManager.TimePerWave;
    }

    private void OnDestroy()
    {
        if (waveManager != null)
        {
            waveManager.WaveEndEvent.RemoveListener(HideSlider);
            waveManager.WaveStartEvent.RemoveListener(ShowSlider);
        }
    }
}
