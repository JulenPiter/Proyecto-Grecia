using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventarioBarco : MonoBehaviour
{

    [Header("Recursos")]
    public Recurso[] Recursos;

    [Header("Textos")]
    public Text[] barcoRecursosCantidad;
    public Text[] barcoRecursosPrecioM;
    public Text[] barcoRecursosNombre;

    public int[] precioMedio;
    public int[] dineroGastado;

    
    public GameObject cantidadBarco;
    public GameObject precioMedioGameObject;
    

    private void OnLevelWasLoaded(int level)
    {
        if (GameObject.FindGameObjectWithTag("CantidadBarco"))
        {
            cantidadBarco = GameObject.FindGameObjectWithTag("CantidadBarco");
            for (int i = 0; i < GameObject.FindGameObjectWithTag("CantidadBarco").transform.childCount; i++)
            {
                barcoRecursosCantidad[i] = cantidadBarco.transform.GetChild(i).gameObject.GetComponent<Text>();
            }
        }

        if (GameObject.FindGameObjectWithTag("PrecioMedio"))
        {
            precioMedioGameObject = GameObject.FindGameObjectWithTag("PrecioMedio");
            for (int i = 0; i < GameObject.FindGameObjectWithTag("PrecioMedio").transform.childCount; i++)
            {
                barcoRecursosPrecioM[i] = precioMedioGameObject.transform.GetChild(i).gameObject.GetComponent<Text>();
            }
        }
    }

    private void Update()
    {

        for (int i = 0; i < Recursos.Length; i++)
        {
            barcoRecursosCantidad[i].text = Recursos[i].Cantidad.ToString();
            barcoRecursosPrecioM[i].text = precioMedio[i].ToString();
            //barcoRecursosNombre[i].text = Recursos[i].Nombre + ":";
        }
    }

    public void setPrecio(int precio, int id)
    {
         precioMedio[id] = dineroGastado[id] / Recursos[id].Cantidad;
    }

    public void setPrecio3(int precio, int id)
    {
        precioMedio[id] = 0;
    }

    public void sumarDineroGastado(int precio, int id)
    {
        dineroGastado[id] += precio;
    }

    public void restarDineroGastado(int id)
    {
        dineroGastado[id] -= precioMedio[id];

    }

    public void resetDineroGastado(int id)
    {
        dineroGastado[id] = 0;
    }

}
