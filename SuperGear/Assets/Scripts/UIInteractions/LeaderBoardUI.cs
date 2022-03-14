using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace Assets.Scripts.UIInteractions
{
    public class LeaderBoardUI : MonoBehaviour
    {
        [SerializeField] private GameObject PlayerInfoButton;
        [SerializeField] private GameObject LeaderboardPanel;
        public static Dictionary<int, int> leaders = new Dictionary<int, int>();//ileri asamada username, score olarak tutulabilir.
        private void Start()
        {
            GameManager.instance.Race.RaceEnd += OpenPanelAndShowLeaderBoard;
            GameManager.instance.PlayfabManager.LeaderBoardsUpdated += GenerateUIMembers;
        }

        private void GenerateUIMembers()
        {
            foreach(var score in leaders)
            {
                var btn = Instantiate(PlayerInfoButton, LeaderboardPanel.transform);
                var txt = btn.GetComponentInChildren<TextMeshProUGUI>();
                txt.text = score.Key + "      " + score.Value;
            }
        }

        private void OpenPanelAndShowLeaderBoard()
        {
            LeaderboardPanel.SetActive(true);
        }

      
    }
}
