using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    [SerializeField]
    private Material material;

    [SerializeField]
    private Material materialCercano;

    [SerializeField]
    private float max_color;

    [SerializeField]
    private float umbralIguales;

    private Color color;
    // Start is called before the first frame update
    void Start()
    {
        InicializaColores();

        Debug.Log(ColoresIguales(material.color, materialCercano.color));
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void InicializaColores()
    {
        //Debug.Log("tu vieja");

        //reseteamos el color
        color.r = 0;
        color.g = 0;
        color.b = 0;
        color.a = 1; //aseguramos que el alfa sea 1

        int colorPrincipal = Random.Range(1, 4);

        if (colorPrincipal == 1)
        {
            color.r = 1;

            color.g = Random.Range(0f, 1);
            color.b = Random.Range(0f, Mathf.Clamp( max_color-color.g,0,1));
        }
        else if (colorPrincipal == 2)
        {
            color.g = 1;

            color.r = Random.Range(0f, 1);
            color.b = Random.Range(0f, Mathf.Clamp(max_color - color.r, 0, 1));
        }
        else if (colorPrincipal == 3)
        {
            color.b = 1;

            color.g = Random.Range(0f, 1);
            color.r = Random.Range(0f, Mathf.Clamp(max_color - color.g, 0, 1));
        }


        material.color = color;
        materialCercano.color = ColorMasCercano(color);
    }

    //este metodo es una mierda, mañana lo hago bonico
    public Color ColorMasCercano(Color c)
    {
        Color resp = new Color();
        resp.r = c.r;
        resp.g = c.g;
        resp.b = c.b;
        resp.a = 1;
        if(c.r == 1)
        {
            if(c.g >= 0.75f)
            {
                resp.g = 1;
                resp.b = 0;
            }
            else if (c.b >= 0.75f)
            {

                resp.g = 0;
                resp.b = 1;
            }
            else if (Mathf.Abs(c.g - c.b) <= 0.5f)
            {
                resp.g = 0;
                resp.b = 0;
            }
            else if(c.g >= c.b)
            {
                resp.g = 1;
                resp.b = 0;
            }
            else
            {
                resp.g = 0;
                resp.b = 1;
            }
        }
        else if (c.g == 1)
        {
            if (c.r >= 0.75f)
            {
                resp.r = 1;
                resp.b = 0;
            }
            else if (c.b >= 0.75f)
            {

                resp.r = 0;
                resp.b = 1;
            }
            else if (Mathf.Abs(c.r - c.b) <= 0.5f)
            {
                resp.r = 0;
                resp.b = 0;
            }
            else if (c.r >= c.b)
            {
                resp.r = 1;
                resp.b = 0;
            }
            else
            {
                resp.r = 0;
                resp.b = 1;
            }
        }
        else if (c.b == 1)
        {
            if (c.g >= 0.75f)
            {
                resp.g = 1;
                resp.r = 0;
            }
            else if (c.r >= 0.75f)
            {

                resp.g = 0;
                resp.r = 1;
            }
            else if (Mathf.Abs(c.g - c.r) <= 0.5f)
            {
                resp.g = 0;
                resp.r = 0;
            }
            else if (c.g >= c.r)
            {
                resp.g = 1;
                resp.r = 0;
            }
            else
            {
                resp.g = 0;
                resp.r = 1;
            }
        }
        return resp;
    }

    public bool ColoresIguales(Color c1,Color c2)
    {
        
        if(c1.r == 1)
        {
            return Mathf.Abs(c1.g - c2.g) < umbralIguales && Mathf.Abs(c1.b - c2.b) < umbralIguales;
        }
        else if (c1.g == 1)
        {
            return Mathf.Abs(c1.r - c2.r) < umbralIguales && Mathf.Abs(c1.b - c2.b) < umbralIguales;
        }
        else if (c1.b == 1)
        {
            return Mathf.Abs(c1.g - c2.g) < umbralIguales && Mathf.Abs(c1.r - c2.r) < umbralIguales;
        }
        else
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
        return Color.white;
    }
}
