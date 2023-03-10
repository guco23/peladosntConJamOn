using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Vector3 direction;

    [SerializeField]
    private float speed;

    private Transform _myTransform;
    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        _myTransform.position += direction * speed * Time.deltaTime;
    }
    public void SetDirection(Vector3 v) 
    {
        direction = v.normalized;
    }
}
