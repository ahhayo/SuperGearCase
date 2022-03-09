using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.CarParts
{
    public class Gear : MonoBehaviour
    {

        private Car car;

        [SerializeField] private int gearIndex;

        public int GearIndex
        {
            get { return gearIndex; }
            set
            {
                gearIndex = value;
                currentGear = car.CarTemplate.Gears[GearIndex];
                car.GearChanged?.Invoke();
            }
        }
        private GearTemplate currentGear;

        private void Start()
        {
            car = GameManager.instance.car;
            currentGear = car.CarTemplate.Gears.First();

        }
        private void Update()
        {

            if (Input.GetKey(KeyCode.W))
            {
                car.CurrentSpeed+= currentGear.GearCurve.Evaluate(car.CurrentSpeed) * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                car.CurrentSpeed -= Mathf.Clamp(car.CarTemplate.BrakeCurve.Evaluate(car.CurrentSpeed), 0, car.CurrentSpeed);
                //TODO : Fren lambalarini yak;
            }
            else
            {

                //if (currentSpeed > 0)
                //    currentSpeed -= Mathf.Clamp(CarTemplate.BrakeCurve.Evaluate(currentSpeed)/100, 0, currentSpeed);
                //else
                //    currentSpeed = 0;
            }

            car.CurrentRPM = Mathf.Clamp(currentGear.GearRPMCurve.Evaluate(car.CurrentSpeed), 0, car.CarTemplate.MaxRPM);

            if (!car.canMove)
            {
                return;
            }

            if (car.CurrentRPM > currentGear.AutoGearUpRPM && car.CarTemplate.Gears.Count - 1 != GearIndex)
                GearIndex++;

            if (car.CurrentRPM < currentGear.AutoGearDownRPM && GearIndex != 0) //simdilik 0dan gerisi yok ama normalde geri vites olmali.
                GearIndex--;


        }

    }
}
