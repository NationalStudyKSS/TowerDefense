using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController_NaviMesh : MonoBehaviour
{
    [SerializeField] List<Transform> _targetPos = new();
    [SerializeField] CharacterController _characterController;
    [SerializeField] Transform _curTargetPos;

    public float _moveSpeed = 5f;
    [SerializeField] float _rotationSpeed = 10f;
    public int _enemyHp = 100;

    public bool isDead = false;

    [SerializeField] GameManager _gameManager;

    [SerializeField] GameObject _deadEffect;
    public NavMeshAgent nvAgent;

    // юс╫ц
    [SerializeField] int nodeNum = 9;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _characterController = GetComponent<CharacterController>();
        nvAgent = GetComponent<NavMeshAgent>();
        nvAgent.SetDestination(_targetPos[0].position);
    }

    public void DamagebyBullet(int damage)
    {
        if (isDead == false)
        {
            _enemyHp -= damage;
            if (_enemyHp <= 0)
            {
                isDead = true;
                _gameManager._killCount++;
                Instantiate(_deadEffect, transform.position, transform.rotation);
                GetComponentInChildren<HUDHpBar>().DestroyHpBar();
                Destroy(gameObject);
            }
        }

    }
}