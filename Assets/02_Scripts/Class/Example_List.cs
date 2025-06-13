using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_List : MonoBehaviour
{
    [SerializeField] GameObject[] _array;

    [SerializeField] List<GameObject> _list;

    private void Start()
    {
        _array = new GameObject[_array.Length];
        _array = GameObject.FindGameObjectsWithTag("Tower");

        for (int i = 0; i < _array.Length; i++)
        {
            _list.Add(GameObject.Find("Cube_" + i));
        }

        Debug.Log(_list[7].name);
        _list.RemoveAt(0);
    }
}
