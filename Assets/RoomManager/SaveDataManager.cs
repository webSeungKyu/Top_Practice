using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SaveDataManager : MonoBehaviour
{
    public static SaveDataList arrangeDataList;
    void Start()
    {
        arrangeDataList = new SaveDataList();
        arrangeDataList.saveDatas = new SaveData[] { };
        string stageName = PlayerPrefs.GetString("lastScene");
        string data = PlayerPrefs.GetString(stageName);
        if(data != null)
        {
            //json > SaveDataList·Î º¯È¯
            arrangeDataList = JsonUtility.FromJson<SaveDataList>(data);
            for(int i = 0; i < arrangeDataList.saveDatas.Length; i++)
            {
                SaveData saveData = arrangeDataList.saveDatas[i];
                string objTag = saveData.objTag;
                GameObject[] objects = GameObject.FindGameObjectsWithTag(objTag);
                for(int j = 0; j < objects.Length; j++)
                {
                    GameObject obj = objects[j];
                    if (objTag.Equals("Door"))
                    {
                        Door door = obj.GetComponent<Door>();
                        if(door.arrangeId == saveData.arrangeId)
                        {
                            Destroy(obj);
                        }
                    }else if (objTag.Equals("ItemBox"))
                    {
                        ItemBox box = obj.GetComponent<ItemBox>();
                        if(box.arrangeId == saveData.arrangeId)
                        {
                            box.open = false;
                            box.GetComponent<SpriteRenderer>().sprite = box.openImage;
                        }
                    }else if (objTag.Equals("Item"))
                    {
                        ItemData item = obj.GetComponent<ItemData>();
                        if (item.arrangeId == saveData.arrangeId)
                        {
                            Destroy(obj);
                        }
                    }else if (objTag.Equals("Enemy"))
                    {
                        EnemyController enemy = obj.GetComponent<EnemyController>();
                        if(enemy.arrangeId == saveData.arrangeId)
                        {
                            Destroy(obj);
                        }
                    }
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SetArrangeId(int arrangeId, string objTag)
    {
        if(arrangeId == 0 || objTag == "")
        {
            return;
        }

        SaveData[] newSaveDatas = new SaveData[arrangeDataList.saveDatas.Length +1 ];

        
        for(int i = 0; i < arrangeDataList.saveDatas.Length; i++)
        {
            newSaveDatas[i] = arrangeDataList.saveDatas[i];
        }
        SaveData saveData = new SaveData();
        saveData.arrangeId = arrangeId;
        saveData.objTag = objTag;
        newSaveDatas[arrangeDataList.saveDatas.Length] = saveData;
        arrangeDataList.saveDatas = newSaveDatas;

    }

    public static void SaveArrangeData(string stageName)
    {
        if(arrangeDataList.saveDatas != null && stageName != "")
        {
            string saveJson = JsonUtility.ToJson(arrangeDataList);

            PlayerPrefs.SetString(stageName, saveJson);
        }
    }
}
