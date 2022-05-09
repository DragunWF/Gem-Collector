using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    int score = 0;

    public void IncreaseScore()
    {
        score += Random.Range(5, 25);
        scoreText.text = "Score: " + string.Format("{0:n0}", score);
    }

    void Start()
    {
        scoreText.text = "Score: " + score;
    }
}
