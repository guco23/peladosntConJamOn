using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Parameters
    [SerializeField]
    private intS _dañoBalasBase;
    #endregion
    #region References
    private MovementController _myMovementController;
    #endregion
    private void Start()
    {
        SetDañoBalas(_dañoBalasBase);
        _myMovementController = GetComponent<MovementController>();
    }
    // Update is called once per frame
    private void Update()
    {
        _myMovementController.SetDirection(InputManager.Instance.GetPlayerMovement());
    }
    public void SetDañoBalas(int valor)
    {
        BalaBehaviour.SetDamage(valor);
    }
}
