using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.CarParts
{
    [CreateAssetMenu(fileName = "New Car", menuName = "New Car")]
    public class CarTemplate : ScriptableObject
    {
        public string CarName;
        public GameObject CarPrefab;
        public AudioClip EngineSound;
        public AnimationCurve BrakeCurve;


        public List<GearTemplate> Gears = new List<GearTemplate>();
        public float MaxSpeed = 250;
        public float MaxRPM = 10000;
        public float WheelRadius = 2f;
    }
}
