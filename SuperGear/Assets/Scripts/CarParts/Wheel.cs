using UnityEngine;

namespace Assets.Scripts.CarParts
{
    public class Wheel : MonoBehaviour
    {
        public WheelType WheelType;
        private float WheelCircumference;

        private void Start()
        {
            WheelCircumference = 2 * Mathf.PI * GameManager.instance.car.CarTemplate.WheelRadius;
        }

        private void Update()
        {
            if (!GameManager.instance.Race.RaceEnded)
                if (GameManager.instance.car.canMove || WheelType == WheelType.RearWheel)
                    RotateWheel();
        }

        [SerializeField] private float multiplier = 100f;
        public void RotateWheel()
        {
            var rotationPerSecond = GameManager.instance.car.CurrentSpeed / WheelCircumference;
            transform.Rotate((rotationPerSecond) * Time.deltaTime * multiplier, 0, 0);
        }
    }

    public enum WheelType
    {
        FrontWheel,
        RearWheel
    }

}
