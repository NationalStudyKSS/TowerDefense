using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetecting : MonoBehaviour
{
    public List<GameObject> _enemies;
    [SerializeField] TowerController _towerController;

    private void Start()
    {
        _towerController = transform.parent.GetComponent<TowerController>();
    }

    private void Update()
    {
        for (int i = _enemies.Count - 1; i >= 0; i--)
        {
            if (_enemies[i] == null)
            {
                _enemies.RemoveAt(i);
            }
            else
            {
                // 혹시 죽음 상태 체크 필요하면 여기서 추가
                EnemyController enemy = _enemies[i].GetComponent<EnemyController>();
                if (enemy != null && enemy.isDead)
                {
                    _enemies.RemoveAt(i);
                }
            }
        }
        if (_towerController._targetEnemy == null && _enemies.Count > 0)
        {
            _towerController._targetEnemy = _enemies[0];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (!_enemies.Contains(other.gameObject))
            {
                _enemies.Add(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _enemies.Remove(other.gameObject);
        }
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetecting : MonoBehaviour
{
    public List<GameObject> _enemies;
    [SerializeField] TowerController _towerController;

    private void Start()
    {
        _towerController = transform.parent.GetComponent<TowerController>();
    }

    private void Update()
    {
        if (_enemies.Count > 0 && _enemies[0] == null)
        {
            _enemies.RemoveAt(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _towerController._targetEnemy = other.gameObject;
            _enemies.Add(other.gameObject);
            _towerController._towerState = TowerController.TOWERSTATE.ATTACK;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _enemies.Remove(other.gameObject);
        }
    }
}

 */