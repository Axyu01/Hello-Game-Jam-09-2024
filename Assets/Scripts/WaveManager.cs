using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    const float SMALL_NUMBER = 0.01f;
    int _currentWave = 0;
    public UnityEvent WaveEndEvent = new UnityEvent();
    public UnityEvent WaveStartEvent = new UnityEvent();
    [Header("Hardness Parameters")]
    [SerializeField]
    float _timePerWave;
    public float TimePerWave { get { return _timePerWave; }}
    [SerializeField]
    float _startHardness;
    [SerializeField]
    float _hardnessMutliplayer;
    [SerializeField]
    float _hardnessAddition;

    float _currentWaveHardness;
    float _currentWaveUsedHardness;
    float _timeLeft = 0;
    public float TimeLeft { get { return _timeLeft; } }
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
        UpdateWaveCycleLogic();
        UpdateWaveManagementLogic();
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
        SpawnNextEnemies();
    }
    void SpawnNextEnemies()
    {
        bool continueSpawning = true;
        while (continueSpawning)
        {
            float availableHardnessPoints = _currentWaveHardness * (_timePerWave - _timeLeft) / _timePerWave - _currentWaveUsedHardness + SMALL_NUMBER;

            if (_nextEnemy != null && availableHardnessPoints > ((EnemyWithWaveParameters)_nextEnemy).HardnessScore)
            {
                EnemyWithWaveParameters enemy = (EnemyWithWaveParameters)_nextEnemy;
                SpawnEnemyOnRandomSpawn(enemy);
            }

            List <EnemyWithWaveParameters> availabeEnemiesToSpawn = new List<EnemyWithWaveParameters>();
            foreach (EnemyWithWaveParameters enemy in _enemiesWithParameters)
            {
                if (enemy.WaveAppearance <= _currentWave)
                {
                    availabeEnemiesToSpawn.Add(enemy);
                }
            }

            int probabilityScoreSum = 0;
            foreach (EnemyWithWaveParameters enemy in availabeEnemiesToSpawn)
            {
                probabilityScoreSum += enemy.ProbabilityScore;
            }

            //Used to choose random Enemy by probability score
            int randomScoreChoice = Random.Range(0, probabilityScoreSum);

            int probabilityScoreCelling = 0;
            foreach (EnemyWithWaveParameters enemy in availabeEnemiesToSpawn)
            {
                probabilityScoreCelling += enemy.ProbabilityScore;
                if(probabilityScoreCelling > randomScoreChoice)
                {
                    _nextEnemy = enemy;
                    break;
                }
            }
            if (availabeEnemiesToSpawn.Count == 0)
            {
                continueSpawning = false;
                continue;
            }

            if (_nextEnemy != null && availableHardnessPoints > ((EnemyWithWaveParameters)_nextEnemy).HardnessScore)
            {
                EnemyWithWaveParameters randomEnemy = ((EnemyWithWaveParameters)_nextEnemy);
                SpawnEnemyOnRandomSpawn(randomEnemy);
            }
            else
            {
                continueSpawning = false;
                continue;
            }
        }      
    }
    void SpawnEnemyOnRandomSpawn(EnemyWithWaveParameters enemy)
    {
        Transform randomSpawn = _spawns[Random.Range(0, _spawns.Count)];
        Instantiate(enemy.EnemyPrefab, randomSpawn.position, Quaternion.identity, transform);
        _currentWaveUsedHardness += enemy.HardnessScore;
        _nextEnemy = null;
    }

    public void StartNextWave()
    {
        _waveEnded = false;
        _currentWave++;
        Debug.LogWarning($"Wave {_currentWave} started!");
        GameManager.Instance.Announcer.Announce($"Wave {_currentWave} started!");
        _currentWaveUsedHardness = 0f;
        _currentWaveHardness = _startHardness * Mathf.Pow(_hardnessMutliplayer,_currentWave-1) + _hardnessAddition * (_currentWave - 1);
        Debug.Log("Wave Hardness:" + _currentWaveHardness);
        _timeLeft = _timePerWave;
        WaveStartEvent?.Invoke();
    }
    void EndWave()
    {
        Debug.LogWarning($"Wave {_currentWave} ended!");
        GameManager.Instance.Announcer.Announce($"Wave {_currentWave} ended!");
        WaveEndEvent?.Invoke();
    }
}
[System.Serializable]
public struct EnemyWithWaveParameters
{
    public GameObject EnemyPrefab;
    public int HardnessScore;
    public int WaveAppearance;
    public int ProbabilityScore;
}
