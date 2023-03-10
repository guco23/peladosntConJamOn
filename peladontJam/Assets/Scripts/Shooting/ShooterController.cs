using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShooterController : MonoBehaviour
{
    public static ShooterController instance { get; private set; }
    [SerializeField]
    RectTransform mirilla;

    [SerializeField]
    GameObject balaPrefab;

    [SerializeField]
    Transform spawnTransform;

    [SerializeField]
    private GameObject _armaPlaceHolder;

    [SerializeField]
    public float _cadenciaDisparo;

    private Animator _mano;

    public bool _mira;
    
    private RaycastHit hit;
    float _reloj;

    private bool _enArea;

    bool _disparando;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _reloj = _cadenciaDisparo;
        _disparando = false;
        ExitArea();
        _mano = _armaPlaceHolder.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _reloj += Time.deltaTime;
        Shoot();
    }

    public void Disparar(InputAction.CallbackContext context)
    {
        if (context.started) _disparando = true;
        if (context.canceled) _disparando = false;
    }
    private void Shoot()
    {
        if (_reloj > _cadenciaDisparo && _disparando && _enArea)
        {
            GetComponent<AudioSource>().PlayOneShot(SoundComponent.Instance._shoot);
            GameObject bullet = Instantiate(balaPrefab, spawnTransform.position, balaPrefab.transform.rotation);
            bullet.transform.right = -_armaPlaceHolder.transform.forward;
            Physics.Raycast(Camera.main.ScreenPointToRay(mirilla.position), out hit);

            if (hit.point != Vector3.zero)
            {
                bullet.GetComponent<BalaBehaviour>().SetDirection(hit.point - spawnTransform.position);
                //Debug.Log(hit.point);
            }
            else { bullet.GetComponent<BalaBehaviour>().SetDirection(bullet.transform.forward); }           
            _reloj = 0;

            _mano.SetTrigger("Shoot");
        }
    }

    public void EnterArea()
    {
        _enArea = true;
        if (_mira)
        {
            mirilla.gameObject.SetActive(true);
        }
        _armaPlaceHolder.SetActive(true);

    }
    public void ExitArea()
    {
        _enArea = false;
        mirilla.gameObject.SetActive(false);
        _armaPlaceHolder.SetActive(false);

    }
}
