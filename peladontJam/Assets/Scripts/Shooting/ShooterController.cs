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
        _cadenciaDisparo = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(InputManager.Instance.GetMouseClick())
        {
            Debug.Log("pene");
            Disparar();
        }
    }

    public void Disparar()
    {
        Instantiate(_balaPrefab, transform, true);
    }

    
}
