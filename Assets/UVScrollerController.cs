using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UVScroller))]
public class UVScrollerController : MonoBehaviour
{
    private UVScroller m_UVScroller;

    private void Start()
    {
        m_UVScroller = GetComponent<UVScroller>();
    }

    private void OnEnable()
    {
        BirdController.BirdHit += OnBirdHit;
        GameManager.GameStarted += OnGameStarted;
    }

    private void OnDisable()
    {
        BirdController.BirdHit -= OnBirdHit;
        GameManager.GameStarted -= OnGameStarted;
    }

    private void OnBirdHit()
    {
        m_UVScroller.enabled = false;
    }

    private void OnGameStarted()
    {
        m_UVScroller.enabled = true;
    }
}
