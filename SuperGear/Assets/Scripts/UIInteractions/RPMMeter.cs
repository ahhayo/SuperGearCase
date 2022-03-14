using UnityEngine;

namespace Assets.Scripts.UIInteractions
{
    public class RPMMeter : SpeedoMeter
    {
        public override void SetCursor()
        {
            var spd = GameManager.instance.car.CurrentRPM;
            if (GameManager.instance.car.CurrentRPM > GameManager.instance.car.CarTemplate.MaxRPM)
                spd = GameManager.instance.car.CarTemplate.MaxRPM;
            Cursor.transform.localRotation = Quaternion.Lerp(Cursor.transform.localRotation,Quaternion.Euler(0, 0, -GetSpeedRotation(spd, GameManager.instance.car.CarTemplate.MaxRPM)), Time.deltaTime * 5);

        }
        public override void SetSpeedText()
        {
            var Txt = " Rpm: " + Mathf.CeilToInt(GameManager.instance.car.CurrentRPM).ToString();
            SpeedText.text = Txt;
            CenterSpeedoMeterText.text = Txt;
        }
    }
}
