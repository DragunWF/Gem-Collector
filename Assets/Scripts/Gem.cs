using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] Sprite[] gemSprites = new Sprite[6];
    Sprite lastUsedSprite;
    ParticleSystem onCollectedParticle;

    const float hoverSpeed = 1.5f;
    const float timeToSwitchDirection = 0.35f;
    const float timeToRespawn = 30f;

    bool isHoveringUp;
    bool isActive = true;

    SpriteRenderer gemSprite;

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
        gemSprite.sprite = gemSprites[Random.Range(0, gemSprites.Length - 1)];
        if (lastUsedSprite == gemSprite.sprite)
            PickRandomSprite();
        else
            lastUsedSprite = gemSprite.sprite;
    }

    void SpawnGem()
    {
        isActive = true;
        gemSprite.color = new Color(1, 1, 1, 1);
        PickRandomSprite();
    }

    void OnGemCollected()
    {
        isActive = false;
        gemSprite.color = new Color(1, 1, 1, 0);
        Invoke("SpawnGem", timeToRespawn);
    }
}
