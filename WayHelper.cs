using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayHelper : Obj_Char
{
    public Obj_zombie zom;
    public GameObject helperPrefab;
    public Vector2Int dir;
    [HideInInspector]
    public int indix;
    public void showWay()
    {
        foreach (var item in gameObject.GetComponentsInChildren<Transform>())
        {
            if (item != transform)
                Destroy(item.gameObject);
        }
        indix = zom.indix;
        dir = zom.dir;
        _cube = zom._cube;
        while (indix < DirSave.Instance().Data.Count )
        {
            zombieMove(indix++);
        }



    }
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
            return;

        string str = DirSave.Instance().Data[idx];


        //向前走
        if (Convert.ToInt32(str) == DirSave.EDIR.eUp.GetHashCode())
        {
            flag = move(dir);
        }
        //backword
        else if (Convert.ToInt32(str) == DirSave.EDIR.eDown.GetHashCode())
        {
            flag = move(new Vector2Int(-dir.x, -dir.y));
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
        }
        if (flag == false)
        {
            Debug.LogError("HelpOver");
        }
    }
    // Start is called before the first frame update

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
                    //_cube.ObjAbove = null;

                    _cube = item;
                    //_cube.ObjAbove = this;
                    //this.transform.position = _cube.transform.position;
                    GameObject G = Instantiate(helperPrefab, _cube.transform.position, this.transform.rotation, this.transform);
                    return true;

                }
                else
                {
                    Debug.LogError("HelperGG");
                    //撞墙
                    return false;
                }
            }
        }
        return false;
    }


}
