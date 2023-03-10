using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ColorBarManager : MonoBehaviour
{

    #region parameters

    private int _amountOfRed;
    private int _amountOfGreen;
    private int _amountOfBlue;
    private int _totalAmount;

    #endregion

    #region Properties

    private Slider slider;

    #endregion

    #region references
    [SerializeField]
    private GameObject _redBar;

    [SerializeField]
    private GameObject _greenBar;

    [SerializeField]
    private GameObject _blueBar;

    #endregion 

    #region methods 

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
        else if (color == 1)
        {
            _amountOfBlue++;
        }

        _totalAmount++;

        SendPercent();
    }

    private void SendPercent() //Cambia el relleno de las barras mediante una regla de tres
    {
        _redBar.GetComponent<Slider>().value = (_amountOfRed * 100) / _totalAmount;
        _greenBar.GetComponent<Slider>().value = (_amountOfGreen * 100) / _totalAmount;
        _blueBar.GetComponent<Slider>().value = (_amountOfBlue * 100) / _totalAmount;
    }

    #endregion


    // Update is called once per frame
    void Update()
    {

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
