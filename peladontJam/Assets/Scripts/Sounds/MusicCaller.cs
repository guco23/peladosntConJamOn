using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCaller : MonoBehaviour
{
    [SerializeField] private MusicComponent _myMusicComponent;
    [SerializeField] private bool _blue;
    [SerializeField] private bool _green;
    [SerializeField] private bool _red;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((bool)other.GetComponent<PlayerController>())
        {
            if (_blue)
            {
                _myMusicComponent._playBlue = true;
            }
            if (_green)
            {
                _myMusicComponent._playGreen = true;
            }
            if (_red)
            {
                _myMusicComponent._playRed = true;
            }
        }
    }
}
