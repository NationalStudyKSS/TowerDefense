using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerFusionController : MonoBehaviour
{
    public List<TowerController> _placedTowers = new();
    public GameObject _reallyStrongTowerPrefab;

    public AudioClip _reallyStrongTowerAudioClip;

    public void TryMerge()
    {
        var basicTowers = _placedTowers.Where(t => t is TowerController && !(t is StrongTowerController)).ToList();
        var strongTowers = _placedTowers.OfType<StrongTowerController>().ToList();

        if (basicTowers.Count >= 2 && strongTowers.Count >= 1)
        {
            // 융합할 위치
            Vector3 spawnPos = strongTowers[0].transform.position;

            // 새로운 타워 생성
            var newTower = Instantiate(_reallyStrongTowerPrefab, spawnPos, Quaternion.identity);
            AudioSource.PlayClipAtPoint(_reallyStrongTowerAudioClip, transform.position);

            // 기존 타워 삭제 및 리스트에서 제거
            var tower1 = basicTowers[0];
            var tower2 = basicTowers[1];
            var tower3 = strongTowers[0];

            _placedTowers.Remove(tower1);
            _placedTowers.Remove(tower2);
            _placedTowers.Remove(tower3);

            Destroy(tower1.gameObject);
            Destroy(tower2.gameObject);
            Destroy(tower3.gameObject);

            // 필요하다면 새 타워도 리스트에 추가
            //var newTowerController = newTower.GetComponent<TowerController>();
            //if (newTowerController != null)
            //{
            //    _placedTowers.Add(newTowerController);
            //}
        }
    }

}
