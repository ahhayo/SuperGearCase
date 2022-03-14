using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using Assets.Scripts.UIInteractions;

public class PlayfabManager : MonoBehaviour
{
    [HideInInspector] public Action LeaderBoardsUpdated;
    [HideInInspector] public Action LeaderBoardDataSended;
    private void Start()
    {
        Login();

    }
    private void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    private void OnSuccess(LoginResult result)
    {
        Debug.Log("Successful login/account create!");
    }
    private void OnError(PlayFabError error)
    {
        Debug.Log("Error while logging in/creating account!");
        Debug.Log(error.GenerateErrorReport());
    }

    public void SendLeaderBoard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "RaceTime",
                    Value = score
                }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderBoardUpdate, OnError);
    }

    public void OnLeaderBoardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successfull leaderboard send");
        LeaderBoardDataSended?.Invoke();
        GetLeaderboard();
    }

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "RaceTime",
            StartPosition = 0,
            MaxResultsCount = 5
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderBoardGet, OnError);
    }

    public void OnLeaderBoardGet(GetLeaderboardResult result)
    {
        LeaderBoardUI.leaders.Clear();
        foreach (var item in result.Leaderboard)
        {
            LeaderBoardUI.leaders.Add(item.Position + 1, item.StatValue);
            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
        LeaderBoardsUpdated?.Invoke();

    }


}
