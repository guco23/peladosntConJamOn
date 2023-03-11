using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundComponent : MonoBehaviour
{
    public AudioClip _shoot;                    // +-
    //public AudioClip _idle;
    //public AudioClip _walking;
    //public AudioClip _running;
    public AudioClip _receiveDamage;
    public AudioClip _slimeJump;                // +-
    public AudioClip _pickUpPuddle;             // --

    #region Singleton
    static private SoundComponent _instance;
    public static SoundComponent Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
