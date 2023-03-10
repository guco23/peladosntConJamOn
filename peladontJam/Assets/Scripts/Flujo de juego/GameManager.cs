using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region References

    [SerializeField]
    SpawnerController[] _spawners;
    [SerializeField]
    GameObject _player;
    ColorController _colorController;

    static private GameManager _instance;

    private UIManager _uiManager;
    [SerializeField]
    private ColorBarManager _barManager;//meter dentro de la ui
    #endregion


    #region Properties
    
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
        SpawnAll();
    }

    public void PlayerDied()
    {
        //TODO

        /*
         * Pantalla de Game Over
         * Reiniciar la escena.
         */
    }

    public void PotionFailed()
    {
        //TODO
        /*
         * Obtener un efecto negativo 
         * 
         * 
         */
    }

    public void PotionCorrect()
    {
        /*
         * Perder todos los efectos negativos.
         * Despawnear todos los enemigos, spawnear uno nuevo de cada.
         * 
         */
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
    /// <summary>
    /// Método llamado al recoger un color para informar a la UI
    /// </summary>
    /// <param name="color"></param>
    public void ColorPicked(int color)
    {
        _barManager.CatchColor(color);
    }
}
