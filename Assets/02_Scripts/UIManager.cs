using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text _killCountText;
    [SerializeField] Text _lvText;

    [SerializeField] GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        _killCountText.text = "KILL : " + _gameManager._killCount;
        _lvText.text = "LV" + _gameManager._currentLevel;
    }
}
