using UnityEngine;

namespace Assets.Scripts.CarParts
{
    [RequireComponent(typeof(AudioSource))]
    public class Engine : MonoBehaviour
    {
        public Car Car;
        private AudioSource EngineAudioSource;
        [Range(-3,0)]
        [SerializeField] private float minPitch=0;
        [Range(0,3)]
        [SerializeField] private float maxPitch=3;

        private void Start()
        {
            if (!Car)
                Car = GetComponent<Car>();

            if (!EngineAudioSource)
                EngineAudioSource = GetComponent<AudioSource>();
            EngineAudioSource.loop = true;
            EngineAudioSource.clip = Car.CarTemplate.EngineSound;
            EngineAudioSource.Play();
        }
        private void FixedUpdate()
        {
            if (Car.canMove)
                Car.transform.position = Car.transform.position + Vector3.forward * Car.CurrentSpeed * Time.deltaTime;

            EngineSoundControl();
        }

        private void EngineSoundControl() //TODO: rpm 0 oldugu durumu hesapla.
        {
            var rat =  (Car.CurrentRPM / Car.CarTemplate.MaxRPM); //current rpm ratio-> between 0-1
            if (rat == 0)
                rat = 0.01f;
            var pitchValue = minPitch + ((maxPitch - minPitch) * rat);//rpm ratio to pitch ratio.
            EngineAudioSource.pitch = pitchValue;
        }
    }
}
