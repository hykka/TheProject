using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheat : MonoBehaviour
{



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) {
            Destroy(this.gameObject);
        }
        if (Input.GetKeyDown("r")) {
            GameObject.Find("DataManager").GetComponent<YsoCorp.DataManager>().reset();
        }
    }
}
