using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject _puddlePrefab;
    [SerializeField] private int _maxLife;
    private int _currentLife;
    private int _damageMultiplier;

    IAManager _iaManager;
    public void DealDamage(int damage)
    {
        _currentLife -= damage * _damageMultiplier;
    }

    private void HandleDeath()
    {
        _iaManager = GetComponent<IAManager>();
        if (GetComponent<PlayerController>() != null)   // Si nos encontramos en el jugador
        {
            //Acción cuando el jugador muera
        }

        else  if (_iaManager != null)                                         // Si nos encontramos en un enemigo
        {
            gameObject.SetActive(false);
            GameObject puddle = Instantiate(_puddlePrefab,transform.position + Vector3.down * 2,Quaternion.identity);
            puddle.GetComponent<PuddleComponent>().SetColor(_iaManager.Color);
        }
        else
        {

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
