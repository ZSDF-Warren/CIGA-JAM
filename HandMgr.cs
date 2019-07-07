using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMgr : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //从摄像机发出到点击坐标的射线

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {

            //显示射线，只有在scene视图中才能看到
            Debug.DrawLine(ray.origin, hit.point);
            if(Input.GetMouseButtonDown(0))
            {
                if (hit.transform.tag == "trigger")
                {
                    obj_Trigger t = hit.transform.gameObject.GetComponent<obj_Trigger>();
                    t.tri = true;
                }

            }

        }


    }
}
