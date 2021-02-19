using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Parallax2D))]
public class Parallax2DController : MonoBehaviour
{
    private Parallax2D m_Parallax2D;

    private void Start()
    {
        m_Parallax2D = GetComponent<Parallax2D>();
    }

    private void OnEnable()
    {
        BirdController.BirdHit += OnBirdHit;
        GameManager.GameStarted += OnGameStarted;
        GameManager.GameResetted += GameResetted;
    }

    private void OnDisable()
    {
        BirdController.BirdHit -= OnBirdHit;
        GameManager.GameStarted -= OnGameStarted;
        GameManager.GameResetted -= GameResetted;
    }

    private void OnBirdHit()
    {
        m_Parallax2D.enabled = false;
    }

    private void OnGameStarted()
    {
        m_Parallax2D.enabled = true;
    }

    private void GameResetted()
    {
        m_Parallax2D.ClearAll();
    }
}
