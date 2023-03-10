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

    #region methods 

    public void CatchColor(int color)
    {
        if (color == 1)
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
    }

    private void SendPercent()
    {

    }

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
