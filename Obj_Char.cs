using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Char : MonoBehaviour
{
    [Header("所在块")]
    public MapCube _cube;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    virtual public bool ChangeCube(MapCube cube)
    {
        return false;
    }
}
