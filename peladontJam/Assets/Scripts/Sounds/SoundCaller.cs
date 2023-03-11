using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCaller : MonoBehaviour
{
    private AudioSource _myAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        _myAudioSource = GetComponent<AudioSource>();

        _myAudioSource.PlayOneShot(SoundComponent.Instance._slimeJump);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
