using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using System.Threading.Tasks;


public class GPGS : MonoBehaviour
{
    [SerializeField] private GameObject loginButton;
    [SerializeField] private GameObject logoutButton;

    void Awake()
    {
        // PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();

        // PlayGamesPlatform.InitializeInstance(config);
        // recommended for debugging:
        PlayGamesPlatform.DebugLogEnabled = true;
        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();

        // authenticate user:
        // PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) =>
        // {
        //     // handle results
        //     if (SignInStatus.Success == result)
        //     {
        //         loginButton.SetActive(false);
        //         logoutButton.SetActive(true);
        //     }
        //     else
        //     {
        //         loginButton.SetActive(true);
        //         logoutButton.SetActive(false);
        //     }
        // });
    }

    public void SignIn()
    {
        // authenticate user:
        // PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptAlways, (result) =>
        // {
        //     // handle results
        //     if (SignInStatus.Success == result)
        //     {
        //         loginButton.SetActive(false);
        //         logoutButton.SetActive(true);
        //     }
        //     else
        //     {
        //         loginButton.SetActive(true);
        //         logoutButton.SetActive(false);
        //     }
        // });
        // StartCoroutine(WaitForLog(true));
    }

    public void SignOut()
    {
        // sign out
        //     PlayGamesPlatform.Instance.SignOut();
        //     loginButton.SetActive(true);
        //     logoutButton.SetActive(false);

    }
    public static void UnclockAchievement(string id)
    {
        Social.ReportProgress(id, 100.0f, (bool success) => { });
    }

    public void ShowAchievements()
    {
        Social.ShowAchievementsUI();
    }

    public static bool IsLoggedIn()
    {
        return PlayGamesPlatform.Instance.localUser.authenticated;
    }
}
