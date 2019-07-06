using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Player : Obj_Char
{
    public Vector2Int dir;

    public int Cross(Vector2Int v1,Vector2Int v2)
    {
        return v1.x * v2.y - v2.x * v1.y;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }
    void move(Vector2Int d)
    {
        var des = d + _cube.Pos;
        foreach (var item in MapMgr.Instance.CubeList)
        {
            if(item.Pos==des)
            {
                if(item.WalkAble)
                {
                    if(dir==d)
                    {
                        //前
                        DirSave.Instance().SaveDirToFile(DirSave.EDIR.eUp);
                    }
                    else if(dir==new Vector2Int(-d.x,-d.y))
                    {
                        //后
                        DirSave.Instance().SaveDirToFile(DirSave.EDIR.eDown);
                    }
                    else
                    {
                        if(Cross(dir, d)==1)
                        {
                            //left
                            DirSave.Instance().SaveDirToFile(DirSave.EDIR.eLeft);
                        }

                        else if(Cross(dir, d) == -1)
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
