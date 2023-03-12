using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    static InputManager _instance;
    public static InputManager Instance
    {
        get { return _instance; }
    }

    private PlayerControlls playerControlls;

    private void Awake()
    {
        _instance = this;
        playerControlls = new PlayerControlls();
        Cursor.lockState= CursorLockMode.None;
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

    public bool GetMouseClick()
    {
        return playerControlls.Player.LeftClick.ReadValue<bool>();
        
    }
    private void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
}
