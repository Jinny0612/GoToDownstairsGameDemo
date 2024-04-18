using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forceX;//水平推力,可以在unity中设置
    Rigidbody2D playerRigidBody2D;
    readonly float toLeft = -1;
    readonly float toRight = 1;
    readonly float stop = 0;
    float directionX;//玩家实际的方向

    //玩家是否存活
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
            directionX = toLeft;//向左
        }else if (Input.GetKey(KeyCode.D))
        {
            directionX = toRight;//向右
        }
        else
        {
            directionX = stop;
        }
        Vector2 newDir = new Vector2(directionX,0);//确定方向
        playerRigidBody2D.AddForce(newDir * forceX);//将玩家向新方向推动
    }
}
