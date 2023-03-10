using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private CharacterController controller;
    #region References
    private Transform _myTransform;
    private Transform _cameraTransform;
    #endregion
    #region Parameters
    [SerializeField]
    private float _speed = 2.0f;
    [SerializeField]
    private float _gravityValue = -9.81f;
    #endregion
    #region Properties
    [SerializeField]
    private Vector3 directionVector;
    private Vector3 playerVelocity;
    #endregion

    private void Start()
    {
        _myTransform = transform;
        controller = gameObject.GetComponent<CharacterController>();
        _cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        controller.Move(directionVector * Time.deltaTime * _speed);
    }
    public void SetDirection(Vector2 direction)
    {
        directionVector = new Vector3(direction.x,0, direction.y);
        directionVector = _cameraTransform.forward * directionVector.z + _cameraTransform.right* directionVector.x;
        directionVector.y = 0;
    }
}
