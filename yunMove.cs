using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yunMove : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        this.transform.position += transform.forward * Time.deltaTime * speed;
    }
}
