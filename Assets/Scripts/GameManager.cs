using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    /**
     * 关于button的问题
     * unity中，button应该挂载对应的gameobject而不是写的脚本，如果挂载了脚本则无法找到对应的方法
     * 挂在了gameobject可以找到需要的方法
     */

    public Button restartButton;//重新开始
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //此处button一直无法触发
        restartButton.onClick.AddListener(reloadScene);
        restartButton.gameObject.SetActive(false);//开始时处于未激活状态
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.isDead) 
        { 
            //玩家死亡，玩家对象非激活
            player.SetActive(false);
            //重新开始游戏按钮激活
            restartButton.gameObject.SetActive(true);
        }
    }

    //重新加载场景
    public void reloadScene()
    {
        //加载所有已激活场景
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("重新激活");
    }

    
}
