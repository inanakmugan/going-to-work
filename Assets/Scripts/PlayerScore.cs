using UnityEngine;
using TMPro;


public class PlayerScore : MonoBehaviour
{
    [SerializeField] float score = 1f;
    [SerializeField] TextMeshPro scoreText;
    [SerializeField] float pointIncreasedPerSecond = 1f;

    private string scoreTag = "Score";
   
    public int scoreInt;

    private void Update()
    {
        // Calculate points gained based on time alive
        scoreInt = Mathf.FloorToInt(score);

        scoreText.text = scoreInt.ToString();

        score += pointIncreasedPerSecond * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Playerprefs deleted");
        }

    }

    public void RegisterScore()
    {
        PlayerPrefs.SetInt(scoreTag, scoreInt);
    }


}
