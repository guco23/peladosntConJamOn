using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    /*
     * Trabajar con valores rgb. Un int del 0 al 255 para cada color. El 0,0,0 es el negro, el 255, 255, 255 es el blanco.
     * Hay que hacer un metodo para pasar los valores de los pigmentos que tenemos a una rueda de colores o blanco (que no haya negro)
     * Otro metodo para comparar colores, y que si es un color cercano en la rueda cromática validarlo.
     * 
     * Metodo para mostrar los colores en pantalla lol
     * 
     */

    //Los colores que tiene el jugador
    int _red;
    int _green;
    int _blue;

    void Start()
    {
        ResetColor();   
    }

    private void ResetColor()
    {
        _red = 0;
        _green = 0;
        _blue = 0;
    }

}
public class ColorCombinacion {
    //Clase que representa un color específico.
    int _RGBred;
    int _RGBgreen;
    int _RGBblue;

    public ColorCombinacion(int red, int green, int blue)
    {
        ProportionToColor(red, green, blue);
    }

    /// <summary>
    /// Pasa una cantidad de pintura a partir de una proporcion a rgb.
    /// </summary>
    /// <param name="redPaint">La cantidad de pintura roja</param>
    /// <param name="greenPaint">La cantidad de pintura verde</param>
    /// <param name="bluePaint">La cantidad de pintura azul</param>
    private void ProportionToColor(int redPaint, int greenPaint, int bluePaint)
    {
        
    }

    private int CalcularSaturacion() {
        return 0;
    }
    private int CalcularIntensidad() {
        return 0;
        }

}
