using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandle : MonoBehaviour
{
    public InputField playerName;
    public Text playerHighScore;

    static public string newplayerName;

    public void NewNameSelected(string playerName)
    {
        MenuManager.Instance.playerName = playerName;
    }

    private void Start()
    {
        MenuManager.Instance.LoadHighScore();
        playerHighScore.text += " " + MenuManager.Instance.playerName +" "+ MenuManager.Instance.highScore;
    }
    public void StartNew()
    {
        newplayerName = playerName.text;
        SceneManager.LoadScene(1);
    }


    public void Exit()
    {
        //MenuManager.Instance.LoadHighScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SaveNameClicked()
    {
        MenuManager.Instance.SaveHighScore();
    }

    public void LoadNameClicked()
    {
        MenuManager.Instance.LoadHighScore();
        //ColorPicker.SelectColor(MainManager.Instance.TeamColor);
    }
}
