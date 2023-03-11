using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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
    #endregion
    //La cantidad de rondas que lleva ganadas el juegador.
    private int puntos;

    #region Properties
    public bool DEBUG;
    #endregion
    #region Accesor
    public GameObject Player { get { return _player; } }
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

        //TODO
        /*
         * Obtener un efecto negativo 
         * Notificar a la UI el nuevo efecto
         */

        //Comenzar una nueva petición.?????
        //NewPotionPetition();
    }
    public void PotionCorrect(Color color)
    {

        /*
         * Perder todos los efectos negativos.
         * 
         */
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
}
