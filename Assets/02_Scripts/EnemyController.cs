using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] List<Transform> _targetPos = new();
    [SerializeField] CharacterController _characterController;
    [SerializeField] Transform _curTargetPos;

    public float _moveSpeed = 5f;
    [SerializeField] float _rotationSpeed = 10f;
    public int _enemyHp = 100;

    bool isDead = false;

    [SerializeField] GameManager _gameManager;

    [SerializeField] GameObject _deadEffect;

    // 임시
    [SerializeField] int nodeNum = 9;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        for (int i = 0; i < nodeNum; i++)
        {
            _targetPos.Add(GameObject.Find("Node_" + i).transform);
        }
    }

    private void Update()
    {
        if (_targetPos.Count > 0)
        {
            _curTargetPos = _targetPos[0];
            float distance = Vector3.Distance(transform.position, _curTargetPos.position);
            Vector3 dir = _curTargetPos.position - transform.position;
            dir.y = 0;
            dir.Normalize();
            _characterController.SimpleMove(dir * _moveSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), _rotationSpeed * Time.deltaTime);

            if (distance < 0.2f)
            {
                _targetPos.RemoveAt(0);
            }
        }
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
                Destroy(gameObject);
            }
        }
        
    }
}
