using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public InputField NameInput;

    public Text BestScoreText;

    public void Start()
    {
        if (DataManager.Instance.BestScore.Points != 0)
        {
            Score BestScore = DataManager.Instance.BestScore;
            BestScoreText.text = "Best Score : " + BestScore.PlayerName + " : " + BestScore.Points;
        }
    }

    public void StartNew()
    {
        DataManager.Instance.CurrentScore.PlayerName = NameInput.text == "" ? "Player" : NameInput.text;
        SceneManager.LoadScene(1);
    }
}
