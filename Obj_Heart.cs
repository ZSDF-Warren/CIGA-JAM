using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Heart : Obj_Char
{
    [Header("一键切关")]
    public bool tri;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
        if (other.transform.tag == "Player" || other.transform.tag == "Zombie")
        {
            tri = true;
            //this.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (tri)
        {
            tri = false;
            Debug.LogError("进入下一关");
            //Convert.ToInt32(str)
            string str = ScenesManager.Instance().SceneName;
            int idx = Convert.ToInt32(str) + 1;
            ScenesManager.Instance().SceneLoad(idx);
        }
    }
}
