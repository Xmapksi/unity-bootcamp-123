using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using TMPro;
public class firstBoot : MonoBehaviour
{
    public bool isFirstBoot = false;
    void Awake()
    {
        // PlayerPrefs.DeleteAll();
        Time.timeScale = 1f;
        if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
        {

            Debug.Log("First Time Opening");
            isFirstBoot = true;
            PlayerPrefs.DeleteAll();
            CallAllDB();
            //Set first time opening to false
            PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);

            //Do your stuff here
        }
        else
        {
            Debug.Log("NOT First Time Opening");
            isFirstBoot = false;
            //Do your stuff here
        }

    }

    private void CallAllDB()
    {
        LoadStatsData();
    }

    public void LoadStatsData()
    {

        SecurePlayerPrefs.SetString("IsMusicOn", "true", "password");
        SecurePlayerPrefs.SetString("IsSoundEffectsOn", "true", "password");
        SecurePlayerPrefs.SetString("LevelDone", "0", "password");
        SecurePlayerPrefs.SetString("RewardedAds", "2", "password");

        SecurePlayerPrefs.SetString("Level1", "0", "password");
        SecurePlayerPrefs.SetString("Level2", "0", "password");
        SecurePlayerPrefs.SetString("Level3", "0", "password");
    }


}
