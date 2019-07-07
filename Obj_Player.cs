using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Player : Obj_Char
{
    [Header("玩家朝向右上为正")]
    public Vector2Int dir;

    public int Cross(Vector2Int v1, Vector2Int v2)
    {
        return v1.x * v2.y - v2.x * v1.y;
    }

    public void zombieMove()
    {
        foreach (string str in DirSave.Instance().Data)
        {
            //向前走
            if (Convert.ToInt32(str) == DirSave.EDIR.eUp.GetHashCode())
            {
                move(dir);
            }
            //backword
            else if (Convert.ToInt32(str) == DirSave.EDIR.eDown.GetHashCode())
            {
                move(new Vector2Int(-dir.x, -dir.y));
            }
            //right
            if (str.Equals(Convert.ToInt32(str) == DirSave.EDIR.eRight.GetHashCode()))
            {
                var d = dir;
                if (dir == new Vector2Int(1, 0))
                {
                    d = new Vector2Int(0, -1);
                }
                if (dir == new Vector2Int(0, 1))
                {
                    d = new Vector2Int(1, 0);
                }
                if (dir == new Vector2Int(-1, 0))
                {
                    d = new Vector2Int(0, 1);

                }
                if (dir == new Vector2Int(0, -1))
                {
                    d = new Vector2Int(-1, 0);
                }
                move(d);
            }
            //left
            if (Convert.ToInt32(str) == DirSave.EDIR.eLeft.GetHashCode()) 
            {
                var d = dir;
                if (dir == new Vector2Int(1, 0))
                {
                    d = new Vector2Int(0, 1);
                }
                if (dir == new Vector2Int(0, 1))
                {
                    d = new Vector2Int(-1, 0);
                }
                if (dir == new Vector2Int(-1, 0))
                {
                    d = new Vector2Int(0, -1);

                }
                if (dir == new Vector2Int(0, -1))
                {
                    d = new Vector2Int(1, 0);
                }
                move(d);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //zombieMove();
    }
    public void move(Vector2Int d)
    {

        var des = d + _cube.Pos;
        Debug.Log(des);
        foreach (var item in MapMgr.Instance.CubeList)
        {
            if (item.Pos == des)
            {
                if (item.WalkAble)
                {
                    if (dir == d)
                    {
                        //前
                        DirSave.Instance().SaveDirToFile(DirSave.EDIR.eUp);
                    }
                    else if (dir == new Vector2Int(-d.x, -d.y))
                    {
                        //后
                        DirSave.Instance().SaveDirToFile(DirSave.EDIR.eDown);
                    }
                    else
                    {
                        if (Cross(dir, d) == 1)
                        {
                            //left
                            DirSave.Instance().SaveDirToFile(DirSave.EDIR.eLeft);
                        }

                        else if (Cross(dir, d) == -1)
                        {
                            //right
                            DirSave.Instance().SaveDirToFile(DirSave.EDIR.eRight);
                        }
                        else
                        {
                            //bug
                            DirSave.Instance().SaveDirToFile(DirSave.EDIR.eNone);
                        }
                    }

                    dir = d;
                    _cube.ObjAbove = null;

                    _cube = item;
                    _cube.ObjAbove = this;
                    this.transform.position = _cube.transform.position;
                    return;

                }
                else
                {
                    //撞墙
                }
            }
        }
        return;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            move(new Vector2Int(0, 1));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            move(new Vector2Int(-1, 0));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            move(new Vector2Int(0, -1));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            move(new Vector2Int(1, 0));
        }

    }
}
