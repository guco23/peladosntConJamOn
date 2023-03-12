using UnityEngine;

public class BalaBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _fuerza;

    [SerializeField]
    private float _timeLife;

    [SerializeField]
    private static int _damage;

    private LayerMask _enemies;
    private Vector3 _direction;

    private void Start()
    {
        _enemies = LayerMask.NameToLayer("Enemies");
        GetComponent<AudioSource>().PlayOneShot(SoundComponent.Instance._shoot);
    }

    private void Update()
    {
        _timeLife -= Time.deltaTime;
        if (_timeLife < 0) Destroy(gameObject);
    }
    public void SetDirection(Vector3 direccion)
    {
        //Debug.Log("tu vieja la chupa");
        _direction = direccion.normalized;
        GetComponent<Rigidbody>().AddForce(_direction * _fuerza, ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(collision.gameObject);
        if (other.gameObject.layer == _enemies)// restar vida
        {
            other.gameObject.GetComponent<AudioSource>().PlayOneShot(SoundComponent.Instance._slimeHitted);
            other.gameObject.GetComponent<LifeComponent>().DealDamage(_damage);
            other.gameObject.GetComponent<LifeComponent>().KnockBack(transform.position - other.transform.position);
        }
        if (other.gameObject.layer != LayerMask.NameToLayer("Detection")) Destroy(gameObject);
    }
    public static void SetDamage(int valor)
    {
        _damage = valor;
    }
}
