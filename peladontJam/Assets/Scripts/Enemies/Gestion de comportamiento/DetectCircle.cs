using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCircle : MonoBehaviour
{
    [SerializeField] private MusicComponent _myMusicComponent;
    [SerializeField] private int _color;
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<InputManager>() != null)
        {

            ShooterController.instance.EnterArea();
            EnemiesManager.Instance.entrys[_color]();
            if (_color == 0) _myMusicComponent._playRed = true;
            else if (_color == 1) _myMusicComponent._playGreen = true;
            else if (_color == 2) _myMusicComponent._playBlue = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("tu vieja exit");

        ShooterController.instance.ExitArea();
        EnemiesManager.Instance.exits[_color]();
        _myMusicComponent._playTotal = true; 
    }
}
