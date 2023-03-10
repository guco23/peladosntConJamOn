using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleComponent : MonoBehaviour
{
    private ColorManager.colors _color;


    public void SetColor(ColorManager.colors color)
    {
        _color = color;
    }

    private void OnTriggerEnter(Collider other)
    {
        ColorManager _manager = other.gameObject.GetComponent<ColorManager>();
        if (_manager != null)
        {
            _manager.AddColor((int) _color);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
