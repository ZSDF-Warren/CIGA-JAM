using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirSave
{
    private static DirSave _instance;
    public static DirSave Instance()
    {
        if (_instance == null)
            _instance = new DirSave();
        return _instance;
    }

    DirSave() { }

    public enum EDIR
    {
        eNone = -1,
        eUp,
        eDown,
        eLeft,
        eRight,
    }


}
