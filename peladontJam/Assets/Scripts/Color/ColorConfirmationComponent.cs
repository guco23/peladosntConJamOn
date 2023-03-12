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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ColorManager>() != null)
        {
            if (other.gameObject.GetComponent<ColorManager>().HasColor())
            {
                _playerColor = other.gameObject.GetComponent<ColorManager>().Colors;
                _canCompare = true;
                GameManager.Instance.ShowMesage("F para entregar");
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ColorManager>() != null)
        {
            _playerColor = null;
            _canCompare = false;
            GameManager.Instance.ShowMesage("");
        }
    }

    public void GivePotion(InputAction.CallbackContext context)
    {
        if (_canCompare && context.performed)
        {
            Color c = _myColorController.GeneraColor(_playerColor[0], _playerColor[1], _playerColor[2]);

            if (_myColorController.ColoresIguales(c, _materialToCompare.color))
            {
                GetComponent<AudioSource>().PlayOneShot(SoundComponent.Instance._poisonSuccess);
                Debug.Log("Tu vieja colorada");
                GameManager.Instance.PotionCorrect(c);
            }
            else
            {
                GetComponent<AudioSource>().PlayOneShot(SoundComponent.Instance._poisonFailed);
                Debug.Log("ColorEquivocado");
                GameManager.Instance.PotionFailed(c);
            }
            _canCompare = false;
            GameManager.Instance.ShowMesage("");
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
