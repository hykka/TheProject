using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterial : MonoBehaviour
{
    private YsoCorp.DataManager data;
    public Material []mat;
    public Material selected;

    void Start()
    {
        data = GameObject.Find("DataManager").GetComponent<YsoCorp.DataManager>();
        int i = 0;
        if (data.getSkint(0) == true && data.getSkint(1) == true)
            i = 2;
        else if (data.getSkint(0) == true || data.getSkint(1) == true)
        {
            i = 1;
        }


        var number = Random.Range(0, i+1);
        SkinnedMeshRenderer meshRenderer = GetComponent<SkinnedMeshRenderer>();
        Debug.Log("number : " +number);
        meshRenderer.material = mat[number];
        selected = mat[number];
    }
}
