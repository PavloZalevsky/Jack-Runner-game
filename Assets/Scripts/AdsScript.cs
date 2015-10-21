using UnityEngine;
using GoogleMobileAds.Api;
using System.Collections;

public class AdsScript : MonoBehaviour
{

    public int FrequencyDisplayAds = 5;

    public string adsInterstitialUnitId = "ca-app-pub-9266418039002283/8869785251";

    private BannerView bannerView;
    private InterstitialAd interstitial;
    private AdRequest request;

    void Awake()
    {
        AdRequestInterstitial();
    }
 

    private void AdRequestInterstitial()
    {
        interstitial = new InterstitialAd(adsInterstitialUnitId);
        interstitial.LoadAd(createAdRequest());
    }

    public bool ShowInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
            AdRequestInterstitial();
            return true;
        }
        else
        {
            AdRequestInterstitial();
            return false;    
        }
    }
    private AdRequest createAdRequest()
    {
        return new AdRequest.Builder()
               .Build();
    }
}

