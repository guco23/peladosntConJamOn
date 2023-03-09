using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private CharacterController controller;
    #region References
    private Transform _myTransform;
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
    }

    void Update()
    {
        controller.Move(directionVector * Time.deltaTime * _speed);

        if (directionVector != Vector3.zero)
        {
            _myTransform.forward = directionVector;
        }
    }
    public void SetDirection(Vector2 direction)
    {
        directionVector = new Vector3(direction.x,0, direction.y);
    }
}
