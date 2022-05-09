using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] GemSO[] gemTypes = new GemSO[6];
    GemSO currentGem;
    GemSO lastUsedGemType;

    SpriteRenderer gemSprite;
    ParticleSystem onCollectedParticle;

    const float hoverSpeed = 1.5f;
    const float timeToSwitchDirection = 0.35f;
    const float timeToRespawn = 30f;

    bool isHoveringUp;
    bool isActive = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && isActive)
            OnGemCollected();
    }

    void Start()
    {
        onCollectedParticle = GetComponent<ParticleSystem>();
        gemSprite = GetComponent<SpriteRenderer>();
        SpawnGem();
        SwitchHoverDirection();
    }

    void Update()
    {
        Hover();
    }

    void Hover()
    {
        var speed = isHoveringUp ? hoverSpeed : -hoverSpeed;
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

    void SwitchHoverDirection()
    {
        isHoveringUp = isHoveringUp ? false : true;
        Invoke("SwitchHoverDirection", timeToSwitchDirection);
    }

    void PickRandomGem()
    {
        currentGem = gemTypes[Random.Range(0, gemTypes.Length - 1)];

        if (lastUsedGemType == currentGem)
            PickRandomGem();
        else
            lastUsedGemType = currentGem;
    }

    void SpawnGem()
    {
        isActive = true;
        gemSprite.color = new Color(1, 1, 1, 1);
        PickRandomGem();

        gemSprite.sprite = currentGem.PickRandomGemShape();
        var particleSettings = onCollectedParticle.main;
        particleSettings.startColor = currentGem.GetParticleColor();
    }

    void OnGemCollected()
    {
        isActive = false;
        onCollectedParticle.Play();
        gemSprite.color = new Color(1, 1, 1, 0);
        Invoke("SpawnGem", timeToRespawn);
    }
}
