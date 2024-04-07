using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    public static int doorNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] enters = GameObject.FindGameObjectsWithTag("Exit");
        for(int i = 0; i < enters.Length; i++)
        {
            GameObject doorObj = enters[i];
            Exit exit = doorObj.GetComponent<Exit>();
            if(doorNumber == exit.doorNumber)
            {
                float x = doorObj.transform.position.x;
                float y = doorObj.transform.position.y;

                if(exit.direction == ExitDirection.up)
                {
                    y += 1;
                }else if (exit.direction == ExitDirection.right)
                {
                    x += 1;
                }
                else if (exit.direction == ExitDirection.down)
                {
                    x -= 1;
                }
                else if (exit.direction == ExitDirection.left)
                {
                    x -= 1;
                }

                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.transform.position = new Vector3(x, y);
                break;

            }
        }
    }

    public static void ChangeScene(string sceneName, int doorNum)
    {
        doorNumber = doorNum;
        string nowScene = PlayerPrefs.GetString("lastScene");
        if(nowScene != "")
        {
            SaveDataManager.SaveArrangeData(nowScene);
        }
        PlayerPrefs.SetString("lastScene", sceneName);
        PlayerPrefs.SetInt("lastDoor", doorNumber);
        ItemKeeper.SaveItem();

        SceneManager.LoadScene(sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
