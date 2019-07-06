using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointHelper : MonoBehaviour
{
    public Obj_Player player;
    public GameObject helper;
    public MapCube mCube;
    public Vector2Int dir;





    public bool move(Vector2Int d)
    {
        
        foreach (var item in MapMgr.Instance.CubeList)
        {
            if (item.Pos == d)
            {
                if (item.WalkAble)
                {
                    mCube = item;
                    GameObject h = Instantiate(helper, this.gameObject.transform.position, this.gameObject.transform.rotation, this.gameObject.transform);
                    return true;
                }
                else
                {
                    return false;
                    //撞墙
                }
            }
            return false;
        }
        return false;

    }

    public void ShowWay()
    {
        mCube = player._cube;
        dir = player.dir;
        bool flag = true;
        while (flag)
        {
            GameObject h = Instantiate(helper, this.gameObject.transform.position, this.gameObject.transform.rotation, this.gameObject.transform);

            //遍历
            {
                //向前走
                if (true)
                {
                    move(mCube.Pos + dir);
                }
                //backword
                else if (true)
                {
                    move(mCube.Pos + new Vector2Int(-player.dir.x, -player.dir.y));
                }
                //right
                if (true)
                {
                    var d = player.dir;
                    if (player.dir == new Vector2Int(1, 0))
                    {
                        d = new Vector2Int(0, -1);
                    }
                    if (player.dir == new Vector2Int(0, 1))
                    {
                        d = new Vector2Int(1, 0);
                    }
                    if (player.dir == new Vector2Int(-1, 0))
                    {
                        d = new Vector2Int(0, 1);

                    }
                    if (player.dir == new Vector2Int(0, -1))
                    {
                        d = new Vector2Int(-1, 0);
                    }
                    player.move(mCube.Pos + d);
                }
                //left
                if (true)
                {
                    var d = player.dir;
                    if (player.dir == new Vector2Int(1, 0))
                    {
                        d = new Vector2Int(0, 1);
                    }
                    if (player.dir == new Vector2Int(0, 1))
                    {
                        d = new Vector2Int(-1, 0);
                    }
                    if (player.dir == new Vector2Int(-1, 0))
                    {
                        d = new Vector2Int(0, -1);

                    }
                    if (player.dir == new Vector2Int(0, -1))
                    {
                        d = new Vector2Int(1, 0);
                    }
                    player.move(mCube.Pos + d);
                }
            }
        }
    }
}
