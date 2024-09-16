using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField]
    PlayerController _player;
    PlayerController Player { get { return _player; } }
}
