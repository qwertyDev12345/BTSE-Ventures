using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.RemoteConfig;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
    [SerializeField] private Text loadingText;
    [SerializeField] private float dotInterval = 0.4f;
    [SerializeField] private GameObject _back;
    
    private const int MaxDots = 3;
    private Coroutine dotsRoutine;

    private string enableADS = "enableADS";
    private string adsURL = "adsURL";
    private string menuSceneName = "Main menu";

    private struct UserAttributes { }
    private struct AppAttributes { }

    private UniWebView webView;

    private async void Start()
    {
        SetLoading(true);

        try
        {
            await InitServices();
            await RemoteConfigService.Instance.FetchConfigsAsync(new UserAttributes(), new AppAttributes());
        
            var config = RemoteConfigService.Instance.appConfig;
            bool useWebView = config.GetBool(enableADS, false);
            string url = config.GetString(adsURL, string.Empty);
        
            if (useWebView && !string.IsNullOrEmpty(url))
                OpenWebView(url);
            else
                OpenMenu();
        }
        catch (Exception e)
        {
            Debug.LogError($"[Loader] Remote Config failed: {e}");
            OpenMenu(); // fallback
        }
    }

    private static async Task InitServices()
    {
        if (UnityServices.State == ServicesInitializationState.Uninitialized)
            await UnityServices.InitializeAsync();

        if (!AuthenticationService.Instance.IsSignedIn)
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    private void OpenWebView(string url)
    {
        _back.SetActive(true);
        
        webView = gameObject.AddComponent<UniWebView>();
        webView.Frame = new Rect(0, 0, Screen.width, Screen.height);
        webView.EmbeddedToolbar.Hide();
        
        webView.SetSupportMultipleWindows(false, true);
        webView.SetAllowFileAccess(true);
        webView.SetCalloutEnabled(true);
        webView.SetBackButtonEnabled(true);
        webView.OnShouldClose += webView => false;
        webView.OnPageFinished += (view, code, url) => OnLoaded();
        webView.SetAllowBackForwardNavigationGestures(true);
            
        webView.Load(url);
    }

    private void OnLoaded()
    {
        SetLoading(false);
        webView.Show();
    }

private void CloseWebView()
    {
        if (webView == null) return;
        Destroy(webView);
        webView = null;
    }

    private void OpenMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    private void SetLoading(bool value)
    {
        if (loadingText == null) return;

        if (dotsRoutine != null)
        {
            StopCoroutine(dotsRoutine);
            dotsRoutine = null;
        }

        loadingText.gameObject.SetActive(value);
        if (value) dotsRoutine = StartCoroutine(AnimateDots());
    }

    private IEnumerator AnimateDots()
    {
        int dots = 0;
        var wait = new WaitForSeconds(dotInterval);
        while (true)
        {
            loadingText.text = "Loading" + new string('.', dots);
            dots = (dots + 1) % (MaxDots + 1);
            yield return wait;
        }
    }
}
