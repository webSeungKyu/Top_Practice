using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    key, life, arrow
}

public class ItemData : MonoBehaviour
{
    public ItemType type;
    public int count = 1;

    public int arrangeId = 0;
    void Start()
    {
        StartCoroutine("ItemMove");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ItemMove()
    {
        int temp = 1;
        Transform originalTransfrom = transform;
        yield return new WaitForSeconds(1.19f);
        while (true)
        {
            if(transform.position.y <= originalTransfrom.position.y)
            {
                temp *= -1;
                transform.Translate(0, (temp * 9.7f * Time.deltaTime), 0);
            }
            else
            {
                temp *= -1;
                transform.Translate(0, (temp * 9.7f * Time.deltaTime), 0);
            }
            yield return new WaitForSeconds(0.42f);


        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switch (type)
            {
                case ItemType.key:
                    ItemKeeper.hasKeys++; break;
                case ItemType.arrow:
                    ItemKeeper.hasArrows++; break;
                case ItemType.life:
                    PlayerController.hp++;
                    PlayerPrefs.SetInt("playerHp", PlayerController.hp); 
                    break;

                default: Debug.Log("¿¹¿Ü"); break;
            }
            SaveDataManager.SetArrangeId(arrangeId, gameObject.tag);
        }

        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        rb.gravityScale = 0;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        rb.AddForce(new Vector2(0, 4.2f), ForceMode2D.Impulse);
        Destroy(gameObject, 1.19f);


    }
}
