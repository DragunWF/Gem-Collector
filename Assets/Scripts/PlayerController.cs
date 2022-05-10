using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerState playerState;

    const float baseSpeed = 1.5f;
    const float baseSteerSpeed = 175;

    const float maxAcceleration = 10;
    const float accelerationSpeed = 5;
    const float deaccelerationSpeed = 8;
    float acceleration = 0f;
    bool carReversing;

    const float maxSteerAcceleration = 50;
    const float steerAccelerationSpeed = 30;
    const float steerDeaccelerationSpeed = 40;
    float steerAcceleration = 0f;
    bool steeringLeft;

    public bool OnRoad { get; private set; }
    public bool OnIntersection { get; private set; }

    public void ChangeRoadStatus(string roadType, bool state)
    {
        switch (roadType)
        {
            case "Road":
                OnRoad = state;
                break;
            case "Intersection":
                OnIntersection = state;
                break;
        }
    }

    void Start()
    {
        playerState = GetComponent<PlayerState>();
    }

    void Update()
    {
        if (playerState.IsAlive)
        {
            CarMovement();
            CarSteering();
        }
        else
        {
            var playerSprite = GetComponent<SpriteRenderer>();
            playerSprite.color = new Color(1, 1, 1, 0);
        }
    }

    void CarMovement()
    {
        var bonusSpeed = CheckForBonusSpeed();

        var arrowKeyPressed = (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow));
        var wdKeyPressed = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S));

        if (arrowKeyPressed || wdKeyPressed)
        {
            carReversing = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);

            acceleration += Time.deltaTime * accelerationSpeed;
            if (acceleration >= maxAcceleration)
                acceleration = maxAcceleration;

            var speed = Input.GetAxis("Vertical") * Time.deltaTime * (baseSpeed + acceleration + bonusSpeed);
            transform.Translate(0, speed, 0);
        }
        else
        {
            acceleration -= Time.deltaTime * deaccelerationSpeed;
            if (acceleration <= 0)
                acceleration = 0;

            var force = carReversing ? -acceleration : acceleration;
            var friction = Time.deltaTime * force;
            transform.Translate(0, friction, 0);
        }
    }

    void CarSteering()
    {
        var arrowKeyPressed = (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow));
        var wdKeyPressed = (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D));

        if (arrowKeyPressed || wdKeyPressed)
        {
            steeringLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);

            steerAcceleration += Time.deltaTime * steerAccelerationSpeed;
            if (steerAcceleration >= maxSteerAcceleration)
                steerAcceleration = maxSteerAcceleration;

            var rotateSpeed = Input.GetAxis("Horizontal") * Time.deltaTime * (baseSteerSpeed + steerAcceleration);
            transform.Rotate(0, 0, rotateSpeed);
        }
        else
        {
            steerAcceleration -= Time.deltaTime * steerDeaccelerationSpeed;
            if (steerAcceleration <= 0)
                steerAcceleration = 0;

            var force = steeringLeft ? -steerAcceleration : steerAcceleration;
            var friction = Time.deltaTime * force;
            transform.Rotate(0, 0, friction);
        }
    }

    float CheckForBonusSpeed()
    {
        float bonusSpeed = 0f;

        if (OnRoad)
            bonusSpeed += 1.5f;
        if (OnIntersection)
            bonusSpeed += 1.25f;

        return bonusSpeed;
    }
}
