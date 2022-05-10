using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    EndScreen endScreen;
    int sceneBuildIndex;

    void Awake()
    {
        sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneBuildIndex == 0)
            endScreen = FindObjectOfType<EndScreen>();
    }

    void Start()
    {
        if (sceneBuildIndex == 0)
            endScreen.gameObject.SetActive(false);
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene(0);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }
}
