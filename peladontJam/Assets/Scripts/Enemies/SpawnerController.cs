using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField]
    GameObject _enemyPrefab;

    public void DespawnSpawned()
    {
        Debug.Log("spawner despawneo");
        int numChilds = transform.childCount;

        for(int i = 0; i < numChilds; i++)
        {
            Debug.Log("despaun");
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    public void Spawn()
    {
        GameObject spawny = Instantiate(_enemyPrefab, transform.position, Quaternion.identity, transform);
        
    }
}
