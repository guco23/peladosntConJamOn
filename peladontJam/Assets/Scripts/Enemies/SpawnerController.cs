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
            IAManager aux = transform.GetChild(i).gameObject.GetComponent<IAManager>();
            if (aux != null) aux.QuitaDelegados();

            Debug.Log("despaun");
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    public void Spawn()
    {
        GameObject spawny = Instantiate(_enemyPrefab, transform.position, Quaternion.identity, transform);
        
    }
    public void CleanPuddles()
    {
        int numChilds = transform.childCount;

        for (int i = 0; i < numChilds; i++)
        {
            if(transform.GetChild(i).GetComponent<PuddleComponent>() != null)
                Destroy(transform.GetChild(i).gameObject);
        }
    }
}
