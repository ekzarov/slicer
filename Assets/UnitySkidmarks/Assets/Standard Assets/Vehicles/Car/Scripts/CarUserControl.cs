using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        public float autoSpeed = 0;
        public float acceleration = 1.01f;

        private CarController m_Car; // the car controller we want to use

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = autoSpeed > 0 ? autoSpeed : Input.GetAxis("Vertical");

#if !MOBILE_INPUT
            float handbrake = Input.GetAxis("Jump");
            m_Car.Move(h, v * acceleration, v, handbrake);
#else
            m_Car.Move(horizontal, vertical, vertical, 0f, vertical > 0 ? acceleration : (float?)null);
#endif
        }
    }
}
