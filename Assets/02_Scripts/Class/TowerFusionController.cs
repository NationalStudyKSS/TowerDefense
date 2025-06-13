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
            // 위치를 정해서 reallyStrongTower 생성
            Vector3 spawnPos = strongTowers[0].transform.position;

            Instantiate(_reallyStrongTowerPrefab, spawnPos, Quaternion.identity);

            // 기존 타워 삭제
            Destroy(basicTowers[0].gameObject);
            Destroy(basicTowers[1].gameObject);
            Destroy(strongTowers[0].gameObject);
        }
    }
    
}
