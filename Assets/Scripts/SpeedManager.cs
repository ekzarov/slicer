using UnityEngine;

public class SpeedManager : MonoBehaviour {

    public float speed = 2f;

    private Vector3 randomRotation;
    private bool stopped = false;

    public void Accelerate() {
        stopped = true;
    }

    public void Deaccelerate() {
        stopped = true;
    }
}