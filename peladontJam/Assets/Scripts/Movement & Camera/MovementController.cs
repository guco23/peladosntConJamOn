using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private CharacterController controller;
    #region References
    private Transform _cameraTransform;
    #endregion
    #region Parameters
    [SerializeField]
    private float _speed = 2.0f;
    [SerializeField]
    private float _gravityValue = -9.81f;
    private float _downForce;
    #endregion
    #region Properties
    [SerializeField]
    private Vector3 directionVector;
    #endregion

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        _cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        controller.Move(directionVector * Time.deltaTime * _speed);
        controller.Move(_downForce * Vector3.down   );
    }
    public void SetDirection(Vector2 direction)
    {
        directionVector = new Vector3(direction.x,0, direction.y);
        directionVector = _cameraTransform.forward * directionVector.z + _cameraTransform.right* directionVector.x;
        _downForce -= _gravityValue *Time.deltaTime;
        if (controller.isGrounded)
        {
            _downForce = 0;
        }
    }
}
