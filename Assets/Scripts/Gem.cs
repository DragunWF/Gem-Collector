using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] Sprite[] gemSprites = new Sprite[6];
    SpriteRenderer gemSprite;
    Sprite lastUsedSprite;

    ParticleSystem onCollectedParticle;
    Color[] particleColors = new Color[6] {
       new Color32(22, 102, 224, 128), // Blue
       new Color32(29, 222, 177, 128), // Cyan
       new Color32(24, 222, 77, 128), // Green
       new Color32(235, 145, 28, 128), // Orange
       new Color32(227, 39, 199, 128), // Pink
       new Color32(232, 220, 56, 128), // Yellow
    };
    int particleColorIndex;

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

    void PickRandomSprite()
    {
        var index = Random.Range(0, gemSprites.Length - 1);
        gemSprite.sprite = gemSprites[index];

        if (lastUsedSprite == gemSprite.sprite)
            PickRandomSprite();
        else
        {
            lastUsedSprite = gemSprite.sprite;
            particleColorIndex = index;
        }
    }

    void SpawnGem()
    {
        isActive = true;
        gemSprite.color = new Color(1, 1, 1, 1);
        PickRandomSprite();

        var particleSettings = onCollectedParticle.main;
        particleSettings.startColor = particleColors[particleColorIndex];
    }

    void OnGemCollected()
    {
        isActive = false;
        onCollectedParticle.Play();
        gemSprite.color = new Color(1, 1, 1, 0);
        Invoke("SpawnGem", timeToRespawn);
    }
}
