using System.Linq;
using UnityEngine;

namespace Assets.Scripts.CarParts
{
    public class Gear : MonoBehaviour
    {

        public Car Car;

        [SerializeField] private int gearIndex;
        public int GearIndex
        {
            get { return gearIndex; }
            private set
            {
                gearIndex = value;
                currentGear = Car.CarTemplate.Gears[GearIndex];
                GameManager.instance.UIManager.GearText.text = gearIndex != 0 ? "Gear : " + (gearIndex).ToString() : "Gear : N";
                Car.GearChanged?.Invoke();
            }
        }
        private GearTemplate currentGear;

        private void Start()
        {
            if (!Car)
                Car = GetComponent<Car>();
            currentGear = Car.CarTemplate.Gears.First();

        }
        private void Update()
        {
            Car.CurrentRPM = Mathf.Clamp(currentGear.GearRPMCurve.Evaluate(Car.CurrentSpeed), 0, Car.CarTemplate.MaxRPM);
          
            if (!GameManager.instance.Race.RaceStarted)
                return;
            if (GameManager.instance.Race.RaceEnded)
                UseBrake();

            if (Input.GetKey(KeyCode.W))
                UseGas();
            else if (Input.GetKey(KeyCode.S))
                UseBrake();
            else
            {
                if (Car.CurrentSpeed > 0)
                    Car.CurrentSpeed -= Mathf.Clamp(Car.CarTemplate.BrakeCurve.Evaluate(Car.CurrentSpeed) / 10f, 0, Car.CurrentSpeed);
                else
                    Car.CurrentSpeed = 0;
            }

            if (Input.GetKeyUp(KeyCode.S))
                Car.UsingBrake = false;


            if (!Car.canMove)
            {
                return;
            }

            if (Car.CurrentRPM > currentGear.AutoGearUpRPM && Car.CarTemplate.Gears.Count - 1 != GearIndex)
                GearIndex++;

            if (Car.CurrentRPM < currentGear.AutoGearDownRPM && GearIndex != 0) //simdilik 0dan gerisi yok ama normalde geri vites olmali.
                GearIndex--;


        }
        private void UseGas()
        {
            Car.CurrentSpeed += currentGear.GearCurve.Evaluate(Car.CurrentSpeed) * Time.deltaTime;
        }
        private void UseBrake()
        {
            Car.CurrentSpeed -= Mathf.Clamp(Car.CarTemplate.BrakeCurve.Evaluate(Car.CurrentSpeed), 0, Car.CurrentSpeed);
            Car.UsingBrake = true;
        }
    }
}
