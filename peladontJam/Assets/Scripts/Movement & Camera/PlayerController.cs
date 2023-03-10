using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region References
    private MovementController _myMovementController;
    private InputManager _inputManager;
    #endregion
    private void Start()
    {
        _myMovementController = GetComponent<MovementController>();
        _inputManager = InputManager.Instance;
    }
    // Update is called once per frame
    void Update()
    {
        _myMovementController.SetDirection(_inputManager.GetPlayerMovement());
    }
}
