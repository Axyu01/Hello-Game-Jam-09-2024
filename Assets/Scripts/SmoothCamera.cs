using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    [Header("references")]
    [SerializeField]
    private Camera _camera;
    [Header("parameters")]
    [SerializeField]
    float _speed = 3f;
    [Header("folllow player vs cursor")]
    [SerializeField, Range(0f, 1f)]
    float _cursorFollowPercentage = 0.3f;


    Quaternion _startRotation;
    private void Start()
    {
        _startRotation = transform.rotation;
    }
    void Update()
    {
        if(WorldSwitcher.IsChillWorldActive)
        {
            Follow(GameManager.Instance.ChillWorldPlayer.transform, Time.deltaTime);
        }
        else
        {
            Follow(GameManager.Instance.FightWorldPlayer.transform, Time.deltaTime);
        }
    }
    void Follow(Transform followedTransform,float change)
    {
        //_camera.transform.parent = followedTransform;
        _camera.transform.localPosition = Vector3.Lerp(_camera.transform.position,(Vector3)FollowedPosition(followedTransform) + Vector3.forward *_camera.transform.localPosition.z,change * _speed);
        //_camera.transform.rotation = _startRotation;
    }
    Vector2 FollowedPosition(Transform followedTransform)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 target = followedTransform.position;
        return Vector2.Lerp(target,mousePosition,_cursorFollowPercentage);
    }
}
