using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    

    void Start()
    {
        
    }

    //문에 트리거 체크 안 할 것이므로 onTrigger 대신 OnCollsion 씀
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
