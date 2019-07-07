using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_zombie : Obj_Char
{
    public Vector2Int dir;
    public int indix;
    public WayHelper helper;

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
    public void zombieMove(int idx)
    {
        bool flag = true;
        if (idx > DirSave.Instance().Data.Count - 1)
        {
            Debug.LogError("GG");
            return;

        }

        string str = DirSave.Instance().Data[idx];


        //向前走
        if (Convert.ToInt32(str) == DirSave.EDIR.eUp.GetHashCode())
        {
            flag = move(dir);
            Debug.Log(dir);
        }
        //backword
        else if (Convert.ToInt32(str) == DirSave.EDIR.eDown.GetHashCode())
        {
            flag = move(new Vector2Int(-dir.x, -dir.y));
            Debug.Log(new Vector2Int(-dir.x, -dir.y));

        }
        //right
        if (Convert.ToInt32(str) == DirSave.EDIR.eRight.GetHashCode())
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
            flag = move(d);
            Debug.Log(d);
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
            flag = move(d);
            Debug.Log(d);

        }
        if (flag==false)
        {
            Debug.LogError("GameOver");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.tag = "Zombie";
        //zombieMove();
        indix = 0;
        helper.showWay();

    }
    public bool move(Vector2Int d)
    {
        var des = d + _cube.Pos;
        foreach (var item in MapMgr.Instance.CubeList)
        {
            if (item.Pos == des)
            {
                if (item.WalkAble)
                {
                    dir = d;
                    _cube.ObjAbove = null;

                    _cube = item;
                    _cube.ObjAbove = this;
                    this.transform.position = _cube.transform.position;
                    return true;

                }
                else
                {
                    Debug.LogError("GG");
                    //撞墙
                    return false;
                }
            }
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&MapMgr.Instance.canMove)
        {
            zombieMove(indix++);
            helper.showWay();
        }
    }
}
