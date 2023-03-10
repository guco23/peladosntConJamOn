using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    [SerializeField]
    private Material _material;

    [SerializeField]
    private Material _materialCercano;

    [SerializeField]
    private Material _materialCustom;

    public int _red;
    public int _green;
    public int _blue;

    [SerializeField]
    private float _max_color;

    [SerializeField]
    private float _umbralIguales;

    public Material Material
    {
        get { return _material; }
    }

    private Color _color;
    // Start is called before the first frame update
    void Start()
    {
        InicializaColores();
    }

    // Update is called once per frame
    void Update()
    {
        _materialCustom.color = GeneraColor(_red, _green, _blue);
    }
    public void InicializaColores()
    {       
        ResetColor(ref _color);

        float[] colores = new float[] {_color.r,_color.g,_color.b};

        int colorPrincipal = Random.Range(0, 3);

        //asignamos el color principal e inicializamos los secundarios
        colores[colorPrincipal] = 1;
        if (colorPrincipal == 0)    InicializaSecundarios(ref colores[1], ref colores[2]);
        else if (colorPrincipal == 1) InicializaSecundarios(ref colores[0], ref colores[2]);
        else if (colorPrincipal == 2) InicializaSecundarios(ref colores[1], ref colores[0]);

        _color.r = colores[0];
        _color.g = colores[1];
        _color.b = colores[2];
        
        _material.color = _color;
        _materialCercano.color = ColorMasCercano(_color);
    }

    private void InicializaSecundarios(ref float c1,ref float c2)
    {
        c1 = Random.Range(0f, 1);
        c2 = Random.Range(0f, Mathf.Clamp(_max_color - c1, 0, 1));
    }
    private void ResetColor(ref Color c)
    {
        c = Color.black;        
    }

    private Color CopiaColor(Color c)
    {
        return new Color(c.r, c.g, c.b, c.a);
    }

    private void EvaluaSecundarios(ref float c1,ref float c2)
    {
        if (c1 >= 0.75f)                    {c1 = 1; c2 = 0;}
        else if (c2 >= 0.75f)               {c1 = 0; c2 = 1;}
        else if (Mathf.Abs(c1 - c2) <= 0.5f){c1 = 0; c2 = 0;}
        else if (c1 >= c2)                  {c1 = 1; c2 = 0;}
        else                                {c1 = 0; c2 = 1;}
    }
   
    public Color ColorMasCercano(Color c)
    {        
        float[] colores = new float[]{c.r,c.g, c.b};

        if (colores[0] == 1) EvaluaSecundarios(ref colores[1], ref colores[2]);
        else if (colores[1] == 1) EvaluaSecundarios(ref colores[0], ref colores[2]);
        else if (colores[2] == 1) EvaluaSecundarios(ref colores[1], ref colores[0]);

        return new Color(colores[0], colores[1], colores[2],1);
    }

    public bool ColoresIguales(Color c1,Color c2)
    {        
        if(c1.r == 1)       return Mathf.Abs(c1.g - c2.g) < _umbralIguales && Mathf.Abs(c1.b - c2.b) < _umbralIguales;
        else if (c1.g == 1) return Mathf.Abs(c1.r - c2.r) < _umbralIguales && Mathf.Abs(c1.b - c2.b) < _umbralIguales;
        else if (c1.b == 1) return Mathf.Abs(c1.g - c2.g) < _umbralIguales && Mathf.Abs(c1.r - c2.r) < _umbralIguales;
        else //por si acaso
        {
            Debug.Log("algo va mal con tu vieja");
            return true;
        }
        //return ((Mathf.Abs(c1.r - c2.r) + Mathf.Abs(c1.g - c2.g) + Mathf.Abs(c1.b - c2.b)) < umbrarIguales);
    }

    //genera un color con estos valores de mezcla
    public Color GeneraColor(int r,int g,int b)
    {
        //calcula el mayor/ mayores
        //estos los pone a 1
        //los otros los pone en la parte proporcional a los mayores
        float _r,_g, _b;
        
        int aux = Mathf.Max(r,g,b);

        _r = (float)r / aux;
        _g = (float)g / aux;
        _b = (float)b / aux;

        return new Color(_r,_g,_b,1);
    }
}
