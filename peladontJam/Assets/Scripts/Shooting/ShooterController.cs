using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShooterController : MonoBehaviour
{

    [SerializeField]
    RectTransform mirilla;

    [SerializeField]
    GameObject balaPrefab;

    [SerializeField]
    Transform spawnTransform;

    [SerializeField]
    float _cadenciaDisparo;

    private RaycastHit hit;
    float _reloj;

    // Start is called before the first frame update
    void Start()
    {
        _reloj = _cadenciaDisparo;
    }

    // Update is called once per frame
    void Update()
    {
        _reloj += Time.deltaTime;
    }

    public void Disparar(InputAction.CallbackContext context)
    {
        if (_reloj > _cadenciaDisparo && context.started)
        {
            GameObject bullet = Instantiate(balaPrefab, spawnTransform.position, Quaternion.identity);
            //Physics.Raycast(Camera.main.transform.position, Camera.main.ScreenPointToRay(mirilla.position).direction,out hit, Mathf.Infinity);
            Physics.Raycast(Camera.main.ScreenPointToRay(mirilla.position), out hit);

            if (hit.point != Vector3.zero)
            {
                bullet.GetComponent<BalaBehaviour>().SetDirection(hit.point - spawnTransform.position);
                Debug.Log(hit.point);
            }
            else { bullet.GetComponent<BalaBehaviour>().SetDirection(Camera.main.ScreenPointToRay(mirilla.position).direction); }
            _reloj = 0;

        }
    }

    
}
