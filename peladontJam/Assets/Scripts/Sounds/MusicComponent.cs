using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicComponent : MonoBehaviour
{
    #region Accessors
    #endregion

    #region Paramenters
    [SerializeField]
    private AudioSource _audioSourceBlue;
    [SerializeField]
    private AudioSource _audioSourceGreen;
    [SerializeField]
    private AudioSource _audioSourceRed;
    /// <summary>
    /// tiempo de la transicion
    /// </summary>
    [SerializeField]
    private float _fadeTime;
    /// <summary>
    /// umbral para que la transicion se complete rapidamente 
    /// </summary>
    [SerializeField]
    private float _umbralVolume;
    #endregion

    #region Properties
    [SerializeField] private bool _onBlue;
    [SerializeField] private bool _onGreen;
    [SerializeField] private bool _onRed;

    [SerializeField] private bool _playBlue;
    [SerializeField] private bool _playGreen;
    [SerializeField] private bool _playRed;

    private PlayerControlls _myPlayerControlls;
    #endregion

    #region Methods
    /// <summary>
    /// cambia la pista de audio a la indicada, progresivamente bajando las otras pistas
    /// </summary>
    /// 

    /// <summary>
    /// cambia la pista de audio a la indicada, progresivamente bajando las otras pistas
    /// </summary>
    public void ChangeMusic(AudioSource currentSource)
    {
        if (currentSource.volume <= _umbralVolume)
        {
            if (!_onBlue)
            {
                _audioSourceBlue.volume = Mathf.Lerp(_audioSourceBlue.volume, 0, Time.deltaTime * _fadeTime);
            }
            if (!_onGreen)
            {
                _audioSourceGreen.volume = Mathf.Lerp(_audioSourceGreen.volume, 0, Time.deltaTime * _fadeTime);
            }
            if (!_onRed)
            {
                _audioSourceRed.volume = Mathf.Lerp(_audioSourceRed.volume, 0, Time.deltaTime * _fadeTime);
            }

            currentSource.volume = Mathf.Lerp(currentSource.volume, 1, Time.deltaTime * _fadeTime);
        }
        else
        {
            if (!_onBlue)
            {
                _audioSourceBlue.volume = 0;
            }
            if (!_onGreen)
            {
                _audioSourceGreen.volume = 0;
            }
            if (!_onRed)
            {
                _audioSourceRed.volume = 0;
            }

            currentSource.volume = 1;
        }

    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _audioSourceBlue = transform.GetChild(0).GetComponent<AudioSource>();     // AudioSource BLUE
        _audioSourceGreen = transform.GetChild(1).GetComponent<AudioSource>();      // AudioSource GREEN
        _audioSourceRed = transform.GetChild(2).GetComponent<AudioSource>();      // AudioSource RED
        _myPlayerControlls = new PlayerControlls();
        ChangeMusic(_audioSourceBlue);
    }

    private void ChangeState (ref bool myState)
    {
        _onBlue = false;
        _onGreen = false;
        _onRed = false;
        myState = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_playBlue)
        {
            _playGreen = false;
            _playRed = false;
            ChangeState(ref _onBlue);
        }
        if (_playGreen)
        {
            _playBlue = false;
            _playRed = false;
            ChangeState(ref _onGreen);
        }
        if (_playRed)
        {
            _playGreen = false;
            _playBlue = false;
            ChangeState(ref _onRed);
        }

        if (_onBlue) ChangeMusic(_audioSourceBlue);
        if (_onGreen) ChangeMusic(_audioSourceGreen);
        if (_onRed) ChangeMusic(_audioSourceRed);
    }
}
