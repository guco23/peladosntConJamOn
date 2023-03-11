using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Parameters
    [SerializeField]
    private int _da�oBalasBase;

    //NOTA
    //Gestionamos el da�o de los enemigos desde aqu� ya que todos los enemigos tienen el mismo da�o y as� es mas f�cil cambiarlo
    [SerializeField]
    [Tooltip("El da�o que le hacen los enemigos al jugador")]
    private int _da�oEnemigosBase;

    private int _da�oEnemigosActual;

    #endregion
    #region References
    private MovementController _myMovementController;

    private LifeComponent _lifeComponent;
    #endregion

    [SerializeField]
    private float _tiempoEntreDa�os;

    private float _currentTime;

    private LayerMask enemies;
    private void Start()
    {
        _da�oEnemigosActual =_da�oEnemigosBase;

        _currentTime = 0;

        enemies = LayerMask.NameToLayer("Enemies");

        SetDa�oBalas(_da�oBalasBase);

        _myMovementController = GetComponent<MovementController>();
        _lifeComponent = GetComponent<LifeComponent>();
    }
    // Update is called once per frame
    private void Update()
    {
        _myMovementController.SetDirection(InputManager.Instance.GetPlayerMovement());
        _currentTime += Time.deltaTime;
    }
    public void SetDa�oBalas(int valor)
    {
        BalaBehaviour.SetDamage(valor);
    }
    public void SetDa�oEnemigos(int valor)
    {
        _da�oEnemigosActual = valor;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == enemies && _currentTime >= _tiempoEntreDa�os)
        {
            _currentTime = 0;
            _lifeComponent.DealDamage(_da�oEnemigosActual);
        }
    }
}
