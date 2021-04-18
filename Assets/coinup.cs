using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinup : MonoBehaviour
{
    public YsoCorp.DataManager data;
    public GameObject coin;
    private int rotatespeed = 1;
    public AudioSource sound;

    private void Awake() {
        data = GameObject.Find("DataManager").GetComponent<YsoCorp.DataManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        data.addCoin();
        sound.Play();
        GetComponent<MeshRenderer>().enabled = false;
        Destroy(coin, 2f);
    }
    private void Update()
    {
        transform.Rotate(0, rotatespeed, 0, Space.World);
    }
}
