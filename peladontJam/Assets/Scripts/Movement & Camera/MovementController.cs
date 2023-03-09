using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    [SerializeField]
    private Vector3 directionVector;
    private float playerSpeed = 2.0f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {

        //Vector3 move = new Vector3(direction.x, 0, direction.x);
        controller.Move(directionVector * Time.deltaTime * playerSpeed);

        if (directionVector != Vector3.zero)
        {
            gameObject.transform.forward = directionVector;
        }
        //playerVelocity.y += gravityValue * Time.deltaTime;
        //controller.Move(playerVelocity * Time.deltaTime);
    }
    void SetDirection(Vector2 direction)
    {
        directionVector = direction;
    }
}
