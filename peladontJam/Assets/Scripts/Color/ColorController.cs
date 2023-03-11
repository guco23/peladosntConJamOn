using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    [SerializeField]
    [Range(0f,2f)]
    [Tooltip("Valor entre 0 y 2 para indicar la cercanía al blanco del color generado")]
    private float _max_color;

    [SerializeField]
    [Range(0f,1f)]
    [Tooltip("Margen de error para aceptar un color,1 es maxima tolerancia,0 es nada de tolerancia")]
    private float _umbralIguales;

    /// <summary>
    /// Crea un color posible y lo devuelve como objeto color.
    /// </summary>
    /// <returns>El objeto color creado (obvio)</returns>
    public Color InicializaColor()
    {
        //Debug.Log("Color de tu vieja");
        Color _color = new Color();

        float[] colores = new float[] { 0, 0, 0 };

        int colorPrincipal = Random.Range(0, 3);

        //asignamos el color principal e inicializamos los secundarios
        colores[colorPrincipal] = 1;
        if (colorPrincipal == 0) InicializaSecundarios(ref colores[1], ref colores[2]);
        else if (colorPrincipal == 1) InicializaSecundarios(ref colores[0], ref colores[2]);
        else if (colorPrincipal == 2) InicializaSecundarios(ref colores[1], ref colores[0]);

        _color.r = colores[0];
        _color.g = colores[1];
        _color.b = colores[2];

        return _color;
    }

    /// <summary>
    /// Méotodos internos para la creación del color.
    /// </summary>
    /// <param name="c1">primer color secundario</param>
    /// <param name="c2">segundo color secundario</param>
    private void InicializaSecundarios(ref float c1,ref float c2)
    {
        c1 = Random.Range(0f, 1);
        c2 = Random.Range(0f, Mathf.Clamp(_max_color - c1, 0, 1));
    }
    

    /// <summary>
    /// Comprueba cosas de los secundarios.
    /// Yo que se, lo hizo Samuel y funciona bien pero no lo comentó asi que no se que hace ni como ngl.
    /// </summary>
    /// <param name="c1"></param>
    /// <param name="c2"></param>
    private void EvaluaSecundarios(ref float c1,ref float c2)
    {
        if (c1 >= 0.75f)                    {c1 = 1; c2 = 0;}
        else if (c2 >= 0.75f)               {c1 = 0; c2 = 1;}
        else if (Mathf.Abs(c1 - c2) <= 0.5f){c1 = 0; c2 = 0;}
        else if (c1 >= c2)                  {c1 = 1; c2 = 0;}
        else                                {c1 = 0; c2 = 1;}
    }
   
    /// <summary>
    /// Encuentra el color más cercano de los 7 posibles colores principales, incluyendo el blanco.
    /// </summary>
    /// <param name="c"></param>
    /// <returns>El color de los 7</returns>
    public Color ColorMasCercano(Color c)
    {        
        float[] colores = new float[]{c.r,c.g, c.b};

        if (colores[0] == 1) EvaluaSecundarios(ref colores[1], ref colores[2]);
        else if (colores[1] == 1) EvaluaSecundarios(ref colores[0], ref colores[2]);
        else if (colores[2] == 1) EvaluaSecundarios(ref colores[1], ref colores[0]);

        return new Color(colores[0], colores[1], colores[2],1);
    }

    /// <summary>
    /// Comprueba si dos colores están suficientemente cerca cromáticamente para darlo por bueno.
    /// </summary>
    /// <param name="c1">Uno de los dos colores</param>
    /// <param name="c2">El otro color</param>
    /// <returns>True si están suficientemente cerca, False si no lo están. si hay algún otro fallo posible, te aconseja prestar atención a tu progenitora porque no se haya en sus óptimas facultades.</returns>
    public bool ColoresIguales(Color c1,Color c2)
    {        
        if(c1.r == 1)       return Mathf.Abs(c1.g - c2.g) < _umbralIguales && Mathf.Abs(c1.b - c2.b) < _umbralIguales;
        else if (c1.g == 1) return Mathf.Abs(c1.r - c2.r) < _umbralIguales && Mathf.Abs(c1.b - c2.b) < _umbralIguales;
        else if (c1.b == 1) return Mathf.Abs(c1.g - c2.g) < _umbralIguales && Mathf.Abs(c1.r - c2.r) < _umbralIguales;
        else //por si acaso
        {
            Debug.Log("algo va mal con tu vieja");
            return false;
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
