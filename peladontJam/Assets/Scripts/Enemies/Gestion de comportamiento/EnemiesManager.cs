using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public static EnemiesManager Instance { get; private set; }

    public delegate void mydelegate();

    public mydelegate[] entrys = new mydelegate[3];
    public mydelegate[] exits = new mydelegate[3];
       
    private void Awake()
    {
        Instance = this;
    }  
}
