using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float rotateSpeed;
    public bool x;
    public bool y;
    public bool z;

    // Update is called once per frame
    void Update()
    {
        if (x) {
            transform.Rotate(rotateSpeed, 0, 0, Space.World);
        }
        if (y) {
            transform.Rotate(0, rotateSpeed, 0, Space.World);
        }
        if (z) {
            transform.Rotate(0, 0, rotateSpeed, Space.World);
        }
        
    }
}
