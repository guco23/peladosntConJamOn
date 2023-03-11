using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region References
    [SerializeField]
    ColorBarManager _colorBarManager;
    [SerializeField]
    LifeBarComponet _lifeBarComponet;
    [SerializeField]
    TextMeshProUGUI _textMessage;
    [SerializeField]
    GameObject _crossHair;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CatchColor(int color)
    {
        _colorBarManager.CatchColor(color);
    }
    public void UpdateHealth(int life)
    {
        _lifeBarComponet.UpdateHeath(life);
    }
    public void ShowMesagge(string mesagge)
    {
        _textMessage.text = mesagge;
    }
    public void HideCrossHair()
    {
        _crossHair.SetActive(false);
    }
    public void ShowCrossHair()
    {
        _crossHair.SetActive(true);
    }
}
