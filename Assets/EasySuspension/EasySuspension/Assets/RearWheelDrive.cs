using System.Collections.Generic;
using UnityEngine;

public class RearWheelDrive : MonoBehaviour
{
    public Swipe swipeControl;
    public GameManager gameManager;
    public float staticSpeedMotorTorque = 1000;

    public Transform MeshL1, MeshR1, MeshL2, MeshR2;
    public WheelCollider L1, R1, L2, R2;

    public float maxAngle = 30;
    public float maxTorque = 300;


    #region AI

    public Transform pathGroup;
    public WheelCollider wheelFL, wheelFR;

    private List<Transform> path;
    private float maxSteer = 15.0f;
    private int currentPathObj;

    #endregion

    public void Start()
    {
        BuildPath();
    }

    private void BuildPath()
    {
        var pathObjs = pathGroup.GetComponentInChildren<Transform>();
        path = new List<Transform>();

        foreach (Transform pathObj in pathObjs)
        {
            if (pathObj != transform)
                path.Add(pathObj);
        }
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
            //angle = 15;
        }
        else if (swipeControl.SwipeRight)
        {
            //angle = -15;
        }
        else if (wheel.transform.localPosition.z > 0)
        {
            //wheel.steerAngle = angle;
        }

        if (doWheel)
        {
            // wheel.motorTorque = staticSpeedMotorTorque;
        }

        RotateMesh(wheel, mesh);
    }
}
