using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamaraController : CinemachineExtension
{
    #region References
    private InputManager _inputManager;
    #endregion
    #region Parameters
    [Tooltip("Angulo max que se puede mover la camara en vertical")] //El angulo
    [SerializeField]
    private float _rotationAngle = 80f;
    [Tooltip("Sensibilidad de la camara")]
    [SerializeField]
    private float _sens = 50f;
    #endregion
    #region Properties
    private Vector3 _rotation;
    private int _inversionFactor = 1;
    #endregion
    #region Methods
    /// <summary>
    /// Método que sirve para mover la cámara, pilla el input, modifica la rotacion y en el caso del eje y solo deja que
    /// esté en un  intervalo
    /// </summary>
    /// <param name="vcam"></param>
    /// <param name="stage"></param>
    /// <param name="state"></param>
    /// <param name="deltaTime"></param>
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow)
        {
            if (stage == CinemachineCore.Stage.Aim) //Durante la stage de apuntado
            {
                if (_rotation == null) 
                    _rotation = transform.localRotation.eulerAngles; 

                Vector2 deltaInput = _inputManager.GetMouseDelta(); //Recoge input

                _rotation.x += deltaInput.x * _sens * Time.deltaTime; //calcula la rotacion
                _rotation.y += deltaInput.y * _sens * Time.deltaTime;
                _rotation.y = Mathf.Clamp(_rotation.y, -_rotationAngle, _rotationAngle); //Capa la rotacion vertical

                state.RawOrientation = Quaternion.Euler(-_rotation.y * _inversionFactor, _rotation.x * _inversionFactor, 0f); //setea la rotacion, el "-" que lleva es
                                                                                        //para evitar que el eje vertical de la camara invertido
            }
        }
    }

    public void InvertirEjes()
    {
        _inversionFactor= -_inversionFactor;
    }
    #endregion
    protected override void Awake() //Setea la referencia al Input manager 
    {
        _inputManager = InputManager.Instance;
        base.Awake();
    }
}

