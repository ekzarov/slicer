using UnityEngine;
using System.Collections;

public class RearWheelDrive : MonoBehaviour
{
    public Swipe swipeControl;
    public GameManager gameManager;
    public float staticSpeedMotorTorque = 1000;

    public Transform MeshL1, MeshR1, MeshL2, MeshR2;
    public WheelCollider L1, R1, L2, R2;

    // private WheelCollider[] wheels;

    public float maxAngle = 30;
    public float maxTorque = 300;
    // public GameObject wheelShape;

    // here we find all the WheelColliders down in the hierarchy
    public void Start()
    {
        // wheels = GetComponentsInChildren<WheelCollider>();

        //for (int i = 0; i < wheels.Length; ++i)
        //{
        //    var wheel = wheels[i];

        // create wheel shapes only when needed
        // if (wheelShape != null)
        // {
        //var ws = GameObject.Instantiate(wheelShape);
        //ws.transform.parent = wheel.transform;

        //if (wheel.transform.localPosition.x < 0f)
        //{
        //    ws.transform.localScale = new Vector3(ws.transform.localScale.x * -1, ws.transform.localScale.y, ws.transform.localScale.z);
        //}
        // }
        //}
    }

    // this is a really simple approach to updating wheels
    // here we simulate a rear wheel drive car and assume that the car is perfectly symmetric at local zero
    // this helps us to figure our which wheels are front ones and which are rear
    public void Update()
    {
        float angle = maxAngle * Input.GetAxis("Horizontal");
        float torque = maxTorque * Input.GetAxis("Vertical");

        // foreach (WheelCollider wheel in wheels)
        // {
        // Wheel(L1, angle);
        Wheel(L1, MeshL1, angle);
        Wheel(R1, MeshR1, angle);
        Wheel(L2, MeshL2, angle, false);
        Wheel(R2, MeshR2, angle, false);
        // }
    }

    private void RotateMesh(WheelCollider collider, Transform mesh)
    {
         mesh.localEulerAngles = new Vector3(mesh.localEulerAngles.x, L1.steerAngle - mesh.localEulerAngles.z, mesh.localEulerAngles.z);
         // frWheel.localEulerAngles = new Vector3(frWheel.localEulerAngles.x, frWheelCollider.steerAngle - frWheel.localEulerAngles.z, frWheel.localEulerAngles.z);
 
         mesh.Rotate(collider.rpm / 60 * 360 * Time.deltaTime, 0, 0);
         //frWheel.Rotate(frWheelCollider.rpm / 60 * 360 * Time.deltaTime, 0, 0);
         //rlWheel.Rotate(rlWheelCollider.rpm / 60 * 360 * Time.deltaTime, 0, 0);
         //rrWheel.Rotate(rrWheelCollider.rpm / 60 * 360 * Time.deltaTime, 0, 0);
    }

    private void Wheel(WheelCollider wheel, Transform mesh, float angle, bool doWheel = true)
    {
        if (swipeControl.SwipeLeft)
        {
            angle = 15;
        }
        else if (swipeControl.SwipeRight)
        {
            angle = -15;
        }

        // a simple car where front wheels steer while rear ones drive
        if (wheel.transform.localPosition.z > 0 || swipeControl.SwipeLeft || swipeControl.SwipeRight)
        {
            wheel.steerAngle = angle;
        }

        //if (wheel.transform.localPosition.z < 0)
        //{
        // wheel.motorTorque = torque;
        if (doWheel)
        {
            wheel.motorTorque = staticSpeedMotorTorque;
        }
        // }

        // update visual wheels if any
        //Quaternion q;
        //Vector3 p;
        //wheel.GetWorldPose(out p, out q);

        //// assume that the only child of the wheelcollider is the wheel shape
        //Transform shapeTransform = wheel.transform.GetChild(0);
        //shapeTransform.position = p;
        //shapeTransform.rotation = q;

        RotateMesh(wheel, mesh);


        // Skids

        // gameManager.Skid();

        //WheelHit wheelHitInfo;
        //if (wheel.GetGroundHit(out wheelHitInfo))
        //{
        //    // Check sideways speed
        //    // Gives velocity with +Z being our forward axis

        //    Vector3 localVelocity = transform.InverseTransformDirection(rigidbody.velocity);
        //    float skidSpeed = Mathf.Abs(localVelocity.x);
        //    if (skidSpeed >= SKID_FX_SPEED)
        //    {
        //        // MAX_SKID_INTENSITY as a constant, m/s where skids are at full intensity
        //        float intensity = Mathf.Clamp01(skidSpeed / MAX_SKID_INTENSITY);
        //        Vector3 skidPoint = wheelHitInfo.point + (rigidbody.velocity * Time.fixedDeltaTime);
        //        lastSkid = Skidmarks.AddSkidMark(skidPoint, wheelHitInfo.normal, intensity, lastSkid);
        //    }
        //    else
        //    {
        //        lastSkid = -1;
        //    }
        //}
    }
}
