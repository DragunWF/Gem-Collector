using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    const float hoverSpeed = 1.5f;
    const float timeBeforeDirectionSwitch = 0.35f;

    bool isHoveringUp;
    bool isActive = true;

    SpriteRenderer gemSprite;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && isActive)
        {
            gemSprite.color = new Color(1, 1, 1, 0);
            isActive = false;
            Invoke("ActivateGem", 5f);
        }
    }

    void Start()
    {
        gemSprite = GetComponent<SpriteRenderer>();
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
        Invoke("SwitchHoverDirection", timeBeforeDirectionSwitch);
    }

    void ActivateGem()
    {
        gemSprite.color = new Color(1, 1, 1, 1);
        isActive = true;
    }
}
