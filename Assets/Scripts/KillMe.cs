using UnityEngine;

public class KillMe : MonoBehaviour {

    public float lifetime = 10f;

	void Update () {
        if (lifetime > 0)
        {
            lifetime -= Time.deltaTime;
            if (lifetime <= 0)
            {
                Destruction();
            }
        }

        if (this.transform.position.y <= -10) {
            Destruction();
        }
	}

    void OnCollisionEnter(Collision coll) {
        if (coll.gameObject.tag == "Destroyer") {
            Destruction();
        }
    }

    void Destruction() {
        Destroy(this.gameObject);
    }
}