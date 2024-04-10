using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public int score = 0;
    public GameObject textScore;
    public Text textScoreMax;

    private void Awake()
    {
        textScoreMax.text = "Best: " + ScoreMax();
    }

    public void StartGame()
    {
        gameStarted = true;
        FindObjectOfType<Path>().StartBuild();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    public void IncreaseScore(int scores)
    {
        score += scores;

        if(score > ScoreMax())
        {
            PlayerPrefs.SetInt("ScoreMax", score);
            textScoreMax.text = "Best: " + score.ToString();
        }
    }

    private void FixedUpdate()
    {
        Text tagScore = this.textScore.GetComponent<Text>();
        tagScore.text = this.score.ToString();
    }

    public int ScoreMax()
    {
        int i = PlayerPrefs.GetInt("ScoreMax");
        return i;
    }
}
