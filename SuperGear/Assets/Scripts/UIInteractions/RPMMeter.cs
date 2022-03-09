using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Cursor.transform.localRotation = Quaternion.Lerp(Cursor.transform.localRotation,Quaternion.Euler(0, 0, -GetSpeedRotation(spd, GameManager.instance.car.CarTemplate.MaxRPM)), Time.deltaTime);

        }
        public override void SetSpeedText()
        {
            SpeedText.text = "Gear: " + (GameManager.instance.car.gear.GearIndex + 1) + " Rpm: " + Mathf.FloorToInt(GameManager.instance.car.CurrentRPM).ToString();
        }
    }
}
