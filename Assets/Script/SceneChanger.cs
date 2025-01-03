using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneChanger : MonoBehaviour
{
    public enum SceneName
    {
        MainTitle = 0,
        Repeat
    }

    private void LoadScene(SceneName scene)
    {
        switch (scene)
        {
            case SceneName.MainTitle:
                SceneManager.LoadScene(SceneName.MainTitle.ToString());
                break;
            case SceneName.Repeat:
                SceneManager.LoadScene(SceneName.Repeat.ToString());
                break;
        }
    }

    public void LoadSceneMainTitle() => LoadScene(SceneName.MainTitle);
    public void LoadSceneRepeat() => LoadScene(SceneName.Repeat);
    public void GameQuit()
    {
        Application.Quit();
    }
}
