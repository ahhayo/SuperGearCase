using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.CarParts
{
    [CreateAssetMenu(fileName = "New Car", menuName = "New Car")]
    public class CarTemplate : ScriptableObject
    {
        public string CarName;
        public GameObject CarPrefab;

        public AnimationCurve BrakeEffectivenessPerSpeedCurve;


        public List<Gear> Gears = new List<Gear>();
        public float MaxSpeed = 250;
        public float MaxRPM = 10000;
    }
}
