using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class LogAds : MonoBehaviour
{
    private BannerView bannerAd;
    private InterstitialAd interstitialAd;
    private RewardedAd rewardedAd;

    [SerializeField] private string bannerId = "";
    [SerializeField] private string intersitialId = "";
    [SerializeField] private string rewardId = "";

    // Start is called before the first frame update
    void Start()
    {
        pedirInterstitial();
        pedirReward();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Awake()
    {
        MobileAds.Initialize(initStatus => { });

    }
    private void pedirBanner()
    {
        bannerAd = new BannerView(bannerId, AdSize.Banner, AdPosition.Bottom);
        AdRequest pedir = new AdRequest.Builder().Build();
        bannerAd.LoadAd(pedir);
    }

    private void pedirInterstitial()
    {
        this.interstitialAd = new InterstitialAd(intersitialId);
        AdRequest pedir = new AdRequest.Builder().Build();
        this.interstitialAd.LoadAd(pedir);
    }
    private void pedirReward()
    {
        this.rewardedAd = new RewardedAd(rewardId);

        // Create an empty ad request.
        AdRequest pedir = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(pedir);

    }
    public void ClickMostrarBanner()
    {
        pedirBanner();
    }
    public void ClickMostrarInterstitial()
    {
        interstitialAd.Show();
        //interstitialAd.Destroy();
        pedirInterstitial();
    }
    public void ClickMostrarReward()
    {
        
        rewardedAd.Show();
        pedirReward();
    }
}
