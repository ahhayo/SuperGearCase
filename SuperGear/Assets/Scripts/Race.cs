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
            set
            {
                raceStarted = value;
                RaceBegan?.Invoke();
            }
        }
        public Action RaceBegan;
        public Action RaceEnd;
        private bool raceEnd;

        public bool RaceEnded
        {
            get { return raceEnd; }
            set
            {
                raceEnd = value;
                RaceEnd?.Invoke();
                Time.timeScale = 0;
            }
        }



        public Stopwatch CounterStopWatch = new Stopwatch();
        public int CountdownAmount = 5;


        public IEnumerator RaceBeginCounter()
        {
            CounterStopWatch.Restart();
            while (CountdownAmount - CounterStopWatch.Elapsed.Seconds > 0)
            {
                GameManager.instance.UIManager.counterText.text = (CountdownAmount - CounterStopWatch.Elapsed.Seconds).ToString();
                yield return null;
            }

            GameManager.instance.UIManager.counterText.text = "Başla!";
            yield return new WaitForSeconds(1f);
            GameManager.instance.UIManager.counterText.gameObject.SetActive(false);
            RaceStarted = true;
        }


        public void StartRace()
        {
            StartCoroutine(RaceBeginCounter());
        }

    }
}
