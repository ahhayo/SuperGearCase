using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.CarParts
{
    public class Car : MonoBehaviour
    {

        public CarTemplate CarTemplate;
        [HideInInspector] public GameObject CarObject;

        [SerializeField] private float currentSpeed;
        public float CurrentSpeed { get => currentSpeed; }

        [SerializeField] private float currentRPM;
        public float CurrentRPM { get => currentRPM; }

        [SerializeField] private int gearIndex;

        public int GearIndex
        {
            get { return gearIndex; }
            set
            {
                gearIndex = value;
                currentGear = CarTemplate.Gears[GearIndex];
                GearChanged?.Invoke();
            }
        }

        private Gear currentGear;

        public Action GearChanged;

        [SerializeField] private float breakEffectiveness;
        public float BreakEffectiveness { get => breakEffectiveness; }

        [HideInInspector] public bool canMove = false;

        private Wheel[] wheels;
        private void Awake()
        {
            CarObject = Instantiate(CarTemplate.CarPrefab, transform);
            CarObject.transform.position = new Vector3(0, -1.75f, 7);//just for editor. 
            wheels = CarObject.GetComponentsInChildren<Wheel>();

            currentGear = CarTemplate.Gears.First();

        }

        private void AllowCarToMove()
        {
            canMove = true;
            Camera.main.transform.SetParent(CarObject.transform);
        }

        private void Start()
        {
            GameManager.instance.Race.RaceBegan += AllowCarToMove;
            GameManager.instance.cameraController.target = CarObject.transform;
        }

        private void Update()
        {

            if (CarObject.transform.localPosition.z >= 3000)
                if (!GameManager.instance.Race.RaceEnded)
                    GameManager.instance.Race.RaceEnded = true;

            if (Input.GetKey(KeyCode.W))
            {
                currentSpeed += currentGear.GearCurve.Evaluate(currentSpeed) * Time.deltaTime;
                //currentRPM = currentGear.GearRPMCurve.Evaluate(currentSpeed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                var breakEffectiveness = CarTemplate.BrakeEffectivenessPerSpeedCurve.Evaluate(currentSpeed);
                var multiplayer = currentSpeed > 0 ? 5 : 1;
                currentSpeed -= Mathf.Clamp(currentGear.GearCurve.Evaluate(currentSpeed) * breakEffectiveness * multiplayer * Time.deltaTime, 0, 999);
            }
            else
            {
                if (currentSpeed > 0)
                    currentSpeed -= Mathf.Clamp(currentGear.GearCurve.Evaluate(currentSpeed) * 2 * Time.deltaTime, 0, 999);
                else
                    currentSpeed = 0;
            }

            currentRPM = currentGear.GearRPMCurve.Evaluate(currentSpeed);

            if (!canMove)
            {
                return;
            }

            if (currentRPM > currentGear.AutoGearUpRPM && CarTemplate.Gears.Count - 1 != GearIndex)
                GearIndex++;

            if (currentRPM < currentGear.AutoGearDownRPM && GearIndex != 0) //simdilik 0dan gerisi yok ama normalde geri vites olmali.
                GearIndex--;


        }

        private void FixedUpdate()
        {
            if (canMove)
                CarObject.transform.position = CarObject.transform.position + Vector3.forward * currentSpeed * Time.deltaTime;
        }



    }
}
