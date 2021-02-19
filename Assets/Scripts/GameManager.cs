using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public delegate void GameDelegate();
    public static event GameDelegate GameStarted;
    public static event GameDelegate GameResetted;

    public GameObject m_StartPage;
    public GameObject m_CountdownPage;
    public GameObject m_GameOverPage;

    public Text m_ScoreText;

    public bool IsGameOver { get; private set; } = true;

    private int m_Score = 0;

    void Awake()
    {
        Instance = this;
    }

    public void GameStart()
    {
        SetPageState(PageState.Countdown);
    }

    public void GameReset()
    {
        SetScore(0);
        SetPageState(PageState.Start);
        m_ScoreText.gameObject.SetActive(false);
        GameResetted();
    }

    private void OnEnable()
    {
        BirdController.BirdHit += OnGameOver;
        BirdController.BirdScored += OnScored;
        Countdown.CountdownFinished += OnCountdownFinished;
    }

    private void OnDisable()
    {
        BirdController.BirdHit -= OnGameOver;
        BirdController.BirdScored -= OnScored;
        Countdown.CountdownFinished -= OnCountdownFinished;
    }

    private void OnGameOver()
    {
        IsGameOver = true;
        int highScore = PlayerPrefs.GetInt("HighScore");
        if (m_Score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", m_Score);
        }
        SetPageState(PageState.GameOver);
    }

    private void OnScored()
    {
        SetScore(m_Score + 1);
        Debug.Log(m_Score);
    }

    private void OnCountdownFinished()
    {
        IsGameOver = false;
        SetPageState(PageState.None);
        m_ScoreText.gameObject.SetActive(true);
        GameStarted();
    }

    private void SetPageState(PageState state)
    {
        m_StartPage.SetActive(PageState.Start.Equals(state));
        m_CountdownPage.SetActive(PageState.Countdown.Equals(state));
        m_GameOverPage.SetActive(PageState.GameOver.Equals(state));
    }

    private void SetScore(int score)
    {
        m_Score = score;
        m_ScoreText.text = score.ToString();
    }

    private enum PageState
    {
        None,
        Start,
        Countdown,
        GameOver
    }
}
