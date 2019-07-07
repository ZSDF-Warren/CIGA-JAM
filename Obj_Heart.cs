﻿using System.Collections;
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
        }
    }

    private void Update()
    {
        if (tri)
        {
            tri = false;
            Debug.LogError("Win");
        }
    }
}