using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public Sprite openImage;
    public GameObject[] Items;
    public bool open = false;
    public int arrangeId;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(open == false && collision.gameObject.CompareTag("Player"))
        {
            open = true;
            GetComponent<SpriteRenderer>().sprite = openImage;
            int i = Random.Range(0, Items.Length);
            Instantiate(Items[i], transform.position, Quaternion.identity);
            Destroy(gameObject, 4.2f);
            SaveDataManager.SetArrangeId(arrangeId, gameObject.tag);
        }
    }
}
