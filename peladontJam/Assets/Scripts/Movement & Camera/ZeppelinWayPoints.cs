using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class ZeppelinWayPoints : MonoBehaviour
{
    [SerializeField]
    private Transform[] _myWaypoints;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotation;

    private int _index;

    private void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, _myWaypoints[_index].position, _speed * Time.deltaTime);

        if (transform.position == _myWaypoints[_index].position)
        {
            _index++;
            transform.rotation = Quaternion.Euler(90f, 0f, transform.rotation.z + _rotation);
        }
        if (_index == _myWaypoints.Length)
        {
            _index = 0;
            transform.rotation = Quaternion.Euler(90f, 0f, transform.rotation.z - _rotation);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.position = _myWaypoints[_index].position;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
}
