using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManAnimationEvent : MonoBehaviour
{
    public void applyRotation() {
        this.GetComponentInParent<Transform>().Rotate(new Vector3(0.0f, 80.0f, 0.0f));
    }

    public void StartClimb() {
        if (this.GetComponent<Animator>().GetBool("Climbing") == true) {
            Transform player = this.transform.parent.parent.transform;
            this.transform.rotation = player.rotation;
            this.transform.position = new Vector3(player.position.x, this.transform.position.y, player.position.z);
        }
    }
}
