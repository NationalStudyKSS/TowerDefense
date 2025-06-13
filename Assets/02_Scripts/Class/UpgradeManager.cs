using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public GameObject _upgradeTarget;

    public void ATKUp()
    {
        _upgradeTarget.GetComponent<TowerController>()._attackPower += 10;
    }

    public void ASPUp()
    {
        if (_upgradeTarget.GetComponent<TowerController>()._attackSpan > 0.25f)
        {
            _upgradeTarget.GetComponent<TowerController>()._attackSpan -= 0.1f;
        }
    }

    public void ARGUp()
    {
        if (_upgradeTarget.transform.GetChild(1).transform.localScale.x < 10)
        {
            _upgradeTarget.transform.GetChild(1).transform.localScale += new Vector3(1, 0, 1);
        }
    }
}
