using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAManager : MonoBehaviour
{
    #region parameters
    [SerializeField] private ColorManager.colors _color;
    #endregion

    #region accessors
    public ColorManager.colors Color { get { return _color; } }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetColor(ColorManager.colors color)
    {
        _color = color;
    }
}
