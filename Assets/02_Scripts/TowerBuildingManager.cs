using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuildingManager : MonoBehaviour
{
    [SerializeField] GameObject _towerPrefab;
    [SerializeField] GameObject _upgradePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
                        GameObject tower = Instantiate(_towerPrefab);
                        tower.transform.position = hit.collider.transform.position +
                            new Vector3(0, hit.collider.gameObject.transform.localScale.y, 0);
                        break;
                    case "Block_None":
                        break;
                    case "Tower":
                        hit.collider.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = true;
                        _upgradePanel.SetActive(true);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
