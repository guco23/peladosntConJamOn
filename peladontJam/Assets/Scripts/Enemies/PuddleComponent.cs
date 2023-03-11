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
        //Debug.Log("TU Vieja:" + gameObject.name);
        ColorManager _manager = other.gameObject.GetComponent<ColorManager>();
        if (_manager != null)
        {
            //añade el color en el manager, manda el mensaje a la UI y destruye el objeto
            _manager.AddColor((int) _color);
            GameManager.Instance.ColorPicked((int) _color);
            GetComponent<AudioSource>().PlayOneShot(SoundComponent.Instance._pickUpPuddle);
            Destroy(gameObject);
        }
    }  
}
