using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaBehaviour : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Camera.main.gameObject.transform.forward);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
