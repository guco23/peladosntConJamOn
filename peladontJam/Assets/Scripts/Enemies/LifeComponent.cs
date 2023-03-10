using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeComponent : MonoBehaviour
{
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
            //Acci�n cuando el jugador muera
        }

        else  if (_iaManager != null)                                         // Si nos encontramos en un enemigo
        {
            gameObject.SetActive(false);
            Instantiate()
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
