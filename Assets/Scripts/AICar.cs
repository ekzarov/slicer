//using System.Collections.Generic;
//using UnityEngine;

//public class AICar : MonoBehaviour {

//    public Transform pathGroup;
//    public WheelCollider wheelFL, wheelFR;

//    private List<Transform> path;
//    private float maxSteer = 15.0f;
//    private int currentPathObj;

//	void Start () {
//        Debug.Log("START");
//        GetPath();
//	}

//    void GetPath()
//    {
//        var pathObjs = pathGroup.GetComponentInChildren<Transform>();
//        path = new List<Transform>();

//        foreach (Transform pathObj in pathObjs)
//        {
//            if (pathObj != transform)
//                path.Add(pathObj);
//        }
//    }
//    void Update () {
//        GetSteer();
//    }

//    void GetSteer(){
//        var steerVector = transform.InverseTransformPoint(new Vector3(path[currentPathObj].position.x, transform.position.y, path[currentPathObj].position.z));
//        var newSteer = maxSteer * (steerVector.x / steerVector.magnitude);
//        wheelFL.steerAngle = newSteer;
//        wheelFR.steerAngle = newSteer;
//    }
//}
