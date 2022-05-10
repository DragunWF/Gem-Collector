using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    EndScreen endScreen;
    int sceneBuildIndex;
    int mainSceneBuildIndex = 1;

    void Awake()
    {
        sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneBuildIndex == mainSceneBuildIndex)
            endScreen = FindObjectOfType<EndScreen>();
    }

    void Start()
    {
        if (sceneBuildIndex == mainSceneBuildIndex)
            endScreen.gameObject.SetActive(false);
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene(mainSceneBuildIndex);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }
}
