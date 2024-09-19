using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSwitcher : MonoBehaviour
{
    [SerializeField]
    KeyCode _switchKey = KeyCode.Space;
    [SerializeField]
    GameObject _chillWorld;
    static GameObject _chillWorldGlobal;
    [SerializeField]
    GameObject _actionWorld;
    static GameObject _actionWorldGlobal;

    static bool _isChillWorldActive = false;
    public static bool IsChillWorldActive { get { return _isChillWorldActive; } }
    bool _canSwitch = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateWorlds();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(_switchKey) && _canSwitch)
        {
            _isChillWorldActive = !_isChillWorldActive;
            UpdateWorlds();
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
