using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShooterController : MonoBehaviour
{

    [SerializeField]
    GameObject _balaPrefab;
    [SerializeField]
    float _cadenciaDisparo;

    float _reloj;

    // Start is called before the first frame update
    void Start()
    {
        _reloj = _cadenciaDisparo;
    }

    // Update is called once per frame
    void Update()
    {
        _reloj += Time.deltaTime;
    }

    public void Disparar(InputAction.CallbackContext context)
    {
        if (_reloj > _cadenciaDisparo && context.started)
        {
            GameObject bala = Instantiate(_balaPrefab, transform.position, Quaternion.identity);
            _reloj = 0;
        }
    }

    
}
