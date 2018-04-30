//using System.Collections;
//using UnityEngine;

//public class Instantiation : MonoBehaviour
//{
//    public float InstantiationTimer = 1f;
//    private float InstantiationTimerInternal;

//    public Rigidbody prefab;
//    public Transform borders;
//    public float spawnOffset = 5f;
//    public Vector3 rotation;
//    public bool rotate;

//    private float border, centerX, centerY;

//    void Start()
//    {
//        InstantiationTimerInternal = InstantiationTimer;

//        centerX = borders.GetComponent<Renderer>().bounds.center.x;
//        centerY = borders.GetComponent<Renderer>().bounds.center.y;
//        border = borders.GetComponent<Renderer>().bounds.max.x;
//    }

//    void Update()
//    {
//        CreatePrefab();
//    }

//    void CreatePrefab()
//    {
//        InstantiationTimerInternal -= Time.deltaTime;
//        if (InstantiationTimerInternal <= 0)
//        {
//            Vector3 rangePosition = new Vector3(Random.Range(-border, border), 0, Random.Range(-border, border));
//            var currentPosition = new Vector3(centerX, transform.position.y, transform.position.z);
//            var newPosition = currentPosition + rangePosition;

//            var result = rotate ? Instantiate(prefab, newPosition, Random.rotation) : Instantiate(prefab);
//            InstantiationTimerInternal = InstantiationTimer;
// s       }
//    }
//}