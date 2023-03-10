using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    public void SetCadenciaDisparo(float cadenciaDisparo)
    {

    }

    [SerializeField]
    GameObject _balaPrefab;
    float _cadenciaDisparo;
    
    // Start is called before the first frame update
    void Start()
    {
        _cadenciaDisparo = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if((_cadenciaDisparo -= Time.deltaTime) < 0)
        {
            Debug.Log("pene");
            Disparar();
            _cadenciaDisparo = 4;
        }
    }

    public void Disparar()
    {

        GameObject bala = Instantiate(_balaPrefab, transform.position, Quaternion.identity);
    }

    
}
