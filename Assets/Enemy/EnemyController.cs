using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 0.42f;
    public float reactionDistance = 4.2f;

    bool moveOnOff = false;
    Animator animator;
    Rigidbody2D rbody;

    float axisH;
    float axisV;
    public int arrangeId = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            //플레이어가 있고 움직임 On일 때
            if (moveOnOff)
            {
                //플레이어와의 각도 구하기
                float x = player.transform.position.x - transform.position.x;
                float y = player.transform.position.y - transform.position.y;
                float rad = Mathf.Atan2(y, x);
                float angle = rad * Mathf.Deg2Rad;

                if (y > 0)
                {
                    //위
                    animator.SetBool("Up", true);
                    animator.SetBool("Down", false);
                }
                else
                {
                    //아래
                    animator.SetBool("Down", true);
                    animator.SetBool("Up", false);
                }

                //이동할 백터 저장
                axisH = Mathf.Cos(rad) * speed;
                axisV = Mathf.Sin(rad) * speed;

            }
            else
            {
                float distance = Vector2.Distance(player.transform.position, transform.position);
                if (distance < reactionDistance)
                {
                    moveOnOff = true;
                }
            }

        }
    }

    private void FixedUpdate()
    {
        if(moveOnOff)
        {
            rbody.velocity = new Vector2(axisH, axisV);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            rbody.gravityScale = 0;
            GetComponent<CircleCollider2D>().enabled = false;
            animator.Play("EnemyDie");
            Destroy(gameObject, 1.19f);
            SaveDataManager.SetArrangeId(arrangeId, gameObject.tag);
        }
    }
}
