using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int hasKeys = 0;
    public int hasArrows = 0;
    public int playerHp = 0;
    public GameObject arrowText;
    public GameObject keyText;
    public GameObject hpImage;
    public List<Sprite> lifeImages;
    public GameObject mainImage;
    public GameObject resetButton;
    public Sprite gameOverSprite;
    public Sprite gameClearSprite;
    public List<GameObject> padAndAttack;
    public string reStartSceneName = "";
    // Start is called before the first frame update
    void Start()
    {
        UpdateHp();
        UpdateItemCount();
        Invoke("ImageFalse", 1.19f);
        resetButton.SetActive(false);

    }
    void ImageFalse()
    {
        mainImage.SetActive(false);
    }


    void Update()
    {
        UpdateHp();
        UpdateItemCount();
    }

    void UpdateItemCount()
    {
        if (hasKeys != ItemKeeper.hasKeys || hasArrows != ItemKeeper.hasArrows)
        {
            hasKeys = ItemKeeper.hasKeys;
            hasArrows = ItemKeeper.hasArrows;
            keyText.GetComponent<TextMeshProUGUI>().text = ItemKeeper.hasKeys.ToString();
            arrowText.GetComponent<TextMeshProUGUI>().text = ItemKeeper.hasArrows.ToString();
        }
    }

    void UpdateHp()
    {
        GameObject player = null;
        if (PlayerController.gameState != "gameEnd")
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (player != null)
        {
            playerHp = PlayerController.hp;
        }

        switch (playerHp)
        {
            case 0:
                hpImage.GetComponent<Image>().sprite = lifeImages[0]; 
                resetButton.SetActive(true);
                mainImage.SetActive(true);
                mainImage.GetComponent<Image>().sprite = gameOverSprite;
                padAndAttack[0].SetActive(false);
                padAndAttack[1].SetActive(false);
                PlayerController.gameState = "gameEnd";
                break;
            case 1:
                hpImage.GetComponent<Image>().sprite = lifeImages[1]; break;
            case 2:
                hpImage.GetComponent<Image>().sprite = lifeImages[2]; break;
            case 3:
                hpImage.GetComponent<Image>().sprite = lifeImages[3]; break;
                default: break;

        }
    }

    public void ReStart()
    {
        PlayerPrefs.SetInt("playerHp", 3);
        SceneManager.LoadScene(reStartSceneName);
    }


}
