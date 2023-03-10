using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public enum colors { red,green,blue};

    //Los colores que tiene el jugador Rojo Verde Azul
    public int [] Colors = new int[3];

    void Start()
    {
        ResetCantidades();   
    }

    private void ResetCantidades()
    {
        for (int i = 0; i < Colors.Length; i++) Colors[i] = 0;
    }
    public void AddColor(int color)
    {
        Colors[color]++;
    }

}