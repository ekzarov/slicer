using UnityEngine;

public class AnalogueSpeedConverter : MonoBehaviour {

    static float minAngle = 136.5f;
    static float maxAngle = -134.5f;
    static AnalogueSpeedConverter thisSpeedo;

    void Start() {
        thisSpeedo = this;
    }

    public static void ShowSpeed(float speed, float min, float max)
    {
        float ang = Mathf.Lerp(minAngle, maxAngle, Mathf.InverseLerp(min, max, speed));
        thisSpeedo.transform.eulerAngles = new Vector3(0, 0, ang);
    }
}