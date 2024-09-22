using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreenViewer : MonoBehaviour
{
    [SerializeField]
    GameObject _endScreen;
    [SerializeField]
    Button _replayButton;
    [SerializeField]
    Button _exitButton;
    void Start()
    {
        GameManager.Instance.OnGameEnd.AddListener(() => { Cursor.visible = true; _endScreen.SetActive(true); });
        _replayButton.onClick.AddListener(() => { SceneManager.LoadScene(gameObject.scene.name); });
        _exitButton.onClick.AddListener(() => { SceneManager.LoadScene(0); });
    }
}
