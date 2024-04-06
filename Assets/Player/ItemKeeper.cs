using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemKeeper : MonoBehaviour
{
    [Header("열쇠와 화살 소지 수")]
    public static int hasKeys = 3;
    public static int hasArrows = 3;
    // Start is called before the first frame update
    void Start()
    {
        hasKeys = PlayerPrefs.GetInt("keys");
        hasArrows = PlayerPrefs.GetInt("arrows");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SaveItem()
    {
        PlayerPrefs.SetInt("keys", hasKeys);
        PlayerPrefs.SetInt("arrows", hasArrows);
    }
}
