using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region References
    [SerializeField]
    ColorBarManager _colorBarManager;
    [SerializeField]
    LifeBarComponet _lifeBarComponet;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CatchColor(int color)
    {
        _colorBarManager.CatchColor(color);
    }
    public void UpdateHealth(int life)
    {
        _lifeBarComponet.UpdateHeath(life);
    }
}
