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
        Debug.Log("TU Vieja:" + gameObject.name);
        ColorManager _manager = other.gameObject.GetComponent<ColorManager>();
        if (_manager != null)
        {
            _manager.AddColor((int) _color);
            //ColorBarManager.Instance.CatchColor((int)_color);
            GameManager.Instance.ColorPicked((int) _color);
            Destroy(gameObject);
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
