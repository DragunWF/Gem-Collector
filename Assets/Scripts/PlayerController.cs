using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] const float baseSpeed = 5f;
    [SerializeField] const float baseSteerSpeed = 300f;

    const float maxAcceleration = 15f;
    float acceleration = 0f;
    bool reversing;

    void Start()
    {

    }

    void Update()
    {
        CarMovement();
        CarSteering();
    }

    void CarMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            reversing = Input.GetKey(KeyCode.DownArrow);

            acceleration += 0.15f;
            if (acceleration >= maxAcceleration)
                acceleration = maxAcceleration;

            var speed = Input.GetAxis("Vertical") * Time.deltaTime * (baseSpeed + acceleration);
            transform.Translate(0, speed, 0);
        }
        else
        {
            acceleration -= 0.2f;
            if (acceleration <= 0)
                acceleration = 0;

            var force = reversing ? -acceleration : acceleration;
            var friction = Time.deltaTime * force;
            transform.Translate(0, friction, 0);
        }
    }

    void CarSteering()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            var rotateSpeed = Input.GetAxis("Horizontal") * Time.deltaTime * baseSteerSpeed;
            transform.Rotate(0, 0, rotateSpeed);
        }
    }
}
