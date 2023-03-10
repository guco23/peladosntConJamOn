using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaBehaviour : MonoBehaviour
{
    [SerializeField]
    float _fuerza;

    void Start()
    {
        Ray rayCentro = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, Camera.main.nearClipPlane));
        Vector3 direccionDisparo = rayCentro.GetPoint(10) - transform.position;
        direccionDisparo.Normalize();

        GetComponent<Rigidbody>().AddForce(direccionDisparo * _fuerza, ForceMode.Impulse);

    }

    public void Move(Vector3 direccion3)
    {

    }
}
