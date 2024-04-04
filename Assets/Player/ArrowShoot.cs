using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class ArrowShoot : MonoBehaviour
{
    public float shootSpeed = 11.9f;
    public float shootDelay = 0.119f;
    public GameObject bowPrefab;
    public GameObject arrowPrefab;

    bool attacking = false;
    GameObject bowObj;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = transform.position;
        bowObj = Instantiate(bowPrefab, pos, Quaternion.identity);
        bowObj.transform.SetParent(transform); //�÷��̾� ĳ���͸� Ȱ�� �θ�� ����
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        float bowZ = -1; // Ȱ�� Z�� ĳ���ͺ��� ������ ����
        PlayerController playerCnt = GetComponent<PlayerController>();
        if (playerCnt.angleZ > 30 && playerCnt.angleZ < 150)
        {
            bowZ = 1; //Ȱ�� Z�� ĳ���ͺ��� �ڷ� ����
        }

        bowObj.transform.rotation = Quaternion.Euler(0,0, playerCnt.angleZ);
        bowObj.transform.position = new Vector3(transform.position.x, transform.position.y, bowZ);



    }

    public void Attack()
    {
        if(ItemKeeper.hasArrows > 0 && attacking == false)
        {
            //ȭ���� ���� �ְ� ���� ���� �ƴ� �� ����
            ItemKeeper.hasArrows--;
            attacking = true;
            PlayerController playerCnt = GetComponent<PlayerController>();
            float angleZ = playerCnt.angleZ;
            Quaternion r = Quaternion.Euler(0, 0, angleZ);
            GameObject arrowObj = Instantiate(arrowPrefab, transform.position, r);

            float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
            float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);
            Vector3 v = new Vector3(x, y) * shootSpeed;
            Rigidbody2D rb = arrowObj.GetComponent<Rigidbody2D>();
            rb.AddForce(v, ForceMode2D.Impulse);
            Invoke("StopAttack", shootDelay);
        }
    }

    public void StopAttack()
    {
        attacking = false;
    }
}
