using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LifeComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject _puddlePrefab;
    [SerializeField]
    private Transform _puddleTransform;
    [SerializeField] 
    private int _maxLife;
    [SerializeField]
    private int _currentLife;
    [SerializeField]
    public int _damageMultiplier;
    [SerializeField]
    private float _kockbackForce;
    [SerializeField] private float _spawnerOffset;
    IAManager _iaManager;

    Rigidbody _myRigidBody;

    public int MaxLife { get { return _maxLife; }}
    public void DealDamage(int damage)
    {
        _currentLife -= damage * _damageMultiplier;
        if (GetComponent<PlayerController>() != null)   // Si nos encontramos en el jugador
        {
            GameManager.Instance.UpdateHeath(_currentLife);
        }
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
            //desactivamos el enemigo
            gameObject.SetActive(false);
            //creamos el puddle y le asignamos el color
            GameObject myObject = Instantiate(_puddlePrefab,_puddleTransform.position,Quaternion.identity);
            myObject.GetComponent<PuddleComponent>().SetColor(_iaManager.Color);

            //generamos un vector aleatorio para la generacion de los enemigos
            Vector3 aux = new Vector3(Random.Range(-1f, 1),0, Random.Range(-1f, 1)).normalized;

            //crear primer enemigo
            myObject = Instantiate(gameObject, transform.position - _spawnerOffset * aux, Quaternion.identity, transform.parent);
            myObject.SetActive(true);
            myObject.GetComponent<IAManager>()._playerInArea = GetComponent<IAManager>()._playerInArea;            
            //crear segundo enemigo
            myObject = Instantiate(gameObject, transform.position + _spawnerOffset * aux, Quaternion.identity, transform.parent);
            myObject.SetActive(true);
            myObject.GetComponent<IAManager>()._playerInArea = GetComponent<IAManager>()._playerInArea;

            //quitar los delegados del padre
            gameObject.GetComponent<IAManager>().QuitaDelegados();

            //destruimos el objeto
            Destroy(gameObject);
        }
    }




    public void KnockBack(Vector3 direction)
    {
        //direction.Normalize();
        //Debug.Log("Auch");
        //_myRigidBody.AddForce(new Vector3(direction.x,0,direction.z) * _kockbackForce + Vector3.up * 2, ForceMode.Impulse);
    }
    // Start is called before the first frame update
    void Start()
    {
        _currentLife = _maxLife;
        _myRigidBody = GetComponent<Rigidbody>();
    }
    public int GetCurrentLife()
    {
        return _currentLife;
    }
    public int GetMaxLife()
    {
        return _maxLife;
    }
}
