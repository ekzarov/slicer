using UnityEngine;
using UnityEngine.UI;

public class Speed : MonoBehaviour {

    public Transform player;

    void Update()
    {
        var vel = player.GetComponent<Rigidbody>().velocity;      //to get a Vector3 representation of the velocity
        var speed = vel.magnitude; 

        AnalogueSpeedConverter.ShowSpeed(speed, 0, 100);
    }
}
