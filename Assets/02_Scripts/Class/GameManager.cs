using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int _currentLevel = 1;
    [SerializeField] int _currentEnemyHp = 100;
    [SerializeField] float _currentEnemySpeed = 1f;
    [SerializeField] int _enemyCountByStage = 2;
    public int _killCount = 0;
    
    public int CurrentEnemyHp => _currentEnemyHp;
    public float CurrentEnemySpeed => _currentEnemySpeed;
    public int EnemyCountByStage => _enemyCountByStage;

    public void StageUp()
    {
        _currentEnemyHp *= 2;
        _currentEnemySpeed *= 1.1f;
        _enemyCountByStage *= 2;
    }
}
