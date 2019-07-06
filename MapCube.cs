using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCube : MonoBehaviour
{
    public Vector2Int Pos;
    public bool WalkAble;
    public Obj_Char ObjAbove;

    public void Init()
    {
        if (ObjAbove != null)
            ObjAbove.gameObject.transform.position = this.transform.position;
    }

}
