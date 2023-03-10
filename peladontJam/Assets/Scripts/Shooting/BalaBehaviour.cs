using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaBehaviour : MonoBehaviour
{
    [SerializeField]
    float _fuerza;

    Vector3 _direction;

    void Start()
    {
        //Ray rayCentro = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, Camera.main.nearClipPlane));
        //Vector3 direccionDisparo = rayCentro.GetPoint(10) - transform.position;
    }

    public void SetDirection(Vector3 direccion)
    {
        _direction = direccion.normalized;
        GetComponent<Rigidbody>().AddForce(_direction * _fuerza, ForceMode.Impulse);

    }
}
