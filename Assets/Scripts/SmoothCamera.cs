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

    // Update is called once per frame
    void LateUpdate()
    {
        if(_worldSwitcher.IS_ChillWorldActive)
        {
            Follow(_chillWorldTarget.transform, Time.deltaTime);
        }
        else
        {
            Follow(_fightWorldTarget.transform, Time.deltaTime);
        }
    }
    void Follow(Transform followedTransform,float change)
    {
        _camera.transform.parent = followedTransform;
        _camera.transform.localPosition = Vector3.Lerp(_camera.transform.localPosition,Vector3.forward *_camera.transform.localPosition.z,change * _speed);
    }
}
