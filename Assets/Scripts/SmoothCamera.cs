using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    [Header("references")]
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    WorldSwitcher _worldSwitcher;
    [SerializeField]
    GameObject _chillWorldTarget;
    [SerializeField]
    GameObject _fightWorldTarget;
    [Header("parameters")]
    [SerializeField]
    float _speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_worldSwitcher.IS_ChillWorldActive)
        {
            Follow(_chillWorldTarget.transform.position, Time.deltaTime);
        }
        else
        {
            Follow(_fightWorldTarget.transform.position, Time.deltaTime);
        }
    }
    void Follow(Vector2 point,float change)
    {
        _camera.transform.position = Vector3.Lerp(_camera.transform.position,(Vector3)point + Vector3.forward * _camera.transform.position.z,change * _speed);
    }
}
