using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Parameters
    [SerializeField]
    private intS _da�oBalasBase;
    #endregion
    #region References
    private MovementController _myMovementController;
    #endregion
    private void Start()
    {
        SetDa�oBalas(_da�oBalasBase);
        _myMovementController = GetComponent<MovementController>();
    }
    // Update is called once per frame
    private void Update()
    {
        _myMovementController.SetDirection(InputManager.Instance.GetPlayerMovement());
    }
    public void SetDa�oBalas(int valor)
    {
        BalaBehaviour.SetDamage(valor);
    }
}
