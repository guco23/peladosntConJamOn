using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    SpawnerController[] _spawners;

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
    }

    public void PotionFailed()
    {
        //TODO
    }

    public void PotionCorrect()
    {

    }

    /// <summary>
    /// Recorre cada spawner activando su spawn.
    /// </summary>
    private void SpawnAll() { 
        for(int i = 0; i < _spawners.Length; i++)
        {
            Debug.Log(_spawners.Length);
            _spawners[i].Spawn();
        }
      /*  foreach(SpawnerController spawner in _spawners)
        {
            spawner.Spawn();
        } */
    }
    
    /// <summary>
    /// Recorre cada spawner llamando al metodo de kill spawned.
    /// </summary>
    private void KillAllSpawned()
    {
        foreach (SpawnerController spawner in _spawners)
        {
            spawner.KillSpawned();
        }
    }
}
