using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float steerSpeed = 300f;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            var speed = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
            transform.Translate(0, speed, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            var rotateSpeed = Input.GetAxis("Horizontal") * Time.deltaTime * steerSpeed;
            transform.Rotate(0, 0, rotateSpeed);
        }
    }
}
