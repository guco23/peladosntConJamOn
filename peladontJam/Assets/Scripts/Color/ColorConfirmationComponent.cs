using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorConfirmationComponent : MonoBehaviour
{
    [SerializeField]
    private Material _materialToCompare;
    private int[] _playerColor;
    [SerializeField] //proximamente en su gameManager de confianza
    private ColorController _myColorController;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<ColorManager>() != null)
        {
            _playerColor = other.gameObject.GetComponent<ColorManager>().Colors;
            if (_myColorController.ColoresIguales(_myColorController.GeneraColor(_playerColor[0], _playerColor[1], _playerColor[2]), _materialToCompare.color))
            {
                Debug.Log("Tu vieja colorada");

            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       // _materialToCompare = _myColorController.Material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
