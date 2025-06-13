using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_Animator_Event : MonoBehaviour
{
    [SerializeField] Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _animator.SetInteger("TOWERSTATE", 1);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            _animator.SetInteger("TOWERSTATE", 0);
        }
    }

    public void OnFireAnim()
    {
        Debug.Log("»§¾ß!");
    }
}
