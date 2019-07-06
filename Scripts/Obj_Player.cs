using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Player : MonoBehaviour
{
    public MapCube _cube;
    public Vector2Int dir;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void move(Vector2Int d)
    {
        var des=_cube.Pos
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {

            dir = new Vector2Int(1, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            dir = new Vector2Int(-1, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            dir = new Vector2Int(0, -1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            dir = new Vector2Int(0, 1);
        }
    }
}
