using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float downSpeed;//摄像机下降速度
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
        //摄像机匀速下降，实现游戏界面地板不断上移的效果
        //此处需要固定次数，因此不在update中处理，如果放在update中会受到电脑性能限制
        transform.Translate(0, -downSpeed * Time.deltaTime, 0);
    }
}
