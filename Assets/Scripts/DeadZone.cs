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
                //�����ײ������������ǩ��player,�������
                Player.isDead = true;

            }
        }
    }
}
