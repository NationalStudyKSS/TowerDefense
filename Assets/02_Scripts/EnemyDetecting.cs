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
