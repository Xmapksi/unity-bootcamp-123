using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject music;
    //public GameObject[] kilit;

    public GameObject butonClick;

    public GameObject optionsPanel, levelsPanel, profilPanel;
    public GameObject musicOn, musicOff, soundOn, soundOff;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        Kontrol();
        LevelsControl();
        SecurePlayerPrefs.SetString("RewardedAds", "0", "password");
    }

    public void LevelGo(int i)
    {
        OpenAudio();
        SceneManager.LoadScene(i);
    }

    public void ToggleSound()
    {
        OpenAudio();
        string sound = SecurePlayerPrefs.GetString("IsSoundEffectsOn", "password");
        if (sound == "false")
        {
            SecurePlayerPrefs.SetString("IsSoundEffectsOn", "true", "password");
            Kontrol();

        }
        else
        {
            SecurePlayerPrefs.SetString("IsSoundEffectsOn", "false", "password");
            Kontrol();
        }
    }

    public void MusicOpen()
    {
        music.SetActive(true);
    }
    public void MusicClose()
    {
        music.SetActive(false);
    }
    public void ToggleMusic()
    {
        OpenAudio();
        string music = SecurePlayerPrefs.GetString("IsMusicOn", "password");
        if (music == "false")
        {
            SecurePlayerPrefs.SetString("IsMusicOn", "true", "password");
            MusicOpen();
            Kontrol();

        }
        else
        {
            SecurePlayerPrefs.SetString("IsMusicOn", "false", "password");
            MusicClose();
            Kontrol();
        }
    }
    public void Kontrol()
    {
        string music = SecurePlayerPrefs.GetString("IsMusicOn", "password"); //
        if (music == "false")  //
        {
            musicOn.SetActive(true);
            musicOff.SetActive(false);

            MusicClose();//

        }
        else //
        {
            musicOn.SetActive(false);
            musicOff.SetActive(true);
            //music açık
            MusicOpen(); //
        }


        string sound = SecurePlayerPrefs.GetString("IsSoundEffectsOn", "password");
        if (sound == "false")
        {
            soundOn.SetActive(true);
            soundOff.SetActive(false);
        }
        else
        {
            soundOn.SetActive(false);
            soundOff.SetActive(true);
            //sound açık
        }

    }

    public void LevelsControl()
    {
        // for (int i = 1; i < 3; i++)
        // {
        //     string completed = SecurePlayerPrefs.GetString("Level" + i, "password");
        //     if (completed == "1")
        //     {
        //         kilit[i - 1].SetActive(false);
        //     }

        // }

    }


    public void CloseAudio()
    {
        butonClick.SetActive(false);

    }
    public void OpenAudio()
    {
        string soundEffects = SecurePlayerPrefs.GetString("IsSoundEffectsOn", "password");
        if (soundEffects == "true")
        {
            butonClick.SetActive(false);
            butonClick.SetActive(true);
            Invoke("CloseAudio", 1);
        }
    }


    public void OpenLevel()
    {
        OpenAudio();
        levelsPanel.SetActive(true);
    }

    public void OpenOptions()
    {

        OpenAudio();
        optionsPanel.SetActive(true);
    }
    public void CloseOptionsPanel()
    {
        OpenAudio();
        optionsPanel.SetActive(false);
        levelsPanel.SetActive(false);
        profilPanel.SetActive(false);
    }
    public void OpenProfil()
    {
        OpenAudio();
        profilPanel.SetActive(true);
    }



    public void doExitGame()
    {
        Application.Quit();
    }

}