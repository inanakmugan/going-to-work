using TMPro;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
  private string scoreTag = "Score";
  private string highScoreTag = "HighScore";

  [SerializeField] TextMeshProUGUI scoreText;

  void Start()
  {
    SetScoreText();
  }

  private void SetScoreText()
  {
    int highScore = PlayerPrefs.GetInt(highScoreTag);
    int score = PlayerPrefs.GetInt(scoreTag);

    if (score > highScore)
    {
      PlayerPrefs.SetInt(highScoreTag,score);
      NewHighScore(score);

    }
    else if (score < highScore)
    {
      NormalScoreEnding(score, highScore);
    }
  }

  private void NormalScoreEnding(int score, int highScore)
  {
    scoreText.text = "Your score: " + score + " Highscore: " + highScore;
    Debug.Log("NormalScoreEnding function worked");
  }

  private void NewHighScore(int highScore)
  {
    scoreText.text = "New Highscore!: " + highScore;
    Debug.Log("NewHighScore function worked");
  }
}
