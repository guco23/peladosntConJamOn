using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Parameters
    [SerializeField]
    private int _dañoBalasBase;

    //NOTA
    //Gestionamos el daño de los enemigos desde aquí ya que todos los enemigos tienen el mismo daño y así es mas fácil cambiarlo
    [SerializeField]
    [Tooltip("El daño que le hacen los enemigos al jugador")]
    private int _dañoEnemigosBase;

    private int _dañoEnemigosActual;

    #endregion
    #region References
    private MovementController _myMovementController;

    private LifeComponent _lifeComponent;
    #endregion

    [SerializeField]
    private float _tiempoEntreDaños;

    private float _currentTime;

    private LayerMask enemies;
    private void Start()
    {
        _dañoEnemigosActual =_dañoEnemigosBase;

        _currentTime = 0;

        enemies = LayerMask.NameToLayer("Enemies");

        SetDañoBalas(_dañoBalasBase);

        _myMovementController = GetComponent<MovementController>();
        _lifeComponent = GetComponent<LifeComponent>();
    }
    // Update is called once per frame
    private void Update()
    {
        _myMovementController.SetDirection(InputManager.Instance.GetPlayerMovement());
        _currentTime += Time.deltaTime;
    }
    public void SetDañoBalas(int valor)
    {
        BalaBehaviour.SetDamage(valor);
    }
    public void SetDañoEnemigos(int valor)
    {
        _dañoEnemigosActual = valor;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == enemies && _currentTime >= _tiempoEntreDaños)
        {
            _currentTime = 0;
            _lifeComponent.DealDamage(_dañoEnemigosActual);
        }
    }
}
