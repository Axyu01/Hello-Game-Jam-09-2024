using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField]
    Player _fightWorldPlayer;
    public Player FightWorldPlayer { get { return _fightWorldPlayer; } }
}
