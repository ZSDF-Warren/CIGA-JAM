using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCube : MonoBehaviour
{
    [Header("地砖位置")]
    public Vector2Int Pos;
    [Header("能否行走")]
    public bool WalkAble;
    [Header("上面的物体")]
    public Obj_Char ObjAbove;

    public void Init()
    {
        if (ObjAbove != null)
            ObjAbove.gameObject.transform.position = this.transform.position;
    }

}
