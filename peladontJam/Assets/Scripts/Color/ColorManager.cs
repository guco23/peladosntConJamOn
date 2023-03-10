using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public enum colores { red,green,blue};

    //Los colores que tiene el jugador
    public int _red { get; private set; }
    public int _green { get; private set; }
    public int _blue { get; private set; }   

    void Start()
    {
        ResetCantidades();   
    }

    private void ResetCantidades()
    {
        _red = _blue = _green = 0;
    }

}