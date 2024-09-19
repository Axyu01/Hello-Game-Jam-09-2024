using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLeftSlider : MonoBehaviour
{
    public Slider timeSlider;
    public WaveManager waveManager;
    [Header("Color Change parameters")]
    [SerializeField]
    Image _image;
    [SerializeField]
    Gradient _inWaveGradient;
    [SerializeField]
    Gradient _inBetweenWavesGradient;

    private void Start()
    {
        if (waveManager != null && timeSlider != null)
        {
            timeSlider.value = 1f;

            //waveManager.WaveEndEvent.AddListener(HideSlider);
            //waveManager.WaveStartEvent.AddListener(ShowSlider);
        }
    }

    private void Update()
    {
        if (waveManager.WaveEnded)
        {
            timeSlider.value = 1f - waveManager.TimeToStartNextWave / waveManager.TimeBetweenWaves;
            if (_image != null)
            {
                _image.color = _inBetweenWavesGradient.Evaluate(1f - waveManager.TimeToStartNextWave / waveManager.TimeBetweenWaves);
            }
        }
        else
        {
            timeSlider.value = waveManager.TimeLeft / waveManager.TimePerWave;
            if (_image != null)
            {
                _image.color = _inWaveGradient.Evaluate(1f - waveManager.TimeLeft / waveManager.TimePerWave);
            }
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
