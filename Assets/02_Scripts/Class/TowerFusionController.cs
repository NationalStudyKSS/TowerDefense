using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerFusionController : MonoBehaviour
{
    public List<TowerController> _placedTowers = new();
    public GameObject _reallyStrongTowerPrefab;

    public void TryMerge()
    {
        var basicTowers = _placedTowers.Where(t => t is TowerController && !(t is StrongTowerController)).ToList();
        var strongTowers = _placedTowers.OfType<StrongTowerController>().ToList();

        if (basicTowers.Count >= 2 && strongTowers.Count >= 1)
        {
            // ��ġ�� ���ؼ� reallyStrongTower ����
            Vector3 spawnPos = strongTowers[0].transform.position;

            Instantiate(_reallyStrongTowerPrefab, spawnPos, Quaternion.identity);

            // ���� Ÿ�� ����
            Destroy(basicTowers[0].gameObject);
            Destroy(basicTowers[1].gameObject);
            Destroy(strongTowers[0].gameObject);
        }
    }
    
}
