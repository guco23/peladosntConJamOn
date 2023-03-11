using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Parameters
    [SerializeField]
    private intS _daņoBalasBase;
    #endregion
    #region References
    private MovementController _myMovementController;
    #endregion
    private void Start()
    {
        SetDaņoBalas(_daņoBalasBase);
        _myMovementController = GetComponent<MovementController>();
    }
    // Update is called once per frame
    private void Update()
    {
        _myMovementController.SetDirection(InputManager.Instance.GetPlayerMovement());
    }
    public void SetDaņoBalas(int valor)
    {
        BalaBehaviour.SetDamage(valor);
    }
}
