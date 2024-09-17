using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField]
    Player _fightWorldPlayer;
    public Player FightWorldPlayer { get { return _fightWorldPlayer; } }
    [SerializeField]
    Announcer _announcer;
    public Announcer Announcer { get { return _announcer; } }
}
