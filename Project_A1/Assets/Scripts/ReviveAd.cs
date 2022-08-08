using System;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Mediation;

public class ReviveAd : MonoBehaviour
{
    public bool StartedAD, secondChance, rewardEarned;
    public Player_Main PlayerMain;
    public GameObject DieTab;

    IRewardedAd ad;
    string adUnitId = "Rewarded_Android";
    string gameId = "4487579";
    InitializationOptions options = new InitializationOptions();

        void Start(){
          InitServices();
        }

        public async void InitServices()
        {
            try
            {
                InitializationOptions initializationOptions = new InitializationOptions();
                initializationOptions.SetGameId(gameId);
                await UnityServices.InitializeAsync(initializationOptions);

                InitializationComplete();
            }
            catch (Exception e)
            {
                InitializationFailed(e);
            }
        }

        public void SetupAd()
        {
            //Create
            ad = MediationService.Instance.CreateRewardedAd(adUnitId);

            //Subscribe to events
            ad.OnLoaded += AdLoaded;
            ad.OnFailedLoad += AdFailedLoad;

            ad.OnShowed += AdShown;
            ad.OnFailedShow += AdFailedShow;
            ad.OnClosed += AdClosed;
            ad.OnClicked += AdClicked;
            ad.OnUserRewarded += UserRewarded;

            // Impression Event
            MediationService.Instance.ImpressionEventPublisher.OnImpression += ImpressionEvent;
        }

        public void ShowAd()
        {
            if (ad.AdState == AdState.Loaded)
            {
                ad.Show();
                StartedAD = true;
                DieTab.SetActive(false);
            }
            
        }

        void InitializationComplete()
        {
            SetupAd();
            ad.Load();
        }

        void InitializationFailed(Exception e)
        {
            Debug.Log("Initialization Failed: " + e.Message);
            PlayerMain.EndD();
        }

        void AdLoaded(object sender, EventArgs args)
        {
            Debug.Log("Ad loaded");
        }

        void AdFailedLoad(object sender, LoadErrorEventArgs args)
        {
            Debug.Log("Failed to load ad");
            Debug.Log(args.Message);
            PlayerMain.EndD();
        }

        void AdShown(object sender, EventArgs args)
        {
            Debug.Log("Ad shown!");
                
            StartedAD = true;
        }

        void AdClosed(object sender, EventArgs e)
        {
            // Pre-load the next ad
            //ad.Load();
            Debug.Log("Ad has closed");
            
            // Execute logic after an ad has been closed.
            
        }

        void AdClicked(object sender, EventArgs e)
        {
            Debug.Log("Ad has been clicked");
            // Execute logic after an ad has been clicked.
            
            StartedAD = true;
        }

        void AdFailedShow(object sender, ShowErrorEventArgs args)
        {
            Debug.Log(args.Message);
            PlayerMain.EndD();
        }

        void ImpressionEvent(object sender, ImpressionEventArgs args)
        {
            var impressionData = args.ImpressionData != null ? JsonUtility.ToJson(args.ImpressionData, true) : "null";
            Debug.Log("Impression event from ad unit id " + args.AdUnitId + " " + impressionData);
        }
        
        void UserRewarded(object sender, RewardEventArgs e)
        {
            Debug.Log($"Received reward: type:{e.Type}; amount:{e.Amount}");
            rewardEarned = true;
            StartedAD = false;
            Invoke("RewardCheck", 1);  
        }

        void RewardCheck(){
          if(rewardEarned == true){
            PlayerMain.Rvs();
          }
          else{
            PlayerMain.EndD();
          }
    }
}