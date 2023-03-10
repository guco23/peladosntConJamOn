using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField]
    GameObject _enemyPrefab;

    public void DespawnSpawned()
    {
        int numChilds = transform.childCount;

        for(int i = 0; i < numChilds; i++)
        {
            Destroy(transform.GetChild(i));
        }
    }

    public void Spawn()
    {
        GameObject spawny = Instantiate(_enemyPrefab, transform.position, Quaternion.identity, transform);
    }
}
