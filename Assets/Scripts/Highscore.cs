using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Highscore : MonoBehaviour
{
    void OnEnable()
    {
        GetComponent<Text>().text = "Highscore: " + PlayerPrefs.GetInt("HighScore").ToString();
    }
}
