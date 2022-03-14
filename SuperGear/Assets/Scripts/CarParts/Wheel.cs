using UnityEngine;

namespace Assets.Scripts.CarParts
{
    public class Wheel : MonoBehaviour
    {
        public Car Car;
        public WheelType WheelType;
        private float WheelCircumference;

        private void Start()
        {
            WheelCircumference = 2 * Mathf.PI * GameManager.instance.car.CarTemplate.WheelRadius;
            if (!Car)
                Car = GetComponentInParent<Car>();
        }

        private void Update()
        {
            if (Car.canMove)
                RotateWheel();
        }

        private void RotateWheel()
        {
            var rotationPerSecond = GameManager.instance.car.CurrentSpeed / WheelCircumference;
            transform.Rotate((rotationPerSecond) * Time.deltaTime * 100, 0, 0);//*100 because m to cm.
        }
    }

    public enum WheelType
    {
        FrontWheel,
        RearWheel
    }

}
