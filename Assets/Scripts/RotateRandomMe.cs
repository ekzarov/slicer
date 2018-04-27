using UnityEngine;

public class RotateRandomMe : MonoBehaviour {

    public float speed = 2f;

    private Vector3 randomRotation;
    private bool stopped = false;

    void Start()
    {
        randomRotation = Random.rotation.eulerAngles;
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