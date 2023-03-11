using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCircle : MonoBehaviour
{
    [SerializeField]
    private int _color;
 
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("tu vieja enter");  
        EnemiesManager.Instance.entrys[_color]();
    }
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("tu vieja exit");

        EnemiesManager.Instance.exits[_color]();
    }
}
