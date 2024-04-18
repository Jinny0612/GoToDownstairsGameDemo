using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloorManager : MonoBehaviour
{
    readonly float leftBorder = -3;//左边界
    readonly float rightBorder = 3;//右边界
    //初始坐标
    readonly float initPositionY = 0;
    [Range(2,6)]public float spacingY;//每个地板的垂直间距，unity中设置
    [Range(0, 20)] public float singleFloorHeight;

    readonly float MAX_FLOOR_COUNT = 10;//最大地板数量
    readonly float MIN_FLOOR_UNDER_PLAYER_COUNT = 5;//玩家脚下最少地板数量
    //static int groundNumber = -1;


    private List<Transform> floors;//已经生成的地板集合
    public Transform player;//unity绑定玩家角色

    //unity中使用的TextMeshPro，但是代码中要使用TMP_Text类型才能将unity中的文本物体挂载到脚本上
    public TMP_Text displayCountText;//展示的楼层数

    // Start is called before the first frame update
    void Start()
    {
        floors = new List<Transform>();
        for (int i = 0;i<MAX_FLOOR_COUNT;i++)
        {
            //初始化创建最大地板数量
            createFloor();
        }
    }

    // Update is called once per frame
    void Update()
    {
        createFloorWhenNeed();
        displayCountFloor();
    }

    //随机生成新地板的x坐标
    float newFloorPosionX()
    {
        if (floors.Count == 0)
        {
            return 0;
        }
        //生成左右边界中的随机数作为新地板的x坐标
        return UnityEngine.Random.Range(leftBorder, rightBorder);
    }

    //生成新的地板y坐标
    public float newFloorPosionY()
    {
        if (floors.Count == 0)
        {
            //生成第一块地板
            return initPositionY;
        }
        int index = floors.Count - 1;//上一块地板的下标
        //上一块地板的坐标 - 地板间距
        return floors[index].position.y - spacingY;
    }

    //创建地板
    void createFloor()
    {
        //创建地板  路径为assets/Resources下的Floor，Resources文件夹路径固定
        GameObject newFloor = Instantiate(Resources.Load<GameObject>("Floor"));
        newFloor.transform.position = new Vector3(newFloorPosionX(), newFloorPosionY(), 0);
        //加入已生成的地板集合
        floors.Add(newFloor.transform);
    }

    //地板数量不足时持续产生地板
    public void createFloorWhenNeed()
    {
        //玩家下方地板数量
        int floorUnderPlayerCount = 0;
        foreach(Transform floor in floors)
        {
            if(floor.position.y < player.position.y)
            {
                floorUnderPlayerCount++;
            }
        }
        if (floorUnderPlayerCount < MIN_FLOOR_UNDER_PLAYER_COUNT)
        {
            //地板数量不足，创建新地板
            createFloor();
            //如果地板数量过多则移除掉第一块地板
            controlFloorCount();
        }
    }

    //控制地板数量
    public void controlFloorCount()
    {
        if(floors.Count > MAX_FLOOR_COUNT)
        {
            Destroy(floors[0].gameObject);
            floors.RemoveAt(0);
        }
    }

    //计算已经下了几楼
    float countLowerFloor()
    {
        float playerPositionY = player.transform.position.y;
        float deep = Mathf.Abs(initPositionY - playerPositionY) + 1 ;
        return Mathf.Floor(deep / spacingY) +1;
    }

    public void displayCountFloor()
    {
        //tostring此处可以去掉小数位
        displayCountText.SetText("已经下了 " + countLowerFloor().ToString("0000") + " 楼");
    }
}
