using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDestroyer : MonoBehaviour
{
    public int maxHp;
    public int currentHp;

    private void Start()
    {
        currentHp = maxHp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponentInChildren<HUDHpBar>().DestroyHpBar();
            Destroy(other.gameObject);
            currentHp--;

            if (currentHp < 0)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
