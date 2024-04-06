using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirtualPad : MonoBehaviour
{
    public float maxLength = 70.0f; // ���� �����̴� �ִ� �Ÿ�
    public bool is4DPad = true; // �����¿�� �����̴��� ����
    GameObject player;
    Vector2 startLocation;
    Vector2 touchLocation;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player");
        startLocation = GetComponent<RectTransform>().localPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// �е� ������ �� ���콺 ����Ʈ�� ��ũ�� ��ǥ
    /// </summary>
    public void PadDown()
    {
        touchLocation = Input.mousePosition;
    }


    public void PadDrag()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 newTabPosition = mousePosition - touchLocation;

        if (is4DPad == false)
        {
            newTabPosition.y = 0; // Ⱦ��ũ�� ���ӿ��� Y�� 0
        }
        Vector2 axis = newTabPosition.normalized; // ���� ����ȭ
        float distance = Vector2.Distance(startLocation, newTabPosition);
        if (distance > maxLength)
        {
            newTabPosition.x = axis.x * maxLength;
            newTabPosition.y = axis.y * maxLength;
            //�� �� ������ �Ÿ��� ���� �� �Ѱ� �Ÿ��� �ѱ�� �Ѱ� ��ǥ�� ����
        }
        //�� �̵�

        GetComponent<RectTransform>().localPosition = newTabPosition;
        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.SetAxis(axis.x, axis.y);
    }

    /// <summary>
    /// �е� ���� �е��� ��ġ�� ���� ��ġ��, �÷��̾�� �� �����̰�
    /// </summary>
    public void PadUp()
    {
        GetComponent<RectTransform>().localPosition = startLocation;
        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.SetAxis(0, 0);
    }

    public void Attack()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        ArrowShoot shoot = player.GetComponent<ArrowShoot>();
        shoot.Attack();
    }
}
