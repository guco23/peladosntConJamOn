using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeComponent : MonoBehaviour
{
    [SerializeField]
    private float _escalaMinima;

    

    private LifeComponent _myLifeComponent;
    private Transform _myTransform;

    // Start is called before the first frame update
    void Start()
    {
        _myLifeComponent = GetComponent<LifeComponent>();
        _myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _myTransform.localScale = Vector3.one *(float) (_escalaMinima + (1-_escalaMinima)* ((float)_myLifeComponent.GetCurrentLife() / _myLifeComponent.GetMaxLife()));
    }
}
