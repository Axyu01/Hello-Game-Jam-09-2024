using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSwitcher : MonoBehaviour
{
    [SerializeField]
    KeyCode _switchKey = KeyCode.Space;
    [SerializeField]
    GameObject _chillWorld;
    [SerializeField]
    GameObject _actionWorld;

    [SerializeField]
    bool _isChillWorldActive = false;
    bool _isChillWorldActiveLastValue = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateWorlds();
    }

    // Update is called once per frame
    void Update()
    {
        if(_isChillWorldActive != _isChillWorldActiveLastValue)
        {
            UpdateWorlds();
            _isChillWorldActiveLastValue = _isChillWorldActive;
        }
        if(Input.GetKeyDown(_switchKey))
        {
            _isChillWorldActive = !_isChillWorldActive;
            UpdateWorlds();
            _isChillWorldActiveLastValue = _isChillWorldActive;
        }
    }
    void UpdateWorlds()
    {
        if(_isChillWorldActive)
        {
            _chillWorld.SetActive(true);
            _actionWorld.SetActive(false);
        }
        else
        {
            _chillWorld.SetActive(false);
            _actionWorld.SetActive(true);
        }
    }
}
