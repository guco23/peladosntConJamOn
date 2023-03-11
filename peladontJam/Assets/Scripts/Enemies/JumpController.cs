using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class JumpController : MonoBehaviour
{
    private Transform _myTransform;

    //[SerializeField]
    //private float _rayCastDistance;

    [SerializeField]
    private float _jumpHeight;

    [SerializeField]
    private float _ascensionTime;

    [SerializeField]
    private float _descensionTime;

    public bool _ascend;

    private float _currentTime;

    private NavMeshAgent _agent;
    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _currentTime = 0;
        _ascend = true;
        _agent = GetComponent<NavMeshAgent>();
        _agent.baseOffset = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_ascend)
        {
            _currentTime += Time.deltaTime;
            //_myTransform.position += new Vector3(0, _jumpHeight * (Time.deltaTime / _ascensionTime),0);
            _agent.baseOffset += _jumpHeight * (Time.deltaTime / _ascensionTime);
            if (_currentTime >= _ascensionTime)
            {
                _ascend = false;
                _currentTime = 0;
            }
        }
        else
        {
            _currentTime += Time.deltaTime;
            //_myTransform.position -= new Vector3(0, _jumpHeight * (Time.deltaTime / _descensionTime), 0);
            _agent.baseOffset -= _jumpHeight * (Time.deltaTime / _ascensionTime);

            if (_currentTime >= _descensionTime)
            {
                GetComponent<AudioSource>().PlayOneShot(SoundComponent.Instance._slimeJump);
                _ascend = true;
                _currentTime = 0;
            }
        }
    }
}
