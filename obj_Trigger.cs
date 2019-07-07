using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obj_Trigger : Obj_Char
{

    public Animator A;
    [Header("点击触发按钮")]
    public bool tri;
    [Header("旋转中心块")]
    public MapCube _center;
    [HideInInspector]
    public List<MapCube> _cubes;
    private GameObject ffff;
    [Header("旋转半径")]
    public int radius;
    [HideInInspector]
    public bool isRotating;
    [HideInInspector]
    public bool isMovingUp;
    [HideInInspector]
    public bool isMovingDown;
    float startTime;
    float moveTime;

    public enum angle
    {
        cw,
        acw
    }
    [Header("旋转方向")]
    public angle _angle;
    //获得所有的cube
    public void getAllCubes()
    {
        _cubes.Clear();
        for (int i = -radius; i <= radius; i++)
        {
            for (int j = -radius; j <= radius; j++)
            {
                foreach (var item in MapMgr.Instance.CubeList)
                {
                    if (_center.Pos + new Vector2Int(i, j) == item.Pos)
                    {
                        _cubes.Add(item);
                    }

                }
            }
        }
    }

    public void Start()
    {

        ffff = new GameObject();

    }
    public void Update()
    {

        if ((Input.GetKeyDown(KeyCode.Y) || tri))
        {
            tri = false;
            if (MapMgr.Instance.canMove && !isRotating)
            {
                startRoutation();
                A.Play("switch");
            }

        }


        if (isRotating)
        {
            if (isMovingUp)
            {
                ffff.transform.position = Vector3.Lerp(ffff.transform.position, ffff.transform.up * 3 + new Vector3(ffff.transform.position.x, 0, ffff.transform.position.z), 0.01f);
                if (Time.time - moveTime > 1)
                {
                    isMovingUp = false;
                    startTime = Time.time;
                }
            }
            else if (isMovingDown)
            {
                ffff.transform.position = Vector3.Lerp(ffff.transform.position, -ffff.transform.up + new Vector3(ffff.transform.position.x, 0, ffff.transform.position.z), 0.01f);
                if (Mathf.Abs(ffff.transform.position.y - MapMgr.Instance.transform.position.y) < 0.01f)
                {
                    MapMgr.Instance.Init();
                    ffff.gameObject.transform.DetachChildren();
                    isMovingDown = false;
                    isRotating = false;
                    MapMgr.Instance.canMove = true;
                }
            }
            else
            {
                if (_angle == angle.cw)
                {
                    ffff.transform.rotation = Quaternion.Lerp(ffff.transform.rotation, Quaternion.FromToRotation(Vector3.forward, Vector3.right), Mathf.Clamp01((Time.time - startTime) / 15));
                    if (Quaternion.Angle(ffff.transform.rotation, Quaternion.FromToRotation(Vector3.forward, Vector3.right)) < 0.01f)
                        endRoutation();
                }
                if (_angle == angle.acw)
                {
                    ffff.transform.rotation = Quaternion.Lerp(ffff.transform.rotation, Quaternion.FromToRotation(Vector3.forward, -Vector3.right), Mathf.Clamp01((Time.time - startTime) / 15));
                    if (Quaternion.Angle(ffff.transform.rotation, Quaternion.FromToRotation(Vector3.forward, -Vector3.right)) < 0.01f)
                        endRoutation();
                }
            }


        }


    }

    //once
    public void startRoutation()
    {
        MapMgr.Instance.canMove = false;
        getAllCubes();
        if (_angle == angle.acw)
            AcwRotationBlocks();
        else
            CwRotationBlocks();
        isRotating = true;

        isMovingUp = true;
        moveTime = Time.time;
        isMovingDown = false;
        ffff.transform.position = _center.transform.position;
        ffff.transform.rotation = new Quaternion();
        foreach (var item in _cubes)
        {
            item.gameObject.transform.SetParent(ffff.transform);
            if (item.ObjAbove != null)
                item.ObjAbove.gameObject.transform.SetParent(ffff.transform);
        }
    }

    public void endRoutation()
    {

        isMovingDown = true;
        //moveTime = Time.time;


    }



    private Vector2Int CWR(Vector2Int vec)
    {
        int x = (vec.y - _center.Pos.y);
        int y = -(vec.x - _center.Pos.x);

        return new Vector2Int(x + _center.Pos.x, y + _center.Pos.y);
    }


    private Vector2Int ACWR(Vector2Int vec)
    {
        int x = -(vec.y - _center.Pos.y);
        int y = (vec.x - _center.Pos.x);

        return new Vector2Int(x + _center.Pos.x, y + _center.Pos.y);
    }
    private Vector2Int CWRP(Vector2Int vec)
    {
        int x = (vec.y);
        int y = -(vec.x);

        return new Vector2Int(x, y);
    }


    private Vector2Int ACWRP(Vector2Int vec)
    {
        int x = -(vec.y);
        int y = (vec.x);

        return new Vector2Int(x, y);
    }
    //NewX = X * Cos(α） -Y * Sin(α)

    //NewY = X * Sin(α) + Y * Cos(α)

    public void CwRotationBlocks()
    {
        foreach (var item in _cubes)
        {
            item.Pos = CWR(item.Pos);
            if (item.ObjAbove != null && item.ObjAbove.tag == "Player")
            {
                Vector2Int pos = item.ObjAbove.GetComponent<Obj_Player>().dir;
                item.ObjAbove.GetComponent<Obj_Player>().dir = CWRP(pos);
            }
            if (item.ObjAbove != null && item.ObjAbove.tag == "Zombie")
            {

                Vector2Int pos1 = item.ObjAbove.GetComponent<Obj_zombie>().dir;
                item.ObjAbove.GetComponent<Obj_zombie>().dir = CWRP(pos1);
                item.ObjAbove.GetComponent<Obj_zombie>().helper.showWay();

            }
            //int x =  (item.Pos.y-_center.Pos.y);
            //int y = -(item.Pos.x - _center.Pos.x);

            //item.Pos = new Vector2Int(x + _center.Pos.x, y + _center.Pos.y);
        }
    }

    public void AcwRotationBlocks()
    {
        foreach (var item in _cubes)
        {
            item.Pos = ACWR(item.Pos);
            if (item.ObjAbove != null && item.ObjAbove.tag == "Player")
            {
                Vector2Int pos = item.ObjAbove.GetComponent<Obj_Player>().dir;
                item.ObjAbove.GetComponent<Obj_Player>().dir = ACWRP(pos);
            }
            if (item.ObjAbove != null && item.ObjAbove.tag == "Zombie")
            {

                Vector2Int pos1 = item.ObjAbove.GetComponent<Obj_zombie>().dir;
                item.ObjAbove.GetComponent<Obj_zombie>().dir = ACWRP(pos1);
                item.ObjAbove.GetComponent<Obj_zombie>().helper.showWay();

            }
            Debug.Log("end");
            //int x = -(item.Pos.y - _center.Pos.y);
            //int y = (item.Pos.x - _center.Pos.x);
            //item.Pos = new Vector2Int(x + _center.Pos.x, y + _center.Pos.y);

        }
    }




    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
        if (other.transform.tag == "Player" || other.transform.tag == "Zombie")
        {
            tri = true;

        }

    }
}
