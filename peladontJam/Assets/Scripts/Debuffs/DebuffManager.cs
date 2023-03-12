using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffManager : MonoBehaviour
{
    #region References
    //Ahora mismo todo esta serializado porque no se si quereis el debuff manager en el player o en algun otro lado
    [SerializeField]
    private PlayerController _playerController; //Para el daño de balas
    [SerializeField]
    private MovementController _movementController; //Para velocidad de movimiento
    [SerializeField]
    private LifeComponent _lifeComponent; //Para el daño recibido
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
    private float _damageReceivedDebuff;
    [SerializeField]
    private float _rateOfFireDebuff;
    [SerializeField]
    private float _sensDebuff;
    #endregion
    #region Properties
    //Valores originales de los parámetros
    private int _originalDamageDealt;
    private float _originalWalkSpeed;
    private float _originalRunSpeed;
    private float _originalDamageReceived;
    private float _originalRateOfFire;
    private float _originalSens;

    private int _currentDamage; //Ya que el daño de las balas se setea para cada bala,
                                  //va almacenando el valor para que se pueda stackear el efecto

    //Array que sirve para el conteo de los efectos. Codificacion:
    //0 = LessDamage, 1 = LessVelocity, 2 = SlimeDamage, 3 = LessBullets
    //4 = CameraVelocity, 5 = MixAxis, 6 = HideCrosshair
    private int[] _debuffContador = new int[7];

    /*booleanos para testing
    public bool _a;
    public bool _b;*/
    #endregion
    #region Methods{

    public void ApplyDebuff(int indexDebuff)
    {
        if (indexDebuff == 0) LessDamageDebuff();
        else if (indexDebuff == 1) LessVelocity();
        else if (indexDebuff == 2) SlimeDamage();
        else if (indexDebuff == 3) LessBullets();
        else if (indexDebuff == 4) CameraVelocity();
        else if (indexDebuff == 5) MixAxis();
        else if (indexDebuff == 6) HideCrosshair();        
    }
    //Conjunto de metodos que aplican debuffs
    private void LessDamageDebuff()
    {
        _currentDamage -= _damageDebuff;
        _playerController.SetDañoBalas(_currentDamage);
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
    
    //Conjunto de métodos que eliminan debuffs
    public void EliminaTodos()
    {
        for(int i =0; i < _debuffContador.Length; i++) if (_debuffContador[i] > 0) EliminameEsta(i);
    }
    private void EliminameEsta(int indexDebuff)
    {
        if (indexDebuff == 0) ElimDamageDebuff();
        else if (indexDebuff == 1) ElimSpeedDebuff();
        else if (indexDebuff == 2) ElimSlimeDebuff();
        else if (indexDebuff == 3) ElimLessBulletsDebuff();
        else if (indexDebuff == 4) ElimCameraSpeedDebuff();
        else if (indexDebuff == 5) ElimAxisDebuff();
        else if (indexDebuff == 6) ElimCrosshairDebuff();
    }
    #region EliminadoresTotales

    private void ElimDamageDebuff()
    {
        _playerController.SetDañoBalas(_originalDamageDealt);
        _debuffContador[0] = 0;
    }
    private void ElimSpeedDebuff()
    {
        _movementController._walkSpeed += _originalWalkSpeed;
        _movementController._maxRunSpeed += _originalRunSpeed;
        _debuffContador[1] = 0;
    }
    private void ElimSlimeDebuff()
    {
        _lifeComponent._damageMultiplier = _originalDamageReceived;
        _debuffContador[2] =0;
    }
    private void ElimLessBulletsDebuff()
    {
        _shooterController._cadenciaDisparo = _originalRateOfFire;
        _debuffContador[3] = 0;
    }
    private void ElimCameraSpeedDebuff()
    {
        _cameraController._sens = _originalSens;
        _debuffContador[4] = 0;
    }
    private void ElimAxisDebuff()
    {
        _cameraController.InvertirEjes();
        _debuffContador[5] = 0;
    }
    private void ElimCrosshairDebuff()
    {
        _uiManager.ShowCrossHair();
        _debuffContador[6] = 0;
    }
    #endregion

    #region EliminadoresParciales

    private void ElimDamageDebuffParcial()
    {
        _currentDamage -= _damageDebuff;
        _playerController.SetDañoBalas(_currentDamage);
        _debuffContador[0]--;
    }
    private void ElimSpeedDebuffParcial()
    {
        _movementController._walkSpeed += _speedDebuff;
        _movementController._maxRunSpeed += _speedDebuff;
        _debuffContador[1]--;
    }
    private void ElimSlimeDebuffParcial()
    {
        _lifeComponent._damageMultiplier -= _damageReceivedDebuff;
        _debuffContador[2]--;
    }
    private void ElimLessBulletsDebuffParcial()
    {
        _shooterController._cadenciaDisparo += _rateOfFireDebuff;
        _debuffContador[3]--;
    }
    private void ElimCameraSpeedDebuffParcial()
    {
        _cameraController._sens -= _sensDebuff;
        _debuffContador[4]--;
    }
    private void ElimAxisDebuffParcial()
    {
        _cameraController.InvertirEjes();
        _debuffContador[5]--;
    }
    private void ElimCrosshairDebuffParcial()
    {
        _uiManager.ShowCrossHair();
        _debuffContador[6]--;
    }
    #endregion


    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameManager.Instance.Player.GetComponent<PlayerController>();
        _movementController = GameManager.Instance.Player.GetComponent<MovementController>();
        _lifeComponent = GameManager.Instance.Player.GetComponent<LifeComponent>();
        _shooterController = GameManager.Instance.Player.GetComponent<ShooterController>();
        _uiManager = GameManager.Instance.UImanager;

        _originalDamageDealt = _playerController._dañoBalasBase;
        _originalWalkSpeed = _movementController._walkSpeed;
        _originalRunSpeed = _movementController._maxRunSpeed;
        _originalDamageReceived = _lifeComponent._damageMultiplier;
        _originalRateOfFire = _shooterController._cadenciaDisparo;
        _originalSens = _cameraController._sens;

        _currentDamage = _originalDamageDealt;
        /* Testing
        _dañoBalasActual = _playerController._dañoBalasBase;
        Debug.Log("daño balas actual " + _playerController._dañoBalasBase);
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
            LessDamageDebuff(); Debug.Log("daño balas actual " + _dañoBalasActual);
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
