using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExitDirection
{
    left, right, up, down
}
public class Exit : MonoBehaviour
{
    public string sceneName = "";
    public int doorNumber = 0;
    public ExitDirection direction = ExitDirection.down; //���� ��ġ���� �÷��̾ ��� ����
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RoomManager.ChangeScene(sceneName, doorNumber);
        }
    }
}
