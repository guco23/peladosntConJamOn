using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    TextMeshProUGUI _puntuacion;
    [SerializeField]
    DebuffUIManager _debuffUIManager;

    [Header("Menus")]
    [SerializeField]
    private GameObject _startMenu;
    [SerializeField]
    private GameObject _endMenu;
    [SerializeField]
    private GameObject _gameMenu;

    #endregion

    #region properties
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

    public void EliminaTodosLosDebuffs()
    {
        _debuffUIManager.EliminaTodosLosDebuffs();
    }
    public void GoToGame(string nombreEscena)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(nombreEscena);
    }

    public void SetPuntuacion(string puntuacion)
    {
        _puntuacion.text = puntuacion;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void ReturnGame()
    {
        SceneManager.LoadScene("_Final");
    }
}
