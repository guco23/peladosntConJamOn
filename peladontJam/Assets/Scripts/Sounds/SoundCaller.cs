using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCaller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(SoundComponent.Instance._slimeJump);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
