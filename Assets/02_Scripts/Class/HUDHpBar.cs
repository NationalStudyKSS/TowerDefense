using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDHpBar : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] RectTransform _canvas;
    [SerializeField] RectTransform _hpBar;
    [SerializeField] Camera _mainCam;

    [SerializeField] GameObject _hpBarPrefab;
    [SerializeField] GameObject _hpObject;
    [SerializeField] int _maxHp;

    private void Start()
    {
        _hpObject = Instantiate(_hpBarPrefab);
        _target = gameObject.transform;
        _canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        _hpObject.transform.SetParent(_canvas);
        _hpBar=_hpObject.GetComponent<RectTransform>();
        _hpBar.localPosition = Vector3.zero;
        _hpBar.localRotation = Quaternion.Euler(0,0,0);
        _hpBar.localScale = Vector3.one;
        _mainCam = Camera.main;
        _maxHp = transform.parent.GetComponent<EnemyController>()._enemyHp;
    }

    private void Update()
    {
        Vector3 currentPos = _target.transform.position;
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(currentPos);
        Vector2 canvasPos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas, screenPoint, _mainCam, out canvasPos);

        _hpBar.localPosition = canvasPos;
        _hpBar.GetComponent<Slider>().value = (float)transform.parent.GetComponent<EnemyController>()._enemyHp / _maxHp;
    }

    public void DestroyHpBar()
    {
        Destroy(_hpBar.gameObject);
    }
}
