using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimation : MonoBehaviour
{
    public void OnFireAnim()
    {
        Debug.Log("����");
        transform.parent.GetComponent<TowerController>().GunFire();
    }
}
