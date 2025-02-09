using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneName
{
    MainTitle = 0,
    Loading,
    Repeat
}
public class LoadingSceneAsync : MonoBehaviour
{
    public static LoadingSceneAsync instance = null;
    [SerializeField] private GameObject loadingUI = null;

    private float delay = 2f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public void LoadLoadingScene()
    {
        loadingUI.SetActive(true);
        SceneManager.LoadSceneAsync(SceneName.Loading.ToString());
        StartCoroutine(LoadingAsync());
    }

    public void LoadLobbyScene()
    {
        SceneManager.LoadScene(SceneName.MainTitle.ToString());
    }
    private IEnumerator LoadingAsync()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneName.Repeat.ToString());
        asyncOperation.allowSceneActivation = false;
        float time = 0;

        while (!asyncOperation.isDone)
        {
            time += Time.deltaTime;
            if (time > delay) asyncOperation.allowSceneActivation = true;

            yield return null;
        }
        loadingUI.SetActive(false);
    }


}