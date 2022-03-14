using UnityEngine;
using TMPro;

namespace Assets.Scripts.UIInteractions
{
    public class SpeedoMeter : MonoBehaviour 
    {
        public bool UseMPH = false;
        public GameObject Cursor;

        [Header("Cursor Min Max Rotations")]
        [SerializeField] private float maxSpeedAngle = -125;
        [SerializeField] private float minSpeedAngle = 125;

        public TextMeshProUGUI SpeedText;
        public TextMeshProUGUI CenterSpeedoMeterText;

        private void Update()
        {
            SetSpeedText();
            SetCursor();
        }

        public virtual void SetSpeedText()
        {
            if (!UseMPH)
            {
                var Txt = Mathf.CeilToInt(GameManager.instance.car.CurrentSpeed).ToString() + " KMH";
                SpeedText.text = Txt;
                CenterSpeedoMeterText.text = Txt;
            }
            else
            {
                var Txt = Mathf.CeilToInt(GameManager.instance.car.CurrentSpeed * 0.62f).ToString() + "MPH";
                SpeedText.text = Txt;
                CenterSpeedoMeterText.text = Txt;
            }

        }

        public virtual void SetCursor()
        {
            var spd = GameManager.instance.car.CurrentSpeed;
            if (GameManager.instance.car.CurrentSpeed > GameManager.instance.car.CarTemplate.MaxSpeed)
                spd = GameManager.instance.car.CarTemplate.MaxSpeed;
            Cursor.transform.localEulerAngles = new Vector3(0, 0, -GetSpeedRotation(spd, GameManager.instance.car.CarTemplate.MaxSpeed));
        }
        /// <summary>
        /// Calculate the Cursor new Position
        /// </summary>
        /// <returns></returns>
        public float GetSpeedRotation(float currentVal, float MaxVal)
        {
            float totalAngleSize = minSpeedAngle - maxSpeedAngle;
            float speedNormalized = currentVal / MaxVal;

            return minSpeedAngle - speedNormalized * totalAngleSize;
        }


    }
}
