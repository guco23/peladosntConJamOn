using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerControlls playerControlls;

    private void Awake()
    {
        playerControlls = new PlayerControlls();
    }
    private void OnEnable()
    {
        playerControlls.Enable();
    }
    private void OnDisable()
    {
        playerControlls.Disable();
    }
    public Vector2 GetPlayerMovement()
    {
        return playerControlls.Player.Movement.ReadValue<Vector2>();
    }
    public Vector2 GetMouseDelta()
    {
        return playerControlls.Player.Look.ReadValue<Vector2>();
    }
}
