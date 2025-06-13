using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuildingManager : MonoBehaviour
{
    [SerializeField] GameObject _towerPrefab;
    [SerializeField] GameObject _strongTowerPrefab;
    [SerializeField] GameObject _strongTowerEffect;

    [SerializeField] GameObject _upgradePanel;
    [SerializeField] UpgradeManager _upgradeManager;
    [SerializeField] TowerFusionController _fusionController;

    [SerializeField] float _strongTowerChance;

    bool hasTower = false;

    void Start()
    {
        _upgradeManager = GameObject.Find("UpgradeManager").GetComponent<UpgradeManager>();
        _fusionController = GameObject.Find("TowerFusionController").GetComponent<TowerFusionController>();
    }

    void Update()
    {
        if (_upgradePanel.activeSelf == true) return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.collider.gameObject.name);
                //Debug.Log(hit.collider.gameObject.transform.position);
                switch (hit.collider.gameObject.tag)
                {
                    case "Block":
                        Block block = hit.collider.GetComponent<Block>();
                        if (block != null && block.hasTower == false)
                        {
                            float rnd = Random.value;
                            if (rnd < _strongTowerChance)
                            {
                                //Instantiate(_strongTowerPrefab, block.transform.position + Vector3.up, Quaternion.identity);
                                GameObject strongTower = Instantiate(_strongTowerPrefab);
                                strongTower.transform.position = hit.collider.transform.position +
                                    new Vector3(0, hit.collider.gameObject.transform.localScale.y, 0);

                                StrongTowerController strongCtrl = strongTower.GetComponent<StrongTowerController>();
                                _fusionController._placedTowers.Add(strongCtrl);
                                Instantiate(_strongTowerEffect, block.transform.position + Vector3.up, Quaternion.identity);
                            }
                            else
                            {
                                //Instantiate(_towerPrefab, block.transform.position + Vector3.up, Quaternion.identity);
                                GameObject tower = Instantiate(_towerPrefab);
                                tower.transform.position = hit.collider.transform.position +
                                    new Vector3(0, hit.collider.gameObject.transform.localScale.y, 0);

                                // 리스트에 추가
                                TowerController towerCtrl = tower.GetComponent<TowerController>();
                                _fusionController._placedTowers.Add(towerCtrl);
                            }

                            block.hasTower = true;
                        }
                        break;
                    case "Block_None":
                        break;
                    case "Tower":
                        hit.collider.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = true;
                        _upgradePanel.SetActive(true);
                        _upgradeManager._upgradeTarget = hit.collider.gameObject;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
