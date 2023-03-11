using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ColorBarManager : MonoBehaviour
{
    public static ColorBarManager Instance { get; private set; }

    #region parameters

    public int _amountOfRed;
    public int _amountOfGreen;
    public int _amountOfBlue;
    public int _totalAmount;

    #endregion

    #region Properties


    #endregion

    #region references
    [SerializeField]
    private Slider _redBar;

    [SerializeField]
    private Slider _greenBar;

    [SerializeField]
    private Slider _blueBar;

    #endregion 

    #region methods 

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        ResetColors();
        SendPercent();
    }
    public void ResetColors()
    {
        _amountOfBlue = _amountOfGreen = _amountOfRed = _totalAmount = 0;
    }
    //Va sumando a la cantidad de cada color y al total
    public void CatchColor(int color)
    {
        if (color == 0)
        {
            _amountOfRed++;
            
        }
        else if (color == 1)
        {
            _amountOfGreen++;
        }
        else if (color == 2)
        {
            _amountOfBlue++;
        }

        _totalAmount++;

        SendPercent();
    }

    private void SendPercent() //Cambia el relleno de las barras mediante una regla de tres
    {
        //Debug.Log("tu vieja la mama");
        if(_totalAmount > 0)
        {
            _redBar.value = (float)(_amountOfRed * 100) / _totalAmount;
            _greenBar.value = (float)(_amountOfGreen * 100) / _totalAmount;
            _blueBar.value = (float)(_amountOfBlue ) * 100 / _totalAmount;
        }
        else
        {
            //Debug.Log("soy gil");
            _redBar.value = 0;
            _greenBar.value = 0;
            _blueBar.value = 0;
        }
    }

    #endregion


    // Update is called once per frame
    void Update()
    {
        _totalAmount = _amountOfBlue + _amountOfGreen + _amountOfRed;
        //Debug.Log(_totalAmount);
        SendPercent();
        //Queria probar el componente con el teclado directamente pero me dice que el input a cambiado o no se que.
        //Probandlo si eso

        /*
        if (Input.GetKeyDown(KeyCode.A))
        {
            CatchColor(0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            CatchColor(1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            CatchColor(2);
        }
        */
    }
}
