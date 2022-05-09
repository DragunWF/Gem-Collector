using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    ParticleSystem explosionParticle;
    Timer timer;

    public bool IsAlive { get; private set; }

    void Start()
    {
        explosionParticle = GetComponent<ParticleSystem>();
        timer = FindObjectOfType<Timer>();
        IsAlive = true;
    }

    void Update()
    {
        if (IsAlive && timer.TimeValue <= 0)
        {
            IsAlive = false;
            explosionParticle.Play();
        }
    }
}
