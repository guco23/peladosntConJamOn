using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public enum colors { red,green,blue};

    //Los colores que tiene el jugador Rojo Verde Azul
    public int [] Colors = new int[3];
    [SerializeField]
    private Material _customMAterial;

    void Start()
    {
        ResetCantidades();
        _customMAterial.color = GameManager.Instance.GetComponent<ColorController>().GeneraColor(Colors[0], Colors[1], Colors[2]);
    }

    private void Update()
    {
        if (GameManager.Instance.DEBUG)
        {
            _customMAterial.color = GameManager.Instance.GetComponent<ColorController>().GeneraColor(Colors[0], Colors[1], Colors[2]);
        }        
    }

    public void ResetCantidades()
    {
        for (int i = 0; i < Colors.Length; i++) Colors[i] = 0;
    }

    public void AddColor(int color)
    {
        Colors[color]++;
        //Hacer llamada al CatchColor dentro del ColorBarManager,
        //componente que tiene el GameObject ColorBars y pasarle el "int color" del parentesis
    }

    public bool HasColor()
    {
        return Colors[1] != 0 || Colors[2] != 0 || Colors[0] != 0;
    }
}