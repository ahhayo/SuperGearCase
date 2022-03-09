using System;
using UnityEngine;

namespace Assets.Scripts.CarParts
{
    [RequireComponent(typeof(Engine), typeof(Gear),typeof(Exhaust))]
    public class Car : MonoBehaviour
    {

        [Header("Car Essentials")]
        public CarTemplate CarTemplate;
        public Engine engine;
        public Gear gear;
        public Exhaust exhaust;
        private Wheel[] wheels;//also required but works different.

        [Header("Car Parameters")]
        [SerializeField] private float currentSpeed;
        public float CurrentSpeed
        {
            get => currentSpeed; set
            {
                currentSpeed = value;
            }
        }

        [SerializeField] private float currentRPM;
        public float CurrentRPM
        { get => currentRPM; 
            set 
            { currentRPM = value; }
        }
        [HideInInspector] public bool canMove = false;

        [Header("Basic Actions")]
        public Action GearChanged;
        public Action Braking;

        private void AllowCarToMove()
        {
            canMove = true;
            //Camera.main.transform.SetParent(CarObject.transform);
        }

        private void Start()
        {
            GameManager.instance.cameraController.FollowAndLookat(transform);
            wheels = GetComponentsInChildren<Wheel>();
            GameManager.instance.Race.RaceBegan += AllowCarToMove;
        }




    }
}
