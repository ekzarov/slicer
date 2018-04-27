using UnityEngine;

public class RotateSimpleMe : MonoBehaviour {

    public float speed = 2f;

    private Vector3 randomRotation;
    private bool stopped = false;

    void Start()
    {
        randomRotation = Vector3.up;
    }

	// Update is called once per frame
	void Update () {
        if (stopped) {
            return;
        }

        transform.Rotate(randomRotation * Time.deltaTime, speed);
	}

    public void Stop() {
        stopped = true;
    }
}