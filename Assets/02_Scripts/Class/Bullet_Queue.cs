using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Queue : MonoBehaviour
{
    public Example_Queue parentQueue;
    public float bulletSpeed = 10f;

    private void Update()
    {
        transform.Translate(0, 0, bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        parentQueue.InitBullet(gameObject);
    }
}
