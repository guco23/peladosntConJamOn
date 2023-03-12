using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebuffUIManager : MonoBehaviour
{

    #region references

    [SerializeField]
    private Sprite[] _debuffIcons; //Se encarga de guardar los diferentes iconos de los debuffs para aplicarselo en el momento correspondiente

    [SerializeField]
    private Color[] _colors; //Se encarga de almacenar los diferentes colores de los debuffs para aplicarlos cuando sea necesario

    #endregion

    #region parameters

    private int _numberOfSlot = 0; //Numero de slots ocupados por debuffs

    #endregion

    #region properties

    private int[] _debuffs = new int [6]; //Los diferentes debuffs que se han aplicado al jugador

    #endregion

    #region methods

    public void AddDebuff(int debuff) //Método para almacenar un nuevo debuff, teniendo que enviar el debuff que se le aplica (por numero)
    {        
        if (_numberOfSlot < _debuffs.Length) //Si no esta llena la lista de debuffs el nuevo se almacena en el seguiente espacio libre
        {
            transform.GetChild(_numberOfSlot).GetComponent<Image>().sprite = _debuffIcons[debuff];
            transform.GetChild(_numberOfSlot).GetComponent<Image>().color = _colors[debuff];
            _debuffs[_numberOfSlot] = debuff;
            _numberOfSlot++;
        }
        else //Si esta llena la lista se sobrescribe en el último y se desplazan el resto, sobrescribiendo de uno en uno
        {
            transform.GetChild(_numberOfSlot - 1).GetComponent<Image>().sprite = _debuffIcons[debuff];
            transform.GetChild(_numberOfSlot - 1).GetComponent<Image>().color = _colors[debuff];
            
            for (int i = _numberOfSlot - 2; i >= 0; i--)
            {
                transform.GetChild(i).GetComponent<Image>().sprite = _debuffIcons[_debuffs[i + 1]];
                transform.GetChild(i).GetComponent<Image>().color = _colors[_debuffs[i + 1]];
            }

            _debuffs[_numberOfSlot - 1] = debuff;

            for (int i = 0; i <= _numberOfSlot - 1; i++)
            {
                _debuffs[i] = _debuffs[i + 1];
            }
        }
       
    }

    #endregion

    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _colors.Length; i++) _colors[i].a = 1;  
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
