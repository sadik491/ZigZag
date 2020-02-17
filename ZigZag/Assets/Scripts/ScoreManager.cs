using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instence;

    public int score;
    public int highScore;

    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
    }
    void Awake()
    {
        if (instence == null)
        {
            instence = this;
        }
    }

    // Update is called once per frame
    void IncrementScore()
    {
        score += 1;
        
    }

    public void StartScore()
    {
        InvokeRepeating("IncrementScore", 0.1f, 0.5f);
    }

    public void StopScore()
    {
        CancelInvoke("IncrementScore");
        PlayerPrefs.SetInt("score", score);

        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
