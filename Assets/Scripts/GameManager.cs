using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    /**
     * ����button������
     * unity�У�buttonӦ�ù��ض�Ӧ��gameobject������д�Ľű�����������˽ű����޷��ҵ���Ӧ�ķ���
     * ������gameobject�����ҵ���Ҫ�ķ���
     */

    public Button restartButton;//���¿�ʼ
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //�˴�buttonһֱ�޷�����
        restartButton.onClick.AddListener(reloadScene);
        restartButton.gameObject.SetActive(false);//��ʼʱ����δ����״̬
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.isDead) 
        { 
            //�����������Ҷ���Ǽ���
            player.SetActive(false);
            //���¿�ʼ��Ϸ��ť����
            restartButton.gameObject.SetActive(true);
        }
    }

    //���¼��س���
    public void reloadScene()
    {
        //���������Ѽ����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("���¼���");
    }

    
}
