using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif



public class StartMenuUIHandler : MonoBehaviour
{
    private InputField inputField;
    private GameObject errorMessage;
    public Text highScoreText;
    public GameObject startMenuData;

   

    private void Start()
    {
        startMenuData.GetComponent<StartMenuData>().LoadHighScore();
        SetHighScoreUI();

        print($"Name: {PlayerData.Instance.playerName} Score:{PlayerData.Instance.score}");
        inputField = GetComponentInChildren<InputField>();
        errorMessage = GameObject.Find("ErrorMessage");

        errorMessage.SetActive(false);
    }

    public void StartGame()
    {
        
        if (CheckPlayerName())
        {
            SceneManager.LoadScene(1);
        }
    }

    private bool CheckPlayerName()
    {
        if (inputField.text == "")
        {
            errorMessage.SetActive(true);
            return false;
        }

        PlayerData.Instance.playerName = inputField.text;
        return true;
    }

    public void SetHighScoreUI()
    {
        if (PlayerData.Instance.playerName == "")
        {
            return;
        }
        highScoreText.text = $"Best Score: {PlayerData.Instance.playerName} ({PlayerData.Instance.score} points)";
    }

    public void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
