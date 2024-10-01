using System;
using NWH.Common.Vehicles;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace NWH.WheelController3D
{
    [DefaultExecutionOrder(60)]
    public class WheelControllerManager : MonoBehaviour
    {
        private List<WheelUAPI> _wheels = new List<WheelUAPI>();
        private int _wheelCount;

        private void Awake()
        {
            _wheels = new List<WheelUAPI>();
            _wheelCount = 0;
        }

        private void FixedUpdate()
        {
            bool requiresWake = false;
            for (int i = 0; i < _wheels.Count; i++)
            {
                float motorTorque = _wheels[i].MotorTorque;
                if (motorTorque > Vehicle.KINDA_SMALL_NUMBER || motorTorque < -Vehicle.KINDA_SMALL_NUMBER)
                {
                    requiresWake = true;
                    break;
                }
            }

            if (requiresWake) 
            {
                WakeAllWheels();
            }
        }

        public void WakeAllWheels()
        {
            for (int i = 0; i < _wheels.Count; i++)
            {
                _wheels[i].WakeFromSleep();
            }
        }

        public void Register(WheelUAPI wheel)
        {
            if (!_wheels.Contains(wheel))
            {
                _wheels.Add(wheel);
                _wheelCount++;
            }
        }

        public void Deregister(WheelUAPI wheel)
        {
            if (_wheels.Contains(wheel))
            {
                _wheels.Remove(wheel);
                _wheelCount--;
            }
        }
    }
}
