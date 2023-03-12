using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleComponent : MonoBehaviour
{
    private ColorManager.colors _color;

    [SerializeField]
    private float _alturaY;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, _alturaY, transform.position.z);
    }
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
            SoundComponent.Instance.PlaySound(SoundComponent.Instance._pickUpPuddle);
            _manager.AddColor((int) _color);
            GameManager.Instance.ColorPicked((int) _color);
            Debug.Log("Tu vieja en bañera");
            Destroy(gameObject);
        }
    }  
}
