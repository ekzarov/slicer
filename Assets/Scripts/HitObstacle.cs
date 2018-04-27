using UnityEngine;

public class HitObstacle : MonoBehaviour {

    public float hitForce = 1000f;
    private Vector3 velocity = Vector3.up;

    void OnCollisionEnter(Collision coll) {
        //if (coll.gameObject.tag == "Obstacle") {
        //    coll.gameObject.GetComponent<Rigidbody>().AddForce(velocity * hitForce, ForceMode.VelocityChange);
        //}
    }
}