using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloorManager : MonoBehaviour
{
    readonly float leftBorder = -3;//��߽�
    readonly float rightBorder = 3;//�ұ߽�
    //��ʼ����
    readonly float initPositionY = 0;
    [Range(2,6)]public float spacingY;//ÿ���ذ�Ĵ�ֱ��࣬unity������
    [Range(0, 20)] public float singleFloorHeight;

    readonly float MAX_FLOOR_COUNT = 10;//���ذ�����
    readonly float MIN_FLOOR_UNDER_PLAYER_COUNT = 5;//��ҽ������ٵذ�����
    //static int groundNumber = -1;


    private List<Transform> floors;//�Ѿ����ɵĵذ弯��
    public Transform player;//unity����ҽ�ɫ

    //unity��ʹ�õ�TextMeshPro�����Ǵ�����Ҫʹ��TMP_Text���Ͳ��ܽ�unity�е��ı�������ص��ű���
    public TMP_Text displayCountText;//չʾ��¥����

    // Start is called before the first frame update
    void Start()
    {
        floors = new List<Transform>();
        for (int i = 0;i<MAX_FLOOR_COUNT;i++)
        {
            //��ʼ���������ذ�����
            createFloor();
        }
    }

    // Update is called once per frame
    void Update()
    {
        createFloorWhenNeed();
        displayCountFloor();
    }

    //��������µذ��x����
    float newFloorPosionX()
    {
        if (floors.Count == 0)
        {
            return 0;
        }
        //�������ұ߽��е��������Ϊ�µذ��x����
        return UnityEngine.Random.Range(leftBorder, rightBorder);
    }

    //�����µĵذ�y����
    public float newFloorPosionY()
    {
        if (floors.Count == 0)
        {
            //���ɵ�һ��ذ�
            return initPositionY;
        }
        int index = floors.Count - 1;//��һ��ذ���±�
        //��һ��ذ������ - �ذ���
        return floors[index].position.y - spacingY;
    }

    //�����ذ�
    void createFloor()
    {
        //�����ذ�  ·��Ϊassets/Resources�µ�Floor��Resources�ļ���·���̶�
        GameObject newFloor = Instantiate(Resources.Load<GameObject>("Floor"));
        newFloor.transform.position = new Vector3(newFloorPosionX(), newFloorPosionY(), 0);
        //���������ɵĵذ弯��
        floors.Add(newFloor.transform);
    }

    //�ذ���������ʱ���������ذ�
    public void createFloorWhenNeed()
    {
        //����·��ذ�����
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
            //�ذ��������㣬�����µذ�
            createFloor();
            //����ذ������������Ƴ�����һ��ذ�
            controlFloorCount();
        }
    }

    //���Ƶذ�����
    public void controlFloorCount()
    {
        if(floors.Count > MAX_FLOOR_COUNT)
        {
            Destroy(floors[0].gameObject);
            floors.RemoveAt(0);
        }
    }

    //�����Ѿ����˼�¥
    float countLowerFloor()
    {
        float playerPositionY = player.transform.position.y;
        float deep = Mathf.Abs(initPositionY - playerPositionY) + 1 ;
        return Mathf.Floor(deep / spacingY) +1;
    }

    public void displayCountFloor()
    {
        //tostring�˴�����ȥ��С��λ
        displayCountText.SetText("�Ѿ����� " + countLowerFloor().ToString("0000") + " ¥");
    }
}
