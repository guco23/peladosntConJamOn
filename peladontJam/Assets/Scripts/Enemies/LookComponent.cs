using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookComponent : MonoBehaviour
{
    Transform _myTransfomr;
    [SerializeField]
    Transform _objetiveTransfom;
    private void Start()
    {
        _myTransfomr = transform;
    }
    // Update is called once per frame
    void Update()
    {
        _myTransfomr.forward = (_objetiveTransfom.position - _myTransfomr.position).normalized;
    }
}
