using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColorConfirmationComponent : MonoBehaviour
{
    [SerializeField]
    private Material _materialToCompare;
    private int[] _playerColor;
    private ColorController _myColorController;

    private bool _canCompare;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<ColorManager>() != null)
        {
            _playerColor = other.gameObject.GetComponent<ColorManager>().Colors;
            _canCompare = true;
            //if (_myColorController.ColoresIguales(_myColorController.GeneraColor(_playerColor[0], _playerColor[1], _playerColor[2]), _materialToCompare.color))
            //{
            //    Debug.Log("Tu vieja colorada");
            //    GameManager.Instance.PotionCorrect(_myColorController.GeneraColor(_playerColor[0], _playerColor[1], _playerColor[2]));
            //}
            //else
            //{
            //    Debug.Log("ColorEquivocado");
            //    GameManager.Instance.PotionFailed(_myColorController.GeneraColor(_playerColor[0], _playerColor[1], _playerColor[2]));
            //}
        }
    }
    public void GivePotion(InputAction.CallbackContext context)
    {
        if (_canCompare && context.performed)
        {
            if (_myColorController.ColoresIguales(_myColorController.GeneraColor(_playerColor[0], _playerColor[1], _playerColor[2]), 
                _materialToCompare.color))
            {
                Debug.Log("Tu vieja colorada");
                GameManager.Instance.PotionCorrect(_myColorController.GeneraColor(_playerColor[0], _playerColor[1], _playerColor[2]));
            }
            else
            {
                Debug.Log("ColorEquivocado");
                GameManager.Instance.PotionFailed(_myColorController.GeneraColor(_playerColor[0], _playerColor[1], _playerColor[2]));
            }
            _canCompare = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _myColorController = GameManager.Instance.GetComponent<ColorController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
