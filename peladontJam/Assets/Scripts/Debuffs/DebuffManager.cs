using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffManager : MonoBehaviour
{
    #region References
    //Ahora mismo todo esta serializado porque no se si quereis el debuff manager en el player o en algun otro lado
    [SerializeField]
    private PlayerController _playerController; //Para el da�o de balas
    [SerializeField]
    private MovementController _movementController; //Para velocidad de movimiento
    [SerializeField]
    private UIManager _uiManager; //Para la mira
    [SerializeField]
    private LifeComponent _lifeComponent; //Para el da�o recibido
    [SerializeField]
    private ShooterController _shooterController; //Para la cadencia
    [SerializeField]
    private CamaraController _cameraController; //Para la sensibilidad e invertir los ejes
    #endregion
    #region Parameters
    //cantidad que bajan, array de ints (la mayoria lo son y los que no toman valores enteros) para no 
    //tener ochenta parametros diferentes
    [Tooltip("Cantidad que disminuye/aumenta cada debuff (no el valor que toma). " +
        "Orden debuffs: da�o hecho, velocidad movimiento, friccion, da�o recibido, cadencia, sensibilidad camara")]
    [SerializeField]
    private int[] _debuffs = new int [6];
    #endregion
    #region Properties
    private int _da�oBalasActual; //Ya que el da�o de las balas se setea para cada bala,
                                  //va almacenando el valor para que se pueda stackear el efecto
    //booleano para testing
    //public bool _a;
    #endregion
    #region Methods
    private void LessDamageDebuff()
    {
        _da�oBalasActual -= _debuffs[0];
        _playerController.SetDa�oBalas(_da�oBalasActual);
    }
    private void LessVelocity()
    {
        _movementController._walkSpeed -= _debuffs[1];
        _movementController._maxRunSpeed -= _debuffs[1];
    }
    private void HideCrosshair()
    {
        _uiManager.HideCrossHair();
    }
    private void MixAxis()
    {
        _cameraController.InvertirEjes(); 
    }
    private void SlimeDamage()
    {
        _lifeComponent._damageMultiplier += _debuffs[3];
    }
    private void LessBullets()
    {
        _shooterController._cadenciaDisparo -= (float) _debuffs[4] / 10;
    }
    private void CameraVelocity()
    {
        _cameraController._sens += _debuffs[5];
    }
    
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        /* Testing
        _da�oBalasActual = _playerController._da�oBalasBase;
        Debug.Log("da�o balas actual " + _playerController._da�oBalasBase);
        Debug.Log("andar" + _movementController._walkSpeed + " correr " +  _movementController._maxRunSpeed);
        Debug.Log("slime damage" + _lifeComponent._damageMultiplier);
        Debug.Log("cadencia " + _shooterController._cadenciaDisparo);
        Debug.Log("sens" + _cameraController._sens);*/
    }

    // Update is called once per frame
    void Update()
    {
        /* Mas testing
        if (_a)
        {
            _a = false;
            LessDamageDebuff(); Debug.Log("da�o balas actual " + _da�oBalasActual);
            LessVelocity(); Debug.Log("andar" + _movementController._walkSpeed + " correr " + _movementController._maxRunSpeed);
            //HideCrosshair();
            MixAxis();
            SlimeDamage(); Debug.Log("slime damage" + _lifeComponent._damageMultiplier);
            LessBullets(); Debug.Log("cadencia " + _shooterController._cadenciaDisparo);
            CameraVelocity(); Debug.Log("sens" + _cameraController._sens);
        }*/
    }
}
