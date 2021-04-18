using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YsoCorp;

public class ManBehavior : MonoBehaviour
{
    public Transform spine;
    public GameObject toSpawn;
    private Animator _animator;

    private bool _turning = false;
    private int _stackToReach = 0;
    private float _bodyInterval = 0.0f;
    public float playerBackOffset = -0.50f;

    void Awake() {
        this._animator = this.GetComponentInChildren<Animator>();
    }
    void Start()
    {
        
    }

    void FixedUpdate()
    {

        if (this._animator?.GetBool("Climbing") == true) {
            if (spine.transform.position.y >= (this._bodyInterval * _stackToReach)) {
                Debug.Log("Spine: " + spine.transform.position.y);
                Debug.Log("ToReach: " + (this._bodyInterval * _stackToReach).ToString());
                this._animator?.SetBool("Stop", true);
                EndClimbing();
            } else {
                transform.position = Vector3.Lerp(transform.position, spine.position, 1f);
            }
        }
    }


    public void EndClimbing() {
        GameObject stackMan = Instantiate(toSpawn, this.transform);
        stackMan.transform.parent = this.transform.parent;
        stackMan.transform.rotation = this.transform.parent.rotation;
        stackMan.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 0.05f);
        this.transform.parent.GetComponent<Player>().addStackMan(stackMan);
        Destroy(this.gameObject, 0.0f);
    }

    public void PlayerownMan(Transform player, int stackSize, float BodyInterval) {
        this.GetComponentInChildren<CapsuleCollider>().enabled = false;
        this.transform.parent = player;
        this._stackToReach = stackSize + 1;
        this._bodyInterval = BodyInterval;


        this.transform.position = new Vector3(player.position.x, player.position.y, player.position.z - this.playerBackOffset);
    }

    public void activate() {
        this._turning = true;
        this._animator?.SetBool("Waiting", false);
        this._animator?.SetBool("Climbing", true);
        this._animator?.Play("turn");
    }
}
