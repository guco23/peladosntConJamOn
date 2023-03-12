using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    private CharacterController controller;
    #region References
    private Transform _cameraTransform;
    #endregion
    #region Parameters
    [SerializeField]
    public float _walkSpeed = 2.0f;
    private float _runSpeedMultiplier = 1.0f;
    [SerializeField] private float _maxRunSpeed = 3.0f;
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
        controller.Move(directionVector.normalized * Time.deltaTime * _walkSpeed * _runSpeedMultiplier);
        controller.Move(_downForce * Vector3.down);
    }
    public void SetDirection(Vector2 direction)
    {       
        directionVector = new Vector3(direction.x,0, direction.y);
        Transform aux = transform;
        

        //directionVector = _cameraTransform.forward * directionVector.z + _cameraTransform.right.normalized* directionVector.x;
        Vector3 v = new Vector2(_cameraTransform.forward.x,_cameraTransform.forward.z).normalized * directionVector.z +
                         new Vector2(_cameraTransform.right.x, _cameraTransform.right.z).normalized * directionVector.x;
        directionVector = new Vector3(v.x, 0, v.y);
        //transform.rotation = _cameraTransform.rotation;      
        Debug.Log(directionVector);
        _downForce -= _gravityValue *Time.deltaTime;
        if (controller.isGrounded)
        {
            _downForce = 0;
        }
    }
    public void Run(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _runSpeedMultiplier = _maxRunSpeed;
        }
        if (context.canceled)
        {
            _runSpeedMultiplier = 1.0f;
        }
    }
}
