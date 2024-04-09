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

    public void StartGame()
    {
        gameStarted = true;
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

    public void IncreaseScore()
    {
        score++;

    }

    private void FixedUpdate()
    {
        Text tagScore = this.textScore.GetComponent<Text>();
        tagScore.text = this.score.ToString();
    }
}
