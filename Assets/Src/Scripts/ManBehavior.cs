using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YsoCorp;

public class ManBehavior : MonoBehaviour
{
    public Transform spine;
    public GameObject toSpawn;
    private Animator _animator;
    public Material color;

    private bool _turning = false;
    private int _stackToReach = 0;
    private float _bodyInterval = 0.0f;

    void Awake() {
        this._animator = this.GetComponentInChildren<Animator>();
    }
    void Start()
    {

    }

    void FixedUpdate()
    {
        if (this._animator?.GetBool("Climbing") == true) {
            EndClimbing();            
            //transform.position = Vector3.Lerp(transform.position, spine.position, 1f);
        }
    }

    public void EndClimbing() {
        color = GetComponentInChildren<RandomMaterial>().selected;
        GameObject stackMan = Instantiate(toSpawn, this.transform);
        stackMan.GetComponent<StackManBehaviour>().changeColor(color);
        stackMan.transform.parent = this.transform.parent;
        Transform spawnRef = this.transform.parent.GetComponent<Player>().SpawnRef.transform;
        stackMan.transform.rotation = new Quaternion(0, 0, 0, 0);//this.transform.parent.rotation;
        stackMan.transform.position = new Vector3(spawnRef.position.x, this.transform.parent.position.y + (0.88f * _stackToReach), spawnRef.position.z);
        this.transform.parent.GetComponent<Player>().addStackMan(stackMan);
        Destroy(this.gameObject, 0.0f);
    }

    public void PlayerownMan(Transform player, int stackSize, float BodyInterval) {
        this.GetComponentInChildren<CapsuleCollider>().enabled = false;
        this.transform.parent = player;
        this._stackToReach = stackSize + 1;
        this._bodyInterval = BodyInterval;

        //this.transform.position = new Vector3(player.position.x, player.position.y, player.position.z - this.playerBackOffset);
    }

    public void activate() {
        this._turning = true;
        this._animator?.SetBool("Waiting", false);
        this._animator?.SetBool("Climbing", true);
        this._animator?.Play("turn");
    }
}
