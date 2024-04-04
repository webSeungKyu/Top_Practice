using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject player;
    Transform respawnRegion; //������ ����(������ ��Ƴ��� ��ġ)
    // Start is called before the first frame update
    void Start()
    {
        respawnRegion = player.transform;

    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -11.9f);
        }
    }
}
