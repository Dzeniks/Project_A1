using System;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Mediation;
using TMPro;

 
public class BtnShopAd : MonoBehaviour
{
    public shopMenu ShopMenu;
    public int AllCoins;
    public TextMeshProUGUI RewText;

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
        }

        void AdLoaded(object sender, EventArgs args)
        {
            Debug.Log("Ad loaded");
            RewText.text = $"{(int)(PlayerPrefs.GetInt("AllCoins") * 0.15)}";
        }

        void AdFailedLoad(object sender, LoadErrorEventArgs args)
        {
            Debug.Log("Failed to load ad");
            Debug.Log(args.Message);
        }

        void AdShown(object sender, EventArgs args)
        {
            Debug.Log("Ad shown!");
        }

        void AdClosed(object sender, EventArgs e)
        {
            // Pre-load the next ad
            ad.Load();
            Debug.Log("Ad has closed");
            // Execute logic after an ad has been closed.
        }

        void AdClicked(object sender, EventArgs e)
        {
            Debug.Log("Ad has been clicked");
            // Execute logic after an ad has been clicked.
        }

        void AdFailedShow(object sender, ShowErrorEventArgs args)
        {
            Debug.Log(args.Message);
        }

        void ImpressionEvent(object sender, ImpressionEventArgs args)
        {
            var impressionData = args.ImpressionData != null ? JsonUtility.ToJson(args.ImpressionData, true) : "null";
            Debug.Log("Impression event from ad unit id " + args.AdUnitId + " " + impressionData);
        }
        
        void UserRewarded(object sender, RewardEventArgs e)
        {
            Debug.Log($"Received reward: type:{e.Type}; amount:{e.Amount}");
            AllCoins = PlayerPrefs.GetInt("AllCoins");
            AllCoins += (int)(PlayerPrefs.GetInt("AllCoins") * 0.15);
            PlayerPrefs.SetInt("AllCoins", AllCoins);
            PlayerPrefs.Save();
        }
}
