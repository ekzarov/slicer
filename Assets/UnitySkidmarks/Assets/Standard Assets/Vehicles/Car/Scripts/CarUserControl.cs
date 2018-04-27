using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        public float autoSpeed = 0;
        public float acceleration = 1.5f;

        private CarController m_Car; // the car controller we want to use

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = Input.GetAxis("Horizontal");
            float v = autoSpeed > 0 ? autoSpeed : Input.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = Input.GetAxis("Jump");
            m_Car.Move(h, v * acceleration, v, handbrake);
#else
            m_Car.Move(h, v * acceleration, v, 0f, acceleration);
#endif
        }
    }
}
