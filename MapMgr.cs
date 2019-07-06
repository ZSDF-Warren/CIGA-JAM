using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMgr
{
    private static MapMgr _instance;
    public static MapMgr Instance()
    {
        if (_instance == null)
            _instance = new MapMgr();

        return _instance;
    }

    private MapMgr()
    {
        Init();
    }

    private void Init()
    {

    }

    public List<MapCube> CubeList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
