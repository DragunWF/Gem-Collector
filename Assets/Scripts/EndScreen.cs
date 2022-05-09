using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI endText;
    [SerializeField] Button retryButton;

    ScoreKeeper scoreKeeper;
    Image background;

    PlayerState playerState;
    bool gameEnding;
    bool isDisplayed;
    float alphaSlider = 0;

    public void TriggerEndScreen()
    {
        gameEnding = true;
    }

    void Awake()
    {
        playerState = FindObjectOfType<PlayerState>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        background = GameObject.Find("Background").GetComponent<Image>();
    }

    void Start()
    {
        background.color = new Color(0, 0, 0, 0);
        retryButton.gameObject.SetActive(false);
        endText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameEnding && alphaSlider < 255)
        {
            alphaSlider += Time.deltaTime * 85;
            background.color = new Color32(0, 0, 0, (byte)alphaSlider);
        }

        if (!isDisplayed && alphaSlider >= 255)
        {
            isDisplayed = true;
            Invoke("DisplayUI", 1);
        }
    }

    void DisplayUI()
    {
        retryButton.gameObject.SetActive(true);
        endText.gameObject.SetActive(true);
        endText.text = "Congrats! You got a score of\n" + scoreKeeper.Score;
    }
}
