using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    PlayerController player;

    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        CollisionEvent(other.tag, true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        CollisionEvent(other.tag, false);
    }

    void CollisionEvent(string tag, bool isEntering)
    {
        switch (tag)
        {
            case "Road":
                player.ChangeRoadStatus(tag, isEntering);
                break;
            case "Intersection":
                player.ChangeRoadStatus(tag, isEntering);
                break;
            case "Gem":
                break;
        }
    }
}
