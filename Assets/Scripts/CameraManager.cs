using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float downSpeed;//������½��ٶ�
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //����������½���ʵ����Ϸ����ذ岻�����Ƶ�Ч��
        //�˴���Ҫ�̶���������˲���update�д����������update�л��ܵ�������������
        transform.Translate(0, -downSpeed * Time.deltaTime, 0);
    }
}
