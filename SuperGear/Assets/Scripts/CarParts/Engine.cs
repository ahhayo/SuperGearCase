using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.CarParts
{
    [RequireComponent(typeof(AudioSource))]
    public class Engine : MonoBehaviour
    {
        private Car car;
        [SerializeField] private AudioSource EngineSource;

        private void Start()
        {
            car = GameManager.instance.car;
            if (!EngineSource)
                EngineSource = GetComponent<AudioSource>();
            EngineSource.clip = car.CarTemplate.EngineSound;
            EngineSource.Play();
        }
        private void FixedUpdate()
        {
            if (car.canMove)
                car.transform.position = car.transform.position + Vector3.forward * car.CurrentSpeed * Time.deltaTime;

            EngineSoundControl();
        }

        public void EngineSoundControl()
        {
            var val = 1 + (car.CurrentRPM / car.CarTemplate.MaxRPM);
            EngineSource.pitch = val;
        }
    }
}
