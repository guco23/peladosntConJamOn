using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameStates { Start, Game, GameOver}

    #region References
    static private GameManager _instance;

    [SerializeField]
    SpawnerController[] _spawners;
    [SerializeField]
    GameObject _player;
    [Header("Managers")]
    [SerializeField]
    private UIManager _uiManager;
    private ColorController _colorController;
    private ColorManager _playerColorManager;

    [Header("Materiales")]
    [SerializeField]
    Material _colorPetition;
    [SerializeField]
    Material _colorCustom;
    [SerializeField]
    Material _closestWrongColor;

    DebuffManager _debuffManager;
    
    #endregion
    //La cantidad de rondas que lleva ganadas el juegador.
    private int puntos;

    #region Properties
    public bool DEBUG;
    private GameStates _actualState;
    private GameStates _beforeState;
    #endregion
    #region Accesor
    public GameObject Player { get { return _player; } }
    public UIManager UImanager { get { return _uiManager; } }
    #endregion

    public static GameManager Instance { get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
        
    }

    private void Start()
    {
        _colorController = GetComponent<ColorController>();
        _playerColorManager = _player.GetComponent<ColorManager>();
        _debuffManager = GetComponent<DebuffManager>();
        NewRound();
    }
    private void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void PlayerDied()
    {
        //TODO

        Debug.Log("Tu vieja murió");
        /*
         * Pantalla de Game Over
         * Reiniciar la escena.
         */
        RestartScene();
    }

    public void PotionFailed(Color color)
    {
        //usar este método para aplicar los debufos
        ColorController.ColorCodificacion colorCod = _colorController.DecodeColor(color);


        _debuffManager.ApplyDebuff((int)colorCod);
        _uiManager.AddDebuff((int)colorCod);
        _playerColorManager.ResetCantidades();
        _uiManager.ResetColors();
        //Comenzar una nueva petición.?????
        //NewPotionPetition();
    }
    public void PotionCorrect(Color color)
    {
        _uiManager.ResetColors();

        _uiManager.EliminaTodosLosDebuffs();
        _debuffManager.EliminaTodos();//quita los efectos del debuff en codido
        NewPotionPetition();
        KillAllSpawned();
        SpawnAll(); 
    }

    /// <summary>
    /// Método llamado al recoger un color para informar a la UI
    /// </summary>
    /// <param name="color"></param>
    public void ColorPicked(int color)
    {
        _uiManager.CatchColor(color);
    }
    /// <summary>
    /// Método que actualiza la barra de vida
    /// </summary>
    /// <param name="life"></param>
    public void UpdateHeath(int life)
    {
        _uiManager.UpdateHealth(life);
    }
    public void HitRecived()
    {
        _uiManager.HitRecived();
    }
    public void ShowMesage(string mesagge)
    {
        _uiManager.ShowMesagge(mesagge);
    }
    /// <summary>
    /// Comienza una nueva ronda, (nueva petición de color).
    /// </summary>
    private void NewRound()
    {   
        //Destruye todos los enemigos y regenera uno.
        KillAllSpawned();
        SpawnAll();
        NewPotionPetition();
        _playerColorManager.ResetCantidades();
        _uiManager.ResetColors();
    }


    /// <summary>
    /// Recorre cada spawner activando su spawn.
    /// </summary>
    private void SpawnAll() { 
        foreach(SpawnerController spawner in _spawners)
        {
            spawner.Spawn();
        }
    }
    
    /// <summary>
    /// Recorre cada spawner llamando al metodo de kill spawned.
    /// </summary>
    private void KillAllSpawned()
    {
        foreach (SpawnerController spawner in _spawners)
        {
            spawner.DespawnSpawned();
        }
    }

    private void NewPotionPetition()
    {
        //Resetea los colores del player
        _playerColorManager.ResetCantidades();
        //Nuevo color
        _colorPetition.color = _colorController.InicializaColor();
    }

    public void RequestStateChange(GameStates gameState)
    {
        if ((_actualState == GameStates.Start || _actualState == GameStates.GameOver) && gameState == GameStates.Game)
        {
            _beforeState = _actualState;
            _actualState = gameState;
        }
        else if(_actualState == GameStates.Start && gameState == GameStates.GameOver)
        {
            _beforeState = _actualState;
            _actualState = gameState;
        }


    }

    public void UpdateState(GameStates newGameState, GameStates beforeGameState) 
    {

        _uiManager.ChangeMenu(newGameState, beforeGameState);

        if (newGameState == GameStates.Game)
        {
            if (beforeGameState == GameStates.Start) 
            { 
                
            }
            else if (beforeGameState == GameStates.GameOver)
            {

            }
        }
        else if (newGameState == GameStates.GameOver)
        {

        }
    }
}
