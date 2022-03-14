using UnityEngine;
using TMPro;
using System;
using System.Diagnostics;
using UnityEngine.UI;

namespace Assets.Scripts.UIInteractions
{
    public class UIManager : MonoBehaviour
    {
        public SpeedoMeter SpeedoMeter;
        public RPMMeter RPMMeter;

        public TextMeshProUGUI counterText;
        public TextMeshProUGUI RaceTimeText;
        public TextMeshProUGUI GearText;
        public LeaderBoardUI LeaderBoardUI;
        public Stopwatch raceTimer = new Stopwatch();
        public Button CarLightsButton;
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

        private void LateUpdate()
        {
            TimeSpan ts = raceTimer.Elapsed;
            RaceTimeText.text = ts.ToString("mm\\:ss\\:f");
        }
    }
}
