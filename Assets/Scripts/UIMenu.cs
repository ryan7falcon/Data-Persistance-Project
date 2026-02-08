using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class UIMenu : MonoBehaviour
{
    private void Start()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.LoadBestScore(); // Load the best score when the menu starts
        }
    }
    public TMP_InputField bestScoreNameText;
    public void SetCurrentPlayerName(string name)
    {
        ScoreManager.Instance.SetCurrentPlayerName(name);
    }

    public void StartGame()
    {
        SetCurrentPlayerName(bestScoreNameText.text);
        ScoreManager.Instance.UpdateScore(0);
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        ScoreManager.Instance.SaveBestScore(); // Save the best score before exiting
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
