using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
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
}
