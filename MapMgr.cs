﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMgr: MonoBehaviour
{
    public bool canMove = true;
    [Header("旋转上面的transform来适配大方向")]
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
        canMove = true;
        foreach (MapCube item in CubeList)
        {
            item.gameObject.transform.position = this.transform.forward* item.Pos.y + this.transform.right * item.Pos.x  + this.transform.position;
            //初始
            item.Init();

        }

    }

    public void RotationController()
    {

    }


    private void Update()
    {
         if(Input.GetKeyDown(KeyCode.F1))
        {
            ScenesManager.Instance().isPowerOn = false;
            ScenesManager.Instance().SceneLoad(1);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            ScenesManager.Instance().isPowerOn = false;
            ScenesManager.Instance().SceneLoad(2);
        }
    }
}
