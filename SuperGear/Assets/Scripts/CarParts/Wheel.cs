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
            //Tekerin dönüş açısı += 360 * (Son frame de aracın gittiği mesafe) / (tekerin çevresinin uzunluğu)
            var distancePerFrame = Car.CurrentSpeed * Time.deltaTime;
            var rotationAmount = 360 * distancePerFrame / WheelCircumference;
            transform.Rotate(new Vector3(rotationAmount, 0, 0));
        }
    }

    public enum WheelType
    {
        FrontWheel,
        RearWheel
    }

}
