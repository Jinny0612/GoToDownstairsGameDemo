using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null) 
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                //如果碰撞到陷阱的物体标签是player,玩家死亡
                Player.isDead = true;

            }
        }
    }
}
