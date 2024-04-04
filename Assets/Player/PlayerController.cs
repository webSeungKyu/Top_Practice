using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;
    public string UpAnime = "PlayerUp";
    public string downAnime = "PlayerDown";
    public string leftAnime = "PlayerLeft";
    public string rightAnime = "PlayerRight";
    public string deadAnime = "PlayerDead";
    string nowAnimation = "";
    string oldAnimation = "";

    float axisH;
    float axisV;
    public float angleZ = -90.0f; //ȸ����

    Rigidbody2D rbody;
    bool isMoving = false;

    public static int hp = 3;
    public static string gameState;
    bool damaging = false;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        oldAnimation = downAnime;
        gameState = "playing";
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == false)
        {
            axisH = Input.GetAxisRaw("Horizontal");
            axisV = Input.GetAxisRaw("Vertical");
        }
        Vector2 fromPt = transform.position;
        Vector2 toPt = new Vector2(fromPt.x + axisH, fromPt.y + axisV);
        angleZ = GetAngle(fromPt, toPt);
        //90���� ��, 0���� ������, -90���� �Ʒ�, 180���� ����
        if (angleZ >= -45 && angleZ < 45)
        {
            nowAnimation = rightAnime;
        }
        else if (angleZ >= 45 && angleZ <= 135)
        {
            nowAnimation = UpAnime;
        }
        else if (angleZ >= -135 && angleZ <= -45)
        {
            nowAnimation = downAnime;
        }
        else
        {
            nowAnimation = leftAnime;
        }

        //�ִϸ��̼� ����
        if (nowAnimation != oldAnimation)
        {
            oldAnimation = nowAnimation;
            GetComponent<Animator>().Play(nowAnimation);
        }

        if(gameState != "playing" || damaging)
        {
            return;
        }
    }


    private void FixedUpdate()
    {
        if (gameState != "playing" || damaging)
        {
            return;
        }
        if (damaging)
        {
            float val = Mathf.Sin(Time.time * 50);
            if(val > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            return;
        }
        rbody.velocity = new Vector2(axisH, axisV) * speed;

    }

    public void SetAxis(float h, float v)
    {
        axisH = h;
        axisV = v;
        if(axisH == 0 &&  axisV == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }

    private float GetAngle(Vector2 p1, Vector2 p2)
    {
        float angle;
        if(axisH != 0 || axisV != 0)
        {
            //�̵� ���̸� ���� ���� > p1�� p2 ���� ���ϱ� (���� 0���� �ϱ� ����)
            float dx = p2.x - p1.x;
            float dy = p2.y - p1.y;
            //��ũ ź��Ʈ �Լ��� ����(����) ���ϱ�
            float rad = Mathf.Atan2(dy, dx);
            //���� ������ ��ȯ�Ͽ� ��ȯ
            angle = rad * Mathf.Rad2Deg;
        }
        else
        {
            angle = angleZ;
        }

        return angle;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GetDamage(collision.gameObject);
        }
    }
    void GetDamage(GameObject enemy)
    {
        if(gameState == "playing")
        {
            hp--;
            if(hp > 0)
            {
                //�ױ� ���� ������ ���߱�
                rbody.velocity = new Vector2(0, 0);
                Vector3 toPos = (transform.position - enemy.transform.position).normalized;
                rbody.AddForce(new Vector2(toPos.x * 4, toPos.y * 4), ForceMode2D.Impulse);
                damaging = true;
                Invoke("DamageEnd", 0.119f);
            }
            else
            {
                GameOver();
            }
        }
    }

    void DamageEnd()
    {
        damaging = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    void GameOver()
    {
        gameState = "gameOver";
        GetComponent<CircleCollider2D>().enabled = false;
        rbody.velocity = new Vector2(0, 0); // ��� ���� �� ������ ���߱�
        rbody.gravityScale = 1;
        rbody.AddForce(new Vector2(0, 0.5f), ForceMode2D.Impulse);
        GetComponent<Animator>().Play(deadAnime);
        Destroy(gameObject, 1.0f);
    }

}
