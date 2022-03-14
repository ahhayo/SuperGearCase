using Cinemachine;
using System;
using UnityEngine;

namespace Assets.Scripts.CarParts
{
    [RequireComponent(typeof(Engine), typeof(Gear), typeof(Exhaust))]
    [RequireComponent(typeof(CarLights))]
    public class Car : MonoBehaviour
    {

        [Header("Car Essentials")]
        [Tooltip("Car Template Is Must.If Others Not Defined, Awake Method Fill Parameters.")]
        public CarTemplate CarTemplate;
        public Engine Engine;
        public Gear Gear;
        public Exhaust Exhaust;
        public CarLights CarLights;
        public Wheel[] Wheels;//also required but works different.
        public CinemachineVirtualCamera EndGameCam;

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
        {
            get => currentRPM;
            set
            { currentRPM = value; }
        }
        [HideInInspector] public bool canMove = false;
        [HideInInspector] public bool UsingBrake=false;
        [Header("Basic Actions")]
        public Action GearChanged;
        
        private void Awake()
        {
            if (!Engine)
                Engine = GetComponent<Engine>();
            if (!Gear)
                Gear = GetComponent<Gear>();
            if (!Exhaust)
                Exhaust = GetComponent<Exhaust>();
            if (Wheels.Length <= 0)
                Wheels = GetComponentsInChildren<Wheel>();
            if (!CarLights)
                CarLights = GetComponent<CarLights>();

        }
        private void Start()
        {
            GameManager.instance.cameraController.FollowAndLookat(transform);
            GameManager.instance.Race.RaceBegan += AllowCarToMove;
            GameManager.instance.Race.RaceEnd += EndGameActions;
        }

        private void EndGameActions()
        {
            GameManager.instance.cameraController.CurrentCam = EndGameCam;
        }

        private void AllowCarToMove()
        {
            canMove = true;
        }


    }
}
