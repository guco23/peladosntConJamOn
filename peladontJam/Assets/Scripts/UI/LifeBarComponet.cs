using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBarComponet : MonoBehaviour
{
    [SerializeField]
    private Slider _lifeBar;
    [SerializeField]
    private LifeComponent _playerLifeComponent;
    // Start is called before the first frame update
    void Start()
    {
        _lifeBar.maxValue = _playerLifeComponent.MaxLife;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateHeath(int life)
    {
        _lifeBar.value = life;
    }
}
