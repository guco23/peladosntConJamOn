using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeComponent : MonoBehaviour
{
    #region Parameters
    [SerializeField]
    [Range(0f,1f)]
    [Tooltip("La escala que tendrá el enemigo cuando su vida sea 0, sirve para ajustar cuanto de pequeño quieres que se haga")]
    private float _escalaMin;
    [SerializeField]
    [Range(0f, 1f)]
    [Tooltip("El porcentaje de masa que tendrá el enemigo cuando su vida sea 0, para ajustar lo q salta")]
    private float _masaMin;
    [SerializeField]
    [Range(0f, 1f)]
    [Tooltip("La masa que tendrá el enemigo cuando su vida sea la maxima")]
    private float _masaMax;

    private float _masaActual;
    #endregion

    #region Properties
    private LifeComponent _myLifeComponent;
    private Transform _myTransform;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _myLifeComponent = GetComponent<LifeComponent>();
        _myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        //actualizacion de la escala
        _myTransform.localScale = Vector3.one *(float) (_escalaMin + (1-_escalaMin)* ((float)_myLifeComponent.GetCurrentLife() / _myLifeComponent.GetMaxLife()));
        _masaActual = _masaMax * (_masaMin + (1 - _masaMin) * ((float)_myLifeComponent.GetCurrentLife() / _myLifeComponent.GetMaxLife()));
    }
}
