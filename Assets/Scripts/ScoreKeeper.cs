using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public int Score { get; private set; }

    public void IncreaseScore()
    {
        Score += Random.Range(5, 25);
        scoreText.text = string.Format("Score: {0:n0}", Score);
    }

    void Start()
    {
        Score = 0;
        scoreText.text = string.Format("Score: {0}", Score);
    }
}
