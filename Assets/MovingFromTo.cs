using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFromTo : MonoBehaviour
{
    public Transform initPos;
    public Transform destPos;
    public float TimeToReach;

    public bool x;
    public bool y;
    public bool z;
    bool revert;

    private float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = initPos.position;
    }

    private void invert() {
        Debug.Log("INVERT TIME");
        Transform tmp = initPos;
        initPos = destPos;
        destPos = tmp;
        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime / TimeToReach;
        if (!revert) {
            if (x && this.transform.position.x >= destPos.transform.position.x) { revert = true; };
            if (y && this.transform.position.y >= destPos.transform.position.y) { revert = true; };
            if (z && this.transform.position.z >= destPos.transform.position.z) { revert = true; };
            transform.position = Vector3.Lerp(initPos.transform.position, destPos.transform.position, time);
        } else {
            if (x && this.transform.position.x <= initPos.transform.position.x) { revert = false; };
            if (y && this.transform.position.y <= initPos.transform.position.y) { revert = false; };
            if (z && this.transform.position.z <= initPos.transform.position.z) { revert = false; };
            transform.position = Vector3.Lerp(destPos.transform.position, initPos.transform.position, time);
        }
        
       
    }
}
