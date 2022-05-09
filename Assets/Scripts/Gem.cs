using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] GemSO[] gemTypes = new GemSO[6];
    GemSO currentGem;
    GemSO lastUsedGem;

    SpriteRenderer gemSprite;
    ParticleSystem onCollectedParticle;
    AudioSource collectedSoundEffect;

    const float timeToRespawn = 30f;
    public bool IsActive { get; private set; }

    ScoreKeeper scoreKeeper;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && IsActive)
            OnGemCollected();
    }

    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

        onCollectedParticle = GetComponent<ParticleSystem>();
        collectedSoundEffect = GetComponent<AudioSource>();
        gemSprite = GetComponent<SpriteRenderer>();

        IsActive = true;
        SpawnGem();
    }

    void PickRandomGem()
    {
        currentGem = gemTypes[Random.Range(0, gemTypes.Length - 1)];

        if (lastUsedGem == currentGem)
            PickRandomGem();
        else
            lastUsedGem = currentGem;
    }

    void SpawnGem()
    {
        IsActive = true;
        gemSprite.color = new Color(1, 1, 1, 1);
        PickRandomGem();

        gemSprite.sprite = currentGem.PickRandomGemShape();
        var particleSettings = onCollectedParticle.main;
        particleSettings.startColor = currentGem.GetParticleColor();
    }

    void OnGemCollected()
    {
        IsActive = false;
        scoreKeeper.IncreaseScore();

        onCollectedParticle.Play();
        collectedSoundEffect.Play();
        gemSprite.color = new Color(1, 1, 1, 0);

        Invoke("SpawnGem", timeToRespawn);
    }
}
