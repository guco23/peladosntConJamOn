using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    SpawnerController[] _spawners;
    [SerializeField]
    GameObject _player;

    static private GameManager _instance;
    private UIManager _uiManager;


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
}
