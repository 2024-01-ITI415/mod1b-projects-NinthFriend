using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    static public int score = 1000;

    // Awake is called to check for already existing HighScore
    void Awake()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");
        }

        // Assign the high score to HighScore
        PlayerPrefs.SetInt("HighScore", score);
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI gt = this.GetComponent<TextMeshProUGUI>();
        gt.text = "High Score: " + score;

        // Update the PlayerPrefs HighScore if necessary
        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
