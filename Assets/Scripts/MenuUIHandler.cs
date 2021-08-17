using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public InputField TextPlayerName;
    public TextMeshProUGUI  BestScore;

    private void Awake()
    {
        SetBestScore();
    }

    private void SetBestScore()
    {
        BestScore.text = "Best Score:" + DataManager.Instance.MaxPlayerName + ":" + DataManager.Instance.MaxScore;
    }

    public void StartNew()
    {
        DataManager.Instance.CurrentPlayerName = TextPlayerName.text;
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
