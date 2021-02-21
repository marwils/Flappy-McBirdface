using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Countdown : MonoBehaviour
{
    public delegate void CountdownDelegate();
    public static event CountdownDelegate CountdownFinished;

    public int m_CountdownInSeconds = 3;

    public AudioSource countdownAudio;
    public AudioSource countdownFinalAudio;

    private Text countdownText;

    private void OnEnable()
    {
        countdownText = GetComponent<Text>();
        countdownText.text = m_CountdownInSeconds.ToString();
        StartCoroutine("DoCountdown");
    }

    IEnumerator DoCountdown()
    {
        for (int count = m_CountdownInSeconds; count > 0; count--)
        {
            countdownAudio.Play();
            countdownText.text = count.ToString();
            yield return new WaitForSeconds(1);
        }
        countdownFinalAudio.Play();
        CountdownFinished();
    }
}
