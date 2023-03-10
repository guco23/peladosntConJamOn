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
    [Tooltip("Valor maximo que se puede mover la camara en vertical")] //El angulo
    [SerializeField]
    private float _rotationAngle = 80f;
    [Tooltip("Sensibilidad horizontal de la camara")]
    [SerializeField]
    private float _horizontalSens = 50f;
    [Tooltip("Sensibilidad horizontal de la camara")]
    [SerializeField]
    private float _verticalSens = 50f;
    #endregion
    #region Properties
    private Vector3 _rotation;
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

                _rotation.x += deltaInput.x * _horizontalSens * Time.deltaTime; //calcula la rotacion
                _rotation.y += deltaInput.y * _verticalSens * Time.deltaTime;
                _rotation.y = Mathf.Clamp(_rotation.y, -_rotationAngle, _rotationAngle); //Capa la rotacion vertical

                state.RawOrientation = Quaternion.Euler(-_rotation.y, _rotation.x, 0f); //setea la rotacion, el "-" que lleva es
                                                                                        //para evitar que el eje vertical de la camara invertido
            }
        }
    }
    #endregion
    protected override void Awake() //Setea la referencia al Input manager 
    {
        _inputManager = InputManager.Instance;
        base.Awake();
    }
}

