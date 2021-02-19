using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public delegate void GameDelegate();
    public static event GameDelegate GameStarted;
    public static event GameDelegate GameResetted;

    public Text m_ScoreText;

    public bool IsGameOver { get; private set; } = false;

    private int m_Score = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnEnable()
    {
        BirdController.BirdHit += OnGameOver;
        BirdController.BirdScored += OnScored;
    }

    private void OnDisable()
    {
        BirdController.BirdHit -= OnGameOver;
        BirdController.BirdScored -= OnScored;
    }

    private void OnGameResetted()
    {
        GameResetted();
        SetScore(0);
    }

    private void OnGameOver()
    {
        IsGameOver = true;
        int highScore = PlayerPrefs.GetInt("HighScore");
        if (m_Score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", m_Score);
        }
        Debug.Log("GameOver");
    }

    private void OnScored()
    {
        SetScore(m_Score + 1);
        Debug.Log(m_Score);
    }

    private void OnGameStarted()
    {
        GameStarted();
    }

    private void SetScore(int score)
    {
        m_Score = score;
        m_ScoreText.text = score.ToString();
    }
}
