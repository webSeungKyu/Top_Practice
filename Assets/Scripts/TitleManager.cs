using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{

    public GameObject startBtn;
    public GameObject continueBtn;
    public string firstSceneName;
    void Start()
    {
        string sceneName = PlayerPrefs.GetString("lastScene");
        if(sceneName == "")
        {
            continueBtn.GetComponent<Button>().interactable = false;
        }
        else
        {
            continueBtn.GetComponent<Button>().interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBtnClick()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("playerHp", 3);
        PlayerPrefs.SetString("lastScene", firstSceneName);
        RoomManager.doorNumber = 0;
        SceneManager.LoadScene(firstSceneName);
    }

    public void ContinueBtnClick()
    {
        string sceneName = PlayerPrefs.GetString("lastScene");
        RoomManager.doorNumber = PlayerPrefs.GetInt("lastDoor");
        SceneManager.LoadScene(sceneName);
    }
}
