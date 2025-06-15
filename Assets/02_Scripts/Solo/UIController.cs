//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class UIController : MonoBehaviour
//{
//    public PlayerController playerController;
//    public TextMeshProUGUI coinText;
//    public TextMeshProUGUI boosterText;
//    public GameObject settingsPanel;

//    // Start is called before the first frame update
//    void Start()
//    {
//        coinText.text = "0";
//        boosterText.text = "0 / 0";
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        coinText.text = $"{playerController.coinCount}";
//        boosterText.text = $"{playerController.boosterCount} / {playerController.boosterMaxCount}";
//    }

//    public void OpenSettings()
//    {
//        Time.timeScale = 0f; // 게임 일시정지
//        settingsPanel.SetActive(true);
//    }

//    public void CloseSettings()
//    {
//        settingsPanel.SetActive(false);
//        Time.timeScale = 1f; // 게임 재개
//    }
    
//    public void GoToMain()
//    {
//        SceneManager.LoadScene("00_Intro");
//    }
//}
