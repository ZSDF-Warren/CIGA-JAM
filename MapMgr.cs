using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMgr: MonoBehaviour
{
    //地图块儿列表
    public List<MapCube> CubeList;

    /// <summary>
    /// MapMgr 单列
    /// </summary>
    private static MapMgr _instance;
    public static MapMgr Instance
    {
        get
        {
            return _instance;
        }
    }


    public void Awake()
    {
        if (_instance == null)
            _instance = this;

        Init();
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        foreach (MapCube item in CubeList)
        {
            item.gameObject.transform.position = new Vector3(item.Pos.x, 0.0f, item.Pos.y) + this.transform.position;
            //初始
            item.Init();
        }

    }

    public void RotationController()
    {

    }

}
