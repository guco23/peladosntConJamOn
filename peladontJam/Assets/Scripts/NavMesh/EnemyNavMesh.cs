using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    
    private Transform _target;

    private Transform _myTransform;

    private NavMeshAgent _myAgent;

    [SerializeField]
    private bool _playerInArea;

    private int _color;
    // Start is called before the first frame update
    public void Start()
    {
        _target = InputManager.Instance.transform;
        _myTransform = transform;
        _myAgent = GetComponent<NavMeshAgent>();
        _playerInArea = false;
        _color = (int)GetComponent<IAManager>().Color;

        EnemiesManager.Instance.entrys[_color] +=  OnEnter;
        EnemiesManager.Instance.exits[_color] +=  OnExit;
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerInArea) _myAgent.SetDestination(_target.transform.position);
    }

    private void OnEnter()
    {
        Debug.Log(_playerInArea);
        _playerInArea = true;
        Debug.Log(_playerInArea);

        Debug.Log("he llamado al delegado   "+gameObject.name);
    }
    private void OnExit()
    {
        _playerInArea = false;
        _myAgent.SetDestination(_myTransform.position);
    }
    public void QuitaDelegados()
    {
        EnemiesManager.Instance.entrys[_color] -= OnEnter;
        EnemiesManager.Instance.exits [_color] -= OnExit;
    }
}
