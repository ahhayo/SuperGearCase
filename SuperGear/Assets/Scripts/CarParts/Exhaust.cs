using UnityEngine;
using UnityEngine.VFX;

namespace Assets.Scripts.CarParts
{
    public class Exhaust : MonoBehaviour
    {

        private Car car;
        public VisualEffect visualEffect;
        private int MaxSpawnRate = 256;

        private void Start()
        {
            car = GameManager.instance.car;
        }


        private void SetExhaustDensity()
        {
            var perc = Mathf.FloorToInt(((car.CurrentSpeed / car.CarTemplate.MaxSpeed) * MaxSpawnRate)) + 20;
            visualEffect.SetInt("SpawnRate", perc);
        }

        private void SetExhaustColor()
        {
            var perc = 1 - (car.CurrentRPM / car.CarTemplate.MaxRPM);
            var newColor = new Vector4(perc, perc, perc, perc);
            visualEffect.SetVector4("ExhaustColor", newColor);
        }

        private void SetExhaustSpeed()
        {
            var perc = -Mathf.FloorToInt(car.CurrentSpeed / car.CarTemplate.MaxSpeed);
            visualEffect.SetFloat("ExhaustMoveDirAndSpeed", -1 + perc);//-1is default val.
        }


        private void Update()
        {
            SetExhaustDensity();
            SetExhaustColor();
            SetExhaustSpeed();
        }

    }
}
