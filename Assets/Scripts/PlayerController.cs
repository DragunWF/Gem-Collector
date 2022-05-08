using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float baseSpeed = 5f;
    const float baseSteerSpeed = 300f;

    const float maxAcceleration = 15f;
    float acceleration = 0f;
    bool carReversing;

    const float maxSteerAcceleration = 50f;
    float steerAcceleration = 0f;
    bool steeringLeft;

    void Update()
    {
        CarMovement();
        CarSteering();
    }

    void CarMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            carReversing = Input.GetKey(KeyCode.DownArrow);

            acceleration += 0.15f;
            if (acceleration >= maxAcceleration)
                acceleration = maxAcceleration;

            var speed = Input.GetAxis("Vertical") * Time.deltaTime * (baseSpeed + acceleration);
            transform.Translate(0, speed, 0);
        }
        else
        {
            acceleration -= 0.085f;
            if (acceleration <= 0)
                acceleration = 0;

            var force = carReversing ? -acceleration : acceleration;
            var friction = Time.deltaTime * force;
            transform.Translate(0, friction, 0);
        }
    }

    void CarSteering()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            steeringLeft = Input.GetKey(KeyCode.LeftArrow);

            steerAcceleration += 5f;
            if (steerAcceleration >= maxSteerAcceleration)
                steerAcceleration = maxSteerAcceleration;

            var rotateSpeed = Input.GetAxis("Horizontal") * Time.deltaTime * (baseSteerSpeed + steerAcceleration);
            transform.Rotate(0, 0, rotateSpeed);
        }
        else
        {
            steerAcceleration -= 0.3f;
            if (steerAcceleration <= 0)
                steerAcceleration = 0;

            var force = steeringLeft ? -steerAcceleration : steerAcceleration;
            var friction = Time.deltaTime * force;
            transform.Rotate(0, 0, friction);
        }
    }
}
