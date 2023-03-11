using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitBorder : MonoBehaviour
{
    [SerializeField]
    Image _hitBorder;
    [SerializeField]
    float _alphaColorBorder;
    [SerializeField]
    float _interpolationSpeed;

    public void HitRecived()
    {
        _alphaColorBorder = 255;
    }
    // Start is called before the first frame update
    void Start()
    {
        _hitBorder.color = new Color(_hitBorder.color.r, _hitBorder.color.g, _hitBorder.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (_hitBorder.color.a > 0)
        {
            _alphaColorBorder = Mathf.Lerp(_hitBorder.color.a, 0, Time.deltaTime * _interpolationSpeed);
            _hitBorder.color = new Color(_hitBorder.color.r, _hitBorder.color.g, _hitBorder.color.b, _alphaColorBorder);
            {
                if (_alphaColorBorder < 2)
                    _alphaColorBorder = Mathf.Clamp(_alphaColorBorder, -1, 0);
            }
        }
    }
}
