using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarDisplay : MonoBehaviour
{
    [SerializeField]
    Slider _slider;
    [SerializeField]
    EntityBase _entity;
    // Update is called once per frame
    void Update()
    {
        _slider.value = _entity.Health/_entity.MaxHealth;
    }
}
