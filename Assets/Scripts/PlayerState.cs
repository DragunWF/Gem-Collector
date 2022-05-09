using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    ParticleSystem explosionParticle;
    AudioSource explosionSoundEffect;
    Timer timer;

    public bool IsAlive { get; private set; }

    void Start()
    {
        explosionSoundEffect = GetComponent<AudioSource>();
        explosionParticle = GetComponent<ParticleSystem>();
        timer = FindObjectOfType<Timer>();
        IsAlive = true;
    }

    void Update()
    {
        if (timer.TimeValue <= 0 && IsAlive)
        {
            IsAlive = false;
            explosionParticle.Play();
            explosionSoundEffect.Play();
        }
    }
}
