using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    ParticleSystem explosionParticle;
    AudioSource explosionSoundEffect;

    EndScreen endScreen;
    Timer timer;

    public bool IsAlive { get; private set; }

    void Awake()
    {
        endScreen = FindObjectOfType<EndScreen>();
        timer = FindObjectOfType<Timer>();

        explosionSoundEffect = GetComponent<AudioSource>();
        explosionParticle = GetComponent<ParticleSystem>();
    }

    void Start()
    {
        IsAlive = true;
    }

    void Update()
    {
        if (timer.TimeValue <= 0 && IsAlive)
        {
            IsAlive = false;
            explosionParticle.Play();
            explosionSoundEffect.Play();

            Invoke("IntializeEndScreen", 3);
        }
    }

    void IntializeEndScreen()
    {
        endScreen.gameObject.SetActive(true);
        endScreen.TriggerEndScreen();
    }
}
