using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnstack : MonoBehaviour
{
    public GameObject Men;
    public GameObject[] spawn;
    private GameObject[] list = new GameObject[100];

    public void Awake() {
        this.transform.parent = null;
    }

    public void initlevel()
    {
        destroySelf();
        for (int i = 0; i < spawn.Length; i++)
        {
            list[i] = Instantiate(Men, spawn[i].transform.position, Quaternion.identity);
        }
    }

    public void destroySelf() {
        for (int i = 0; i < spawn.Length; i++)
        {
            Destroy(list[i]);

        }
    }  
}
