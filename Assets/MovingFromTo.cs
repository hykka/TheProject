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
        transform.position = Vector3.Lerp(initPos.transform.position, destPos.transform.position, time);
        if (time >= TimeToReach) {
            invert();
        }
    }
}
