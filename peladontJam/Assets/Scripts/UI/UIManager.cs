using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField]
    HitBorder _hitBorder;

    [SerializeField]
    DebuffUIManager _debuffUIManager;

    #endregion

    #region properties

    private GameObject _startMenu;
    private GameObject _endMenu;
    private GameObject _gameMenu;
    private GameObject _actualMenu;

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
    public void HitRecived()
    {
        _hitBorder.HitRecived();
    }
    public void ResetColors()
    {
        _colorBarManager.ResetColors();
    }

    public void ChangeMenu(GameManager.GameStates gameState, GameManager.GameStates beforeState)
    {

        if (gameState == GameManager.GameStates.Game)
        {
            _gameMenu.SetActive(true);
            if (beforeState == GameManager.GameStates.Start)
            {
                _startMenu.SetActive(false);
            }
            else if (beforeState == GameManager.GameStates.GameOver)
            {
                _endMenu.SetActive(false);
            }
        }
        else if (gameState == GameManager.GameStates.GameOver)
        {
            _endMenu.SetActive(true);
            _gameMenu.SetActive(false);
        }
    }

    public void RequestStateChange(int newState)
    {
        GameManager.Instance.RequestStateChange((GameManager.GameStates)newState);
    }

    public void AddDebuff(int v)
    {
        _debuffUIManager.AddDebuff(v);
    }
}
