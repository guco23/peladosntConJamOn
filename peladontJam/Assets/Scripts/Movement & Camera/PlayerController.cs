using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region References
    private MovementController _myMovementController;
    #endregion
    private void Start()
    {
        _myMovementController = GetComponent<MovementController>();
    }
    // Update is called once per frame
    void Update()
    {
        _myMovementController.SetDirection(InputManager.Instance.GetPlayerMovement());
    }
}
