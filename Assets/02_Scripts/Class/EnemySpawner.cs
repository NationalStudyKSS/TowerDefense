using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;

    [SerializeField] float _spawnTimer;
    [SerializeField] float _spawnSpan;

    [SerializeField] int _enemyCount;
    [SerializeField] int _enemyMaxCount;

    [SerializeField] bool _isRunning;

    GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _isRunning = true;
    }

    private void Update()
    {
        if (_enemyCount >= _enemyMaxCount)
        {
            _isRunning = false;
        }

        if (_isRunning == true)
        {
            _spawnTimer += Time.deltaTime;
            if (_spawnTimer > _spawnSpan)
            {
                _spawnTimer = 0;
                GameObject enemy = Instantiate(_enemyPrefab, transform.position, transform.rotation);
                enemy.name = "Enemy_" + _enemyCount;
                enemy.GetComponent<EnemyController>()._enemyHp = _gameManager.CurrentEnemyHp;
                enemy.GetComponent<EnemyController>()._moveSpeed = _gameManager.CurrentEnemySpeed;
                _enemyMaxCount = _gameManager.EnemyCountByStage;
                _enemyCount++;
            }
        }
    }

    public void InitEnemySpawner()
    {
        if (_enemyCount < _enemyMaxCount) return;
        _enemyCount = 0;
        _isRunning = true;
        _gameManager._currentLevel++;
        _gameManager.StageUp();
    }
}
