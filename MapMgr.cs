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

    public void Start()
    {
        if (_instance == null)
            _instance = this;
    }

    public void Init()
    {
        foreach (MapCube item in CubeList)
        {
            item.gameObject.transform.position = new Vector3(item.Pos.x, item.Pos.y, 0.0f) + this.transform.position;
        }

    }

}
