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
    private LifeComponent _lifeComponent; //Para el da�o recibido
    [SerializeField]
    private ShooterController _shooterController; //Para la cadencia
    [SerializeField]
    private CamaraController _cameraController; //Para la sensibilidad e invertir los ejes
    [SerializeField]
    private UIManager _uiManager; //Para la mira
    #endregion
    #region Parameters
    //cantidad que aumentan/disminuyen los parametros de cada debuff
    [SerializeField]
    private int _damageDebuff;
    [SerializeField]
    private float _speedDebuff;
    [SerializeField]
    private int _damageReceivedDebuff;
    [SerializeField]
    private float _rateOfFireDebuff;
    [SerializeField]
    private float _sensDebuff;
    #endregion
    #region Properties
    //Valores originales de los par�metros
    private int _originalDamageDealt;
    private float _originalWalkSpeed;
    private float _originalRunSpeed;
    private int _originalDamageReceived;
    private float _originalRateOfFire;
    private float _originalSens;

    private int _currentDamage; //Ya que el da�o de las balas se setea para cada bala,
                                  //va almacenando el valor para que se pueda stackear el efecto

    //Array que sirve para el conteo de los efectos. Codificacion:
    //0 = LessDamage, 1 = LessVelocity, 2 = SlimeDamage, 3 = LessBullets
    //4 = CameraVelocity, 5 = MixAxis, 6 = HideCrosshair
    private int[] _debuffContador = new int[7];

    /*booleanos para testing
    public bool _a;
    public bool _b;*/
    #endregion
    #region Methods
    //Conjunto de metodos que aplican debuffs
    private void LessDamageDebuff()
    {
        _currentDamage -= _damageDebuff;
        _playerController.SetDa�oBalas(_currentDamage);
        _debuffContador[0]++; 
    }
    private void LessVelocity()
    {
        _movementController._walkSpeed -= _speedDebuff;
        _movementController._maxRunSpeed -= _speedDebuff;
        _debuffContador[1]++;
    }
    private void SlimeDamage()
    {
        _lifeComponent._damageMultiplier += _damageReceivedDebuff;
        _debuffContador[2]++;
    }
    private void LessBullets()
    {
        _shooterController._cadenciaDisparo -= _rateOfFireDebuff;
        _debuffContador[3]++;
    }
    private void CameraVelocity()
    {
        _cameraController._sens += _sensDebuff;
        _debuffContador[4]++;
    }
    private void MixAxis()
    {
        _cameraController.InvertirEjes();
        _debuffContador[5]++;
    }
    private void HideCrosshair()
    {
        _uiManager.HideCrossHair();
        _debuffContador[6]++;
    }
    
    //Conjunto de m�todos que eliminan debuffs
    private void ElimDamageDebuff()
    {
        _playerController._da�oBalasBase = _originalDamageDealt;
        _debuffContador[0]--;
    }
    private void ElimSpeedDebuff()
    {
        _movementController._walkSpeed = _originalWalkSpeed;
        _movementController._maxRunSpeed = _originalRunSpeed;
        _debuffContador[1]--;
    }
    private void ElimSlimeDebuff()
    {
        _lifeComponent._damageMultiplier = _originalDamageReceived;
        _debuffContador[2]--;
    }
    private void ElimLessBulletsDebuff()
    {
        _shooterController._cadenciaDisparo = _originalRateOfFire;
        _debuffContador[3]--;
    }
    private void ElimCameraSpeedDebuff()
    {
        _cameraController._sens = _originalSens;
        _debuffContador[4]--;
    }
    private void ElimAxisDebuff()
    {
        _cameraController.InvertirEjes();
        _debuffContador[5]--;
    }
    private void ElimCrosshairDebuff()
    {
        _uiManager.ShowCrossHair();
        _debuffContador[6]--;
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _originalDamageDealt = _playerController._da�oBalasBase;
        _originalWalkSpeed = _movementController._walkSpeed;
        _originalRunSpeed = _movementController._maxRunSpeed;
        _originalDamageReceived = _lifeComponent._damageMultiplier;
        _originalRateOfFire = _shooterController._cadenciaDisparo;
        _originalSens = _cameraController._sens;
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
        /* More testing
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
        }
        if(_b)
        {
            _b= false;
            ElimAxisDebuff();
            ElimCameraSpeedDebuff();
            //ElimCrosshairDebuff();
            ElimDamageDebuff();
            ElimLessBulletsDebuff();
            ElimSlimeDebuff();
            ElimSpeedDebuff();
        }*/
    }
}
