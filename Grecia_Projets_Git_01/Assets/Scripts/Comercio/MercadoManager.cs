using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;


public class MercadoManager : MonoBehaviour
{
    [Header("Textos")]
    public Text[] textoRecursosPrecio;
    public Text[] textoRecursosPrecioVenta;
    public Text[] textoRecursosCantidad;
    public Text[] textoRecursosNombre;
        
    [Header("Recursos")]
    public Recurso[] Recursos;

    float minPrecioRicos, minPrecioMedios, minPrecioPobres, maxPrecioRicos, maxPrecioMedios, maxPrecioPobres;

    float pRicos, pMedios, pPobres;

     
    private void Update()
    {
        for (int i = 0; i < textoRecursosPrecio.Length; i++)
        {
            textoRecursosPrecio[i].text = Recursos[i].Precio.ToString();
            textoRecursosNombre[i].text = Recursos[i].Nombre + ":";
            textoRecursosPrecioVenta[i].text = Recursos[i].PrecioVenta.ToString();
            textoRecursosCantidad[i].text = Recursos[i].Cantidad.ToString();

            Recursos[i].PrecioVenta = Recursos[i].Precio - (Recursos[i].Precio * 10 / 100);
        }

                             
        pRicos =  (Recursos[24].Cantidad * 15 / 100);
        pMedios = (Recursos[24].Cantidad * 50 / 100);
        pPobres = (Recursos[24].Cantidad * 35 / 100);

        
        maxPrecioRicos = (pRicos / 100) * 3;
        maxPrecioMedios = ((pRicos + pMedios) / 100) * 3;
        maxPrecioPobres = ((pRicos + pMedios + pPobres) / 100) * 3;
       
        minPrecioRicos = (pRicos / 100) * 7;
        minPrecioMedios = ((pRicos + pMedios) / 100) * 7;
        minPrecioPobres = ((pRicos + pMedios + pPobres) / 100) * 7;


        for (int i = 0; i < Recursos.Length; i++)
        {
            if(Recursos[i].tipoRecurso == TipoRecurso.Pobre)
            {
                
                if (Recursos[i].Cantidad < maxPrecioPobres)
                {
                    Recursos[i].Precio = Recursos[i].PrecioTramoBajo;
                }
                else if (Recursos[i].Cantidad > maxPrecioPobres && Recursos[i].Cantidad < minPrecioPobres)
                {
                    Recursos[i].b = Mathf.Pow((Recursos[i].PrecioTramoBajo / Recursos[i].PrecioTramoAlto), (1 / (maxPrecioPobres - minPrecioPobres)));
                    Recursos[i].a = Recursos[i].PrecioTramoAlto / Mathf.Pow(Recursos[i].b, minPrecioPobres);

                    Recursos[i].Precio = (int)(Recursos[i].a * Mathf.Pow(Recursos[i].b, Recursos[i].Cantidad));
                }
                else if (Recursos[i].Cantidad > minPrecioPobres)
                {
                    Recursos[i].Precio = Recursos[i].PrecioTramoAlto;
                }
            }
            else if(Recursos[i].tipoRecurso == TipoRecurso.Medio)
            {
                
                if (Recursos[i].Cantidad < maxPrecioMedios)
                {
                    Recursos[i].Precio = Recursos[i].PrecioTramoBajo;
                }
                else if (Recursos[i].Cantidad > maxPrecioMedios && Recursos[i].Cantidad < minPrecioMedios)
                {
                    Recursos[i].b = Mathf.Pow((Recursos[i].PrecioTramoBajo / Recursos[i].PrecioTramoAlto), (1 / (maxPrecioMedios - minPrecioMedios)));
                    Recursos[i].a = Recursos[i].PrecioTramoAlto / Mathf.Pow(Recursos[i].b, minPrecioMedios);

                    Recursos[i].Precio = (int)(Recursos[i].a * Mathf.Pow(Recursos[i].b, Recursos[i].Cantidad));
                }
                else if (Recursos[i].Cantidad > minPrecioMedios)
                {
                    Recursos[i].Precio = Recursos[i].PrecioTramoAlto;
                }
            }
            else if (Recursos[i].tipoRecurso == TipoRecurso.Rico)
            {
               
                if (Recursos[i].Cantidad < maxPrecioRicos)
                {
                    Recursos[i].Precio = Recursos[i].PrecioTramoBajo+50;
                }
                else if (Recursos[i].Cantidad >= maxPrecioRicos && Recursos[i].Cantidad < minPrecioRicos)
                {
                    Recursos[i].b = Mathf.Pow((Recursos[i].PrecioTramoBajo / Recursos[i].PrecioTramoAlto), (1 / (maxPrecioRicos - minPrecioRicos)));
                    Recursos[i].a = Recursos[i].PrecioTramoAlto / Mathf.Pow(Recursos[i].b, minPrecioRicos);

                    Recursos[i].Precio = (int)(Recursos[i].a * Mathf.Pow(Recursos[i].b, Recursos[i].Cantidad));



                    // Formula Crecimiento Lineal
                    /*Recursos[i].a = (Recursos[i].PrecioTramoBajo - Recursos[i].PrecioTramoAlto) / (maxPrecioRicos - minPrecioRicos);
                    Recursos[i].b = Recursos[i].PrecioTramoBajo - (maxPrecioRicos * Recursos[i].a);
                    Recursos[i].Precio = (int)(Recursos[i].a * Recursos[i].Cantidad + Recursos[i].b);*/

                }
                else if (Recursos[i].Cantidad > minPrecioRicos)
                {
                    Recursos[i].Precio = Recursos[i].PrecioTramoAlto;
                }
            }

           
        }
    }
}
