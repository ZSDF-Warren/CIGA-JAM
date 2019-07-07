using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Triangle : Obj_Char
{
    [Header("一键切关")]
    public bool tri;
    private void Start()
    {
        this.gameObject.SetActive(!ScenesManager.Instance().isPowerOn);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
        if (other.transform.tag == "Player" || other.transform.tag == "Zombie")
        {
            tri = true;
        }
    }

    private void Update()
    {
        if (tri)
        {
            tri = false;
            ScenesManager.Instance().SceneLoad();
            Debug.LogError("二周目开始");
        }
    }
}
