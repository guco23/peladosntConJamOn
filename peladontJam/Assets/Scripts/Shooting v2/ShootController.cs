using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootController : MonoBehaviour
{
    [SerializeField]
    RectTransform mirilla;

    [SerializeField]
    GameObject balaPrefab;

    [SerializeField]
    Transform spawnTransform;

    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject bullet =  Instantiate(balaPrefab, spawnTransform.position, Quaternion.identity);
            //Physics.Raycast(Camera.main.transform.position, Camera.main.ScreenPointToRay(mirilla.position).direction,out hit, Mathf.Infinity);
            Physics.Raycast(Camera.main.ScreenPointToRay(mirilla.position), out hit);

            if (hit.point != Vector3.zero)
            {
                bullet.GetComponent<BulletController>().SetDirection(hit.point - spawnTransform.position);
                Debug.Log(hit.point);
            }
            else { bullet.GetComponent<BulletController>().SetDirection(Camera.main.ScreenPointToRay(mirilla.position).direction); }
        }


    }
}
