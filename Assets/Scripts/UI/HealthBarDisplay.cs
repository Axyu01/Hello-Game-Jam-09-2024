using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarDisplay : MonoBehaviour
{
    Vector3 _parentGlobalOffset;
    [SerializeField]
    Slider _slider;
    [SerializeField]
    EntityBase _entity;
    private void Start()
    {
        _parentGlobalOffset = transform.position - transform.parent.position;
    }
    void Update()
    {
        transform.position = transform.parent.position + _parentGlobalOffset;
        transform.rotation = Quaternion.identity;
        _slider.value = _entity.Health/_entity.MaxHealth;
    }
}
