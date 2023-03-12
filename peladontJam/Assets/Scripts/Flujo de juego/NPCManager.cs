using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCManager : MonoBehaviour
{
    [SerializeField]
    private Transform _spawnpPoint;

    [SerializeField]
    private Transform _destinationPoint;
    [SerializeField]
    private GameObject[] _poolNPCSprefabs = new GameObject[4];

    private NavMeshAgent _currentAgent;

    
    private bool _isMoving;
    [SerializeField]
    private float _margin;
    [SerializeField]
    private float _time;

    private float _currentTime;
    // Start is called before the first frame update
    private void Start()
    {
        //_isMoving = false;
        //_currentAgent = null;
        _currentTime = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log(_isMoving);
        if(_isMoving &&_currentAgent != null)
        {
            _currentTime += Time.deltaTime;
            if(_currentTime>_time) { GameManager.Instance.NewPotionPetition();_currentTime = 0;}
            
            //Debug.Log("tu vieja la chupa");
            if((_currentAgent.transform.position -_destinationPoint.position).magnitude <_margin )
            {
                _isMoving=false;
                _currentAgent.GetComponent<Animator>().SetFloat("velocidad", 0);
                //Debug.Log("tu vieja definitiva");
            }
        }
    }

    public void NuevoNpc()
    {
        if (_currentAgent != null) Destroy(_currentAgent.gameObject);

        _currentAgent = Instantiate(_poolNPCSprefabs[Random.Range(0, _poolNPCSprefabs.Length)],
            _spawnpPoint.position, Quaternion.identity).GetComponent<NavMeshAgent>();
        _currentAgent.SetDestination(_destinationPoint.position);
        _isMoving = true;
        _currentTime = 0;
        _currentAgent.GetComponent<Animator>().SetFloat("velocidad", 1f);
    }
    public void BienAnim()
    {
        _currentAgent.GetComponent<Animator>().SetTrigger("Bien");
        Invoke("NuevoNpc", 1f);
    }
    public void MalAnim()
    {
        _currentAgent.GetComponent<Animator>().SetTrigger("Mal");
    }
}
