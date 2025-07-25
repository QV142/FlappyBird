using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;
    public TextMeshProUGUI inGameScore;
    public GameObject scoreBoard;
    public TextMeshProUGUI gameOverScore;
    public TextMeshProUGUI bestScore;
    public Button restartButton;
    private Bird bird;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        bird = FindObjectOfType<Bird>();
        Time.timeScale = 1f;
        scoreBoard.SetActive(false);
        restartButton.gameObject.SetActive(false);
        inGameScore.text = "Flappy Bird";
        restartButton.onClick.AddListener(RestartGame);
    }

    private void Update()
    {
        if (bird != null && bird.hasStarted)
        {
            inGameScore.text = score.ToString();
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        scoreBoard.SetActive(true);
        restartButton.gameObject.SetActive(true);
        gameOverScore.text = score.ToString();
        int best = PlayerPrefs.GetInt("BestScore", 0);
        if (score > best)
        {
            best = score;
            PlayerPrefs.SetInt("BestScore", best);
            PlayerPrefs.Save();
        }

        bestScore.text = best.ToString();
    }

    public void AddScore(int amount)
    {
        score += amount;
        inGameScore.text = score.ToString();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
