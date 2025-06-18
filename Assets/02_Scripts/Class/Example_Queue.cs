using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_Queue : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int maxQueueSize = 10;

    public float curTime;
    public float coolTime;

    public Queue<GameObject> bulletQueue = new Queue<GameObject>();

    private void Awake()
    {
        GameObject bulletObj;
        for (int i = 0; i < maxQueueSize; i++)
        {
            bulletObj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bulletObj.GetComponent<Bullet_Queue>().parentQueue = GetComponent<Example_Queue>();
            bulletObj.SetActive(false);
            bulletQueue.Enqueue(bulletObj);

            Debug.Log("bulletQueue.Count ::: " + bulletQueue.Count);
        }
    }

    private void Start()
    {
        Debug.Log("Awake() 호출 다음에 호출");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            curTime += Time.deltaTime;
            if (curTime > coolTime && bulletQueue.Count>0)
            {
                curTime = 0;
                //GameObject obj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                GameObject obj = bulletQueue.Dequeue();
                obj.SetActive(true);
            }
        }
    }

    public void InitBullet(GameObject bullet)
    {
        bulletQueue.Enqueue(bullet);
        bullet.transform.position = transform.position;
        bullet.SetActive(false);
    }
}
