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
    GameObject _crosshairImage;

    [SerializeField]
    bool _isChillWorldActive = false;
    public bool IS_ChillWorldActive { get { return _isChillWorldActive; } }
    bool _isChillWorldActiveLastValue = false;
    bool _canSwitch = false;

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
        if(Input.GetKeyDown(_switchKey) && _canSwitch)
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

            Cursor.visible = true;
            _crosshairImage.SetActive(false);
        }
        else
        {
            _chillWorld.SetActive(false);
            _actionWorld.SetActive(true);

            Cursor.visible = false;
            _crosshairImage.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent(out Player p))
        {
            _canSwitch = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player p))
        {
            _canSwitch = false;
        }
    }
}
