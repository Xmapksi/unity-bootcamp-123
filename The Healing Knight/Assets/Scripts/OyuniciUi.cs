using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OyuniciUi : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject musicOnButton;
    public GameObject musicOffButton;
    public GameObject soundOnButton;
    public GameObject soundOffButton;
    public GameObject music;
    public GameObject butonClick;
    //public GameObject karakterSes;

    private void Awake()
    {

    }

    void Start()
    {
        ControlButtons();

    }

    public void ControlButtons()
    {
        string musicPref = SecurePlayerPrefs.GetString("IsMusicOn", "password");
        if (musicPref == "true")
        {
            musicOnButton.SetActive(true);
            musicOffButton.SetActive(false);
            music.SetActive(true);
        }
        else
        {
            musicOnButton.SetActive(false);
            musicOffButton.SetActive(true);
            music.SetActive(false);
        }

        string soundEffects = SecurePlayerPrefs.GetString("IsSoundEffectsOn", "password");
        if (soundEffects == "true")
        {
            soundOnButton.SetActive(true);
            soundOffButton.SetActive(false);
            //karakterSes.SetActive(true);

        }
        else
        {
            //karakterSes.SetActive(false);
            soundOnButton.SetActive(false);
            soundOffButton.SetActive(true);
        }
    }

    public void musicOpen()
    {
        OpenAudio();
        musicOnButton.SetActive(false);
        musicOffButton.SetActive(true);
        SecurePlayerPrefs.SetString("IsMusicOn", "false", "password");
        music.SetActive(false);

    }
    public void musicClose()
    {
        OpenAudio();
        musicOnButton.SetActive(true);
        musicOffButton.SetActive(false);
        SecurePlayerPrefs.SetString("IsMusicOn", "true", "password");
        music.SetActive(true);
    }
    public void soundOpen()
    {
        OpenAudio();
        soundOnButton.SetActive(false);
        soundOffButton.SetActive(true);
        //karakterSes.SetActive(false);
        SecurePlayerPrefs.SetString("IsSoundEffectsOn", "false", "password");

    }
    public void soundClose()
    {
        OpenAudio();
        soundOnButton.SetActive(true);
        soundOffButton.SetActive(false);
        //karakterSes.SetActive(true);
        SecurePlayerPrefs.SetString("IsSoundEffectsOn", "true", "password");

    }

    public void PausePanelOpen()
    {
        OpenAudio();
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        music.SetActive(false);
        //karakterSes.SetActive(false);

    }
    public void PausePanelClose()
    {
        OpenAudio();
        pausePanel.SetActive(false);
        ControlButtons();
        Time.timeScale = 1f;
    }
    public void nextLevel()
    {
        OpenAudio();
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene + 1);

    }
    public void replayLevel()
    {
        OpenAudio();
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene);

    }
    public void anasayfa()
    {
        OpenAudio();
        SceneManager.LoadScene(0);
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



}
