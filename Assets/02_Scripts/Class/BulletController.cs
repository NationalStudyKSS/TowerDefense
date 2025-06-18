using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 20f;
    public int _bulletDamage = 25;
    public GameObject _target;

    private void Update()
    {
        if (_target != null)
        {
            transform.LookAt(_target.transform);
            transform.Translate(0, 0, _bulletSpeed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().DamagebyBullet(_bulletDamage);
            Destroy(gameObject);
        }
    }
}