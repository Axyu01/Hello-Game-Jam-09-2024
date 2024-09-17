using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    int _currentWave = 0;
    public UnityEvent WaveEndEvent = new UnityEvent();
    public UnityEvent WaveStartEvent = new UnityEvent();
    [Header("Hardness Parameters")]
    [SerializeField]
    float _timePerWave;
    [SerializeField]
    float _startHardness;
    [SerializeField]
    float _hardnessMutliplayer;
    [SerializeField]
    float _hardnessAddition;

    float _currentWaveHardness;
    float _currentWaveUsedHardness;
    float _timeLeft = 0;
    bool _waveEnded = false;

    EnemyWithWaveParameters? _nextEnemy = null;
    float _usedWaveHardness;

    [SerializeField]
    List<EnemyWithWaveParameters> _enemiesWithParameters;
    [SerializeField]
    List<Transform> _spawns;
    void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        StartNextWave();
    }

    void Update()
    {
        UpdateWaveManagementLogic();
        UpdateWaveCycleLogic();
    }
    void UpdateWaveManagementLogic()
    {
        if (_waveEnded == false)
        {
            _timeLeft -= Time.deltaTime;
            if (_timeLeft < 0)
            {
                _timeLeft = 0;
                EndWave();
                _waveEnded = true;
            }
        }
    }
    void UpdateWaveCycleLogic()
    { 
        if(_nextEnemy == null)
        {
            SpawnNextEnemies();
        }
    }
    void SpawnNextEnemies()
    {
        bool continueSpawning = true;
        while (continueSpawning)
        {
            float availableHardnessPoints = _currentWaveHardness * (_timePerWave - _timeLeft)/_timePerWave - _currentWaveUsedHardness;

            List<EnemyWithWaveParameters> availabeEnemiesToSpawn = new List<EnemyWithWaveParameters>();
            foreach (EnemyWithWaveParameters enemy in _enemiesWithParameters)
            {
                if (enemy.hardnessScore < availableHardnessPoints && enemy.waveAppearance <= _currentWave)
                {
                    availabeEnemiesToSpawn.Add(enemy);
                }
            }
            if (availabeEnemiesToSpawn.Count == 0)
            {
                continueSpawning = false;
            }
            else
            {

                EnemyWithWaveParameters randomEnemy = availabeEnemiesToSpawn[Random.Range(0, availabeEnemiesToSpawn.Count)];
                Transform randomSpawn = _spawns[Random.Range(0, _spawns.Count)];
                Instantiate(randomEnemy.EnemyPrefab, randomSpawn.position,Quaternion.identity, transform);
                _currentWaveUsedHardness += randomEnemy.hardnessScore;
            }
        }      
    }
    public void StartNextWave()
    {
        Debug.LogWarning($"Wave {_currentWave} started!");
        _currentWave++;
        _currentWaveUsedHardness = 0f;
        _currentWaveHardness = _startHardness * Mathf.Pow(_hardnessMutliplayer,_currentWave-1) + _hardnessAddition * (_currentWave - 1);
        _timeLeft = _timePerWave;
        WaveStartEvent?.Invoke();
    }
    void EndWave()
    {
        Debug.LogWarning($"Wave {_currentWave} ended!");
        WaveEndEvent?.Invoke();
    }
}
[System.Serializable]
public struct EnemyWithWaveParameters
{
    public GameObject EnemyPrefab;
    public int hardnessScore;
    public int waveAppearance;
}
