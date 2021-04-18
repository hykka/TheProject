using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YsoCorp;


namespace ManStack {
    public class ManCollision : YCBehaviour {

        private void OnCollisionEnter(Collision collision) {

        }

        private void OnTriggerEnter(Collider collision) {
            if (collision.transform.CompareTag("Man") == true) {
                Player pl = this.GetComponent<Player>();
                collision.transform.GetComponentInParent<ManBehavior>().activate();
                collision.transform.GetComponentInParent<ManBehavior>().PlayerownMan(
                    this.transform, pl.stackSize, pl.BodyInterval);
                pl.stackSize += 1;
            }
        }
    }
}