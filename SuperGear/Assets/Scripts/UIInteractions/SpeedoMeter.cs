using UnityEngine;
using TMPro;
namespace Assets.Scripts.UIInteractions
{
    public class SpeedoMeter : MonoBehaviour
    {
        public GameObject Cursor;

        [Header("Cursor Min Max Rotations")]
        [SerializeField]private float maxSpeedAngle = -125;
        [SerializeField]private float minSpeedAngle = 125;

        public TextMeshProUGUI SpeedText;

        private void Update()
        {
            SetSpeedText();
            SetCursor();
        }

        public virtual void SetSpeedText()
        {
            SpeedText.text = Mathf.FloorToInt(GameManager.instance.car.CurrentSpeed).ToString();
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
