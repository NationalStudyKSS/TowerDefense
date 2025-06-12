using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] int _attackPower;
    
    [SerializeField] float _attackTimer;
    [SerializeField] float _attackSpan;

    public GameObject _targetEnemy;
    [SerializeField] GameObject _bulletPrefab;

    public TOWERSTATE _towerState;

    EnemyDetecting _enemyDetecting;

    public enum TOWERSTATE
    {
        IDLE,
        ATTACK,
        UPGRADING,
        NONE,
    }

    private void Start()
    {
        _enemyDetecting = GetComponentInChildren<EnemyDetecting>();
        _towerState = TOWERSTATE.IDLE; 
    }

    private void Update()
    {
        switch (_towerState)
        {
            case TOWERSTATE.IDLE:
                if (_enemyDetecting._enemies.Count > 0 && _targetEnemy != null)
                {
                    _targetEnemy = _enemyDetecting._enemies[0];
                    _towerState = TOWERSTATE.ATTACK;
                }
                break;
            case TOWERSTATE.ATTACK:
                if (_targetEnemy != null)
                {
                    transform.LookAt(_targetEnemy.transform.position);
                    Vector3 dir = transform.localRotation.eulerAngles;
                    dir.x = 0;
                    transform.localRotation = Quaternion.Euler(dir);

                    _attackTimer += Time.deltaTime;
                    if (_attackTimer > _attackSpan)
                    {
                        _attackTimer = 0;
                        GameObject bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
                        bullet.GetComponent<BulletController>()._target = _targetEnemy;
                        bullet.GetComponent<BulletController>()._bulletDamage = _attackPower;
                    }
                }
                else
                {
                    _attackTimer = 0;
                    _towerState = TOWERSTATE.IDLE;
                }
                break;
            case TOWERSTATE.UPGRADING:
                break;
            case TOWERSTATE.NONE:
                break;
            default:
                break;
        }
    }
}
