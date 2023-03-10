using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public static EnemiesManager Instance { get; private set; }

    public delegate void mydelegate();

    public mydelegate[] entrys = new mydelegate[3];
    public mydelegate[] exits = new mydelegate[3];
    
    //CREO QUE NO HACEN FALTA
    /*
    public mydelegate RedEnemiesEntry;
    public mydelegate GreenEnemiesEntry;
    public mydelegate BlueEnemiesEntry;
    public mydelegate RedEnemiesExit;
    public mydelegate GreenEnemiesExit;
    public mydelegate BlueEnemiesExit;
    */
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
