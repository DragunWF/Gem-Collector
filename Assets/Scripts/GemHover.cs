using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemHover : MonoBehaviour
{
    const float hoverSpeed = 1.5f;
    const float timeToSwitchDirection = 0.35f;
    bool isHoveringUp;

    void Start()
    {
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
}
