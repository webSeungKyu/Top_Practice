using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    

    void Start()
    {
        
    }

    //���� Ʈ���� üũ �� �� ���̹Ƿ� onTrigger ��� OnCollsion ��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(ItemKeeper.hasKeys > 0)
            {
                ItemKeeper.hasKeys--;
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        
    }
}
