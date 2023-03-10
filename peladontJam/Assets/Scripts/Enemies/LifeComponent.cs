using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject _puddlePrefab;
    [SerializeField]
    private Transform _puddleTransform;
    [SerializeField] private int _maxLife;
    [SerializeField]
    private int _currentLife;
    [SerializeField]
    private int _damageMultiplier;
    [SerializeField] private float _spawnerOffset;

    IAManager _iaManager;
    public void DealDamage(int damage)
    {
        _currentLife -= damage * _damageMultiplier;
        if (_currentLife <= 0)
        {
            HandleDeath();
        }
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
            GameObject myObject = Instantiate(_puddlePrefab,_puddleTransform.position,Quaternion.identity);
            myObject.GetComponent<PuddleComponent>().SetColor(_iaManager.Color);

            Vector3 aux = new Vector3(Random.Range(-1f, 1),0, Random.Range(-1f, 1)).normalized;
            myObject = Instantiate(gameObject, transform.position - _spawnerOffset * aux, Quaternion.identity);
            myObject.SetActive(true);
            myObject = Instantiate(gameObject, transform.position + _spawnerOffset * aux, Quaternion.identity);
            myObject.SetActive(true);

            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _currentLife = _maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
