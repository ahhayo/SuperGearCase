using UnityEngine;

namespace Assets.Scripts.CarParts
{
    public class Wheel : MonoBehaviour
    {
        public WheelType WheelType;
        private void Update()
        {
            if (!GameManager.instance.Race.RaceEnded)
                if (GameManager.instance.car.canMove || WheelType == WheelType.RearWheel)
                    transform.Rotate(GameManager.instance.car.CurrentSpeed, 0, 0);
        }
    }

    public enum WheelType
    {
        FrontWheel,
        RearWheel
    }

}
