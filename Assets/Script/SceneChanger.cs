using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public void LoadSceneMainTitle() => LoadingSceneAsync.instance.LoadLobbyScene();
    public void LoadSceneLoading() => LoadingSceneAsync.instance.LoadLoadingScene();
    public void GameQuit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                 Application.Quit();

        #endif

    }
}
