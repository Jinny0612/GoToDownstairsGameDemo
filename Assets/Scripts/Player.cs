using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forceX;//ˮƽ����,������unity������
    Rigidbody2D playerRigidBody2D;
    readonly float toLeft = -1;
    readonly float toRight = 1;
    readonly float stop = 0;
    float directionX;//���ʵ�ʵķ���

    //����Ƿ���
    public static bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        playerRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)) {
            directionX = toLeft;//����
        }else if (Input.GetKey(KeyCode.D))
        {
            directionX = toRight;//����
        }
        else
        {
            directionX = stop;
        }
        Vector2 newDir = new Vector2(directionX,0);//ȷ������
        playerRigidBody2D.AddForce(newDir * forceX);//��������·����ƶ�
    }
}
