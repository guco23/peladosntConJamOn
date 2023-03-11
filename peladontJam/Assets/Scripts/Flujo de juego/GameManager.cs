using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region References
    static private GameManager _instance;

    [SerializeField]
    SpawnerController[] _spawners;
    [SerializeField]
    GameObject _player;

    private UIManager _uiManager;
    [SerializeField]
    private ColorBarManager _barManager;//meter dentro de la ui

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
    [SerializeField]
    private Color _requiredColor;
    //La cantidad de rondas que lleva ganadas el juegador.
    private int puntos;

    #region Properties
    public bool DEBUG;
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
    private void Update()
    {
        //provisional
    }

    public void PlayerDied()
    {
        //TODO

        /*
         * Pantalla de Game Over
         * Reiniciar la escena.
         */
    }

    public void PotionFailed(Color color)
    {
        _colorController.ColorMasCercano(color);
        //TODO
        /*
         * Obtener un efecto negativo 
         * 
         * 
         */
    }
    public void PotionCorrect(Color color)
    {

        /*
         * Perder todos los efectos negativos.
         * Despawnear todos los enemigos, spawnear uno nuevo de cada.
         * 
         */
    }

    /// <summary>
    /// Método llamado al recoger un color para informar a la UI
    /// </summary>
    /// <param name="color"></param>
    public void ColorPicked(int color)
    {
        _barManager.CatchColor(color);
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
        _requiredColor = _colorController.InicializaColor();
        _colorPetition.color = _requiredColor;
    }
}
