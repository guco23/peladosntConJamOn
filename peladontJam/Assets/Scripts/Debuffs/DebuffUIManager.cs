using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebuffUIManager : MonoBehaviour
{

    public enum Debuffs { LessDamage, LessVelocity, MoreSlippy, MixAxis, SlimeDamage, LessBullets, CameraVelocity}

    #region references

    [SerializeField]
    private Sprite[] _debuffIcons;

    [SerializeField]
    private Color[] _colors;

    #endregion

    #region parameters

    private int _numberOfSlot = 0;

    #endregion

    #region methods

    public void AddDebuff(int debuff)
    {
        if (_numberOfSlot < 7)
        {
            transform.GetChild(_numberOfSlot).GetComponent<Image>().sprite = _debuffIcons[debuff];
            transform.GetChild(_numberOfSlot).GetComponent<Image>().color = _colors[debuff];
        }
        else
        {
            
        }
       
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
