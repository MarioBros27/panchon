using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class StartScreen : MonoBehaviour
{
    string gameId = "3867831";
    bool testMode = false;

    bool adsbeenshowed;
    void Start()
    {
        // Initialize the Ads service:
        adsbeenshowed = false;
        Advertisement.Initialize(gameId,testMode);
    }
    void FixedUpdate() {
        if(adsbeenshowed == false){
            ShowInterstitialAd();//
        }
    }
    public void ShowInterstitialAd()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady())
        {
            adsbeenshowed = true;
            Advertisement.Show();
        }
        else
        {
            //Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Zocalo");

    }
}
