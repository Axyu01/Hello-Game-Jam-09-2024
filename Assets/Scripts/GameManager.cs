using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public UnityEvent OnGameEnd = new UnityEvent();
    [SerializeField]
    public int Coins = 100;

    [SerializeField]
    Player _chillWorldPlayer;
    public Player ChillWorldPlayer { get { return _chillWorldPlayer; } }
    [SerializeField]
    Player _fightWorldPlayer;
    [SerializeField]
    GameObject _chillWorld;
    public GameObject ChillWorld { get { return _chillWorld; } }
    [SerializeField]
    GameObject _fightWorld;
    public GameObject FightWorld { get { return _fightWorld; } }
    public Player FightWorldPlayer { get { return _fightWorldPlayer; } }
    [SerializeField]
    Announcer _announcer;
    public Announcer Announcer { get { return _announcer; } }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void EndGame()
    {
        OnGameEnd?.Invoke();
    }
    protected override void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (_instance != this)
        {
            //Destroy(gameObject);
            Destroy(_instance.gameObject);
            _instance = this;
        }
    }
}
