using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text _killCountText;
    [SerializeField] Text _lvText;
    [SerializeField] Slider _slider;
    [SerializeField] GameObject _settingsPanel;

    [SerializeField] GameManager _gameManager;
    [SerializeField] EnemyDestroyer _enemyDestroyer;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _slider.value = 1f;
    }

    private void Update()
    {
        _killCountText.text = "KILL : " + _gameManager._killCount;
        _lvText.text = "LV" + _gameManager._currentLevel;
        _slider.value = (float)_enemyDestroyer.currentHp / _enemyDestroyer.maxHp;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _settingsPanel.SetActive(!_settingsPanel.activeSelf);
        }
    }

    public void RangeOff()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("AttackRange");
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].GetComponent<MeshRenderer>().enabled = false;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadIntro()
    {
        SceneManager.LoadScene(0);
    }
}
