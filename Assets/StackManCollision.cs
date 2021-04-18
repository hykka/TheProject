using UnityEngine;
using YsoCorp;
public class StackManCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {

    }

    private void OnTriggerEnter(Collider collision) {
        if (collision.transform.CompareTag("Obstacles") == true) {
            Player pl = this.GetComponent<Player>();
            collision.transform.GetComponentInParent<ManBehavior>().activate();
            collision.transform.GetComponentInParent<ManBehavior>().PlayerownMan(
                this.transform, pl.stackSize, pl.BodyInterval);
            pl.stackSize += 1;
        }
    }
}
