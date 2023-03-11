using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeComponent : MonoBehaviour
{
    #region Parameters
    [SerializeField]
    [Range(0f,1f)]
    [Tooltip("La escala que tendrá el enemigo cuando su vida sea 0, sirve para ajustar cuanto de pequeño quieres que se haga")]
    private float _escalaMinima;
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
        _myTransform.localScale = Vector3.one *(float) (_escalaMinima + (1-_escalaMinima)* ((float)_myLifeComponent.GetCurrentLife() / _myLifeComponent.GetMaxLife()));
    }
}
