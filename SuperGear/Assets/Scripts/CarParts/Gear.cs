using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.CarParts
{
    [Serializable]
    public class Gear
    {
        public AnimationCurve GearCurve;
        public AnimationCurve GearRPMCurve;

        public float AutoGearUpRPM = 6750;
        public float AutoGearDownRPM = 1750;
    }
}
