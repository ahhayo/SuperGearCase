using UnityEngine;
using TMPro;
using System;
using System.Diagnostics;

namespace Assets.Scripts.UIInteractions
{
    public class UIManager : MonoBehaviour
    {
        public SpeedoMeter SpeedoMeter;
        public RPMMeter RPMMeter;

        public TextMeshProUGUI counterText;
        public TextMeshProUGUI RaceTimeText;

        private Stopwatch raceTimer = new Stopwatch();
        private void Start()
        {
            GameManager.instance.Race.RaceBegan += OnRaceStarted;
            GameManager.instance.Race.RaceEnd += OnRaceEnded;
        }
        private void OnRaceStarted()
        {
            raceTimer.Start();
        }

        private void OnRaceEnded()
        {
            raceTimer.Stop();
        }

        private void Update()
        {
            RaceTimeText.text = (raceTimer.Elapsed.Minutes).ToString() + " : " +(raceTimer.Elapsed.Seconds).ToString() + " : " + (raceTimer.Elapsed.Milliseconds).ToString();
        }
    }
}
