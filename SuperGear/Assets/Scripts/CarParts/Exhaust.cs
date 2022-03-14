using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace Assets.Scripts.CarParts
{
    public class Exhaust : MonoBehaviour
    {

        public Car Car;
        [SerializeField] List<VisualEffect> visualEffects = new List<VisualEffect>();
        [SerializeField] private int MaxSpawnRate = 128;

        private void Start()
        {
            if (!Car)
                Car = GetComponent<Car>();

        }

        private void SetExhaustDensity()
        {
            var percentage = Car.CurrentSpeed == 0 ? 10 : Mathf.FloorToInt(((Car.CurrentSpeed / Car.CarTemplate.MaxSpeed) * MaxSpawnRate));
            foreach (var visualEffect in visualEffects)
                visualEffect.SetInt("SpawnRate", percentage);
        }

        private void SetExhaustColor()
        {
            var perc = 1 - (Car.CurrentRPM / Car.CarTemplate.MaxRPM);
            var newColor = new Vector4(perc, perc, perc, perc);
            foreach (var visualEffect in visualEffects)
                visualEffect.SetVector4("ExhaustColor", newColor);
        }

        private void SetExhaustSpeed()
        {
            var perc = -Mathf.FloorToInt(Car.CurrentSpeed / Car.CarTemplate.MaxSpeed);
            foreach (var visualEffect in visualEffects)
                visualEffect.SetFloat("ExhaustMoveDirAndSpeed", -1 + perc);//-1is default val.
        }


        private void Update()
        {
            if (visualEffects.Count <= 0)
            {
                this.enabled = false;
                throw new Exception("No Visual Effect Added For Exhaust. Please Add One");
            }

            SetExhaustDensity();
            SetExhaustColor();
            SetExhaustSpeed();
        }

    }
}
