using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float deleteTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, deleteTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ȭ���� ���� ���� ������ ���� �ڵ�
        transform.SetParent(collision.transform);
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
