using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Scripts
{
    public class Race : MonoBehaviour
    {

        private bool raceStarted = false;

        public bool RaceStarted
        {
            get { return raceStarted; }
            private set
            {
                raceStarted = value;
                RaceBegan?.Invoke();
            }
        }
        public Action RaceBegan;
        public Action RaceEnd;
        public Action<float> CountDownChanged;

        private bool raceEnded;
        public int Score { get { return (int)GameManager.instance.UIManager.raceTimer.Elapsed.TotalMilliseconds; } }

        public bool RaceEnded
        {
            get { return raceEnded; }
            set
            {
                raceEnded = value;
                RaceEnd?.Invoke();
            }
        }


        private Stopwatch CounterStopWatch = new Stopwatch();
        [SerializeField] private int CountdownAmount = 5;

        private void Start()
        {
            RaceEnd += SendDataToLeaderBoard;
        }

        private void SendDataToLeaderBoard()
        {
            GameManager.instance.PlayfabManager.SendLeaderBoard(Score);
        }

        private IEnumerator RaceBeginCounter()
        {
            CounterStopWatch.Restart();
            while (CountdownAmount - CounterStopWatch.Elapsed.Seconds > 0)
            {
                GameManager.instance.UIManager.counterText.text = (CountdownAmount - CounterStopWatch.Elapsed.Seconds).ToString() + "!";
                CountDownChanged?.Invoke((CountdownAmount * 1000f) - (float)CounterStopWatch.Elapsed.TotalMilliseconds);
                yield return null;
            }

            GameManager.instance.UIManager.counterText.text = "GO!";
            yield return new WaitForSeconds(0.25f);
            GameManager.instance.UIManager.counterText.gameObject.SetActive(false);
            RaceStarted = true;
        }


        public void StartRace()
        {
            StartCoroutine(RaceBeginCounter());
        }

    }
}
