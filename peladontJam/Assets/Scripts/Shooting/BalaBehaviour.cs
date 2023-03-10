using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _fuerza;

    [SerializeField]
    private float _timeLife;

    [SerializeField]
    private static float _damage;


    private LayerMask _enemies;
    private Vector3 _direction;



    private void Start()
    {
        _enemies = LayerMask.GetMask("Enemies");
    }

    private void Update()
    {
        _timeLife -= Time.deltaTime;
        if (_timeLife < 0) Destroy(gameObject);
    }
    public void SetDirection(Vector3 direccion)
    {
        Debug.Log("tu vieja la chupa");
        _direction = direccion.normalized;
        GetComponent<Rigidbody>().AddForce(_direction * _fuerza, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == _enemies)// restar vida
        {
            Debug.Log("Enemigo");
            collision.gameObject.GetComponent<LifeComponent>().DealDamage(20);
        }
        Destroy(gameObject);
    }

    public static void SetDamage(float valor)
    {
        _damage = valor;
    }
}
