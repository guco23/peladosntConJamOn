using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAManager : MonoBehaviour
{
    #region parameters
    [SerializeField] private ColorManager.colors _color;
    [SerializeField] private float _maxRadioCirculo;
    [SerializeField] private float _minRadioCirculo;
    [SerializeField] float _minTiempoMax;
    [SerializeField] float _maxTiempoMax;
    private float _currentTiempoMax;

    #endregion

    #region accessors
    public ColorManager.colors Color { get { return _color; } }
    #endregion

    private Transform _target;

    private Transform _myTransform;

    private NavMeshAgent _myAgent;


    public bool _playerInArea;

    private int _colorInt;

    private float _currentTime;

    private void Awake()
    {
        _playerInArea = false;
    }
    // Start is called before the first frame update
    public void Start()
    {
        _target = InputManager.Instance.transform;
        _myTransform = transform;
        _myAgent = GetComponent<NavMeshAgent>();
        _colorInt = (int)GetComponent<IAManager>().Color;
        _myAgent.SetDestination(_myTransform.position);

        //GetComponent<NavMeshAgent>().updatePosition = false;
        //_myAgent.updateUpAxis = false;
        
        EnemiesManager.Instance.entrys[_colorInt] += OnEnter;
        EnemiesManager.Instance.exits[_colorInt] += OnExit;
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerInArea) _myAgent.SetDestination(_target.transform.position);
        else
        {
            _currentTime += Time.deltaTime;
            if(_currentTime > _currentTiempoMax)
            {
                _currentTime = 0;
                _currentTiempoMax = Random.Range(_minTiempoMax, _maxTiempoMax);
                _myAgent.SetDestination(transform.parent.position + new Vector3(Random.Range(0f, 1f), 0, Random.Range(0f, 1f)).normalized * Random.Range(_minRadioCirculo, _maxRadioCirculo));
            }
        }
    }

    private void OnEnter()
    {        
        _playerInArea = true;      
    }
    private void OnExit()
    {
        _playerInArea = false;
        //dejar de moverse
        //_myAgent.SetDestination(_myTransform.position);
        _myAgent.SetDestination(transform.parent.position + new Vector3(Random.Range(0f, 1f), 0, Random.Range(0f, 1f)).normalized * Random.Range(_minRadioCirculo, _maxRadioCirculo));
        _currentTiempoMax = Random.Range(_minTiempoMax, _maxTiempoMax);
    }
    public void QuitaDelegados()
    {
        EnemiesManager.Instance.entrys[_colorInt] -= OnEnter;
        EnemiesManager.Instance.exits[_colorInt] -= OnExit;
    }
}
