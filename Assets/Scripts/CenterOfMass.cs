using UnityEngine;

public class CenterOfMass : MonoBehaviour
{
    void Update()
    {
        GetComponent<Rigidbody>().centerOfMass = new Vector3(0, -2, 0);
    }
}