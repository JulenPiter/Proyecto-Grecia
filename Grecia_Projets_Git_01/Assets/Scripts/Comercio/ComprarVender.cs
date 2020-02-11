using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprarVender : MonoBehaviour
{
    
    public MercadoManager mercadoManager;
    public InventarioBarco barco;


    private void Awake()
    {
        barco = FindObjectOfType<InventarioBarco>();
        mercadoManager = FindObjectOfType<MercadoManager>();

    }
    public void CerrarMenu()
    {
        gameObject.SetActive(false);
    }

    public void BotonComprar(int id)
    {
                
        if(mercadoManager == null)
            mercadoManager = FindObjectOfType<MercadoManager>();


        if (Globals.Dinero >= mercadoManager.Recursos[id].Precio && mercadoManager.Recursos[id].Cantidad > 0)
        {
            mercadoManager.Recursos[id].Cantidad--;
            barco.Recursos[id].Cantidad++;
            Globals.Dinero -= mercadoManager.Recursos[id].Precio;


            barco.sumarDineroGastado(mercadoManager.Recursos[id].Precio, id);
                                
            barco.setPrecio(mercadoManager.Recursos[id].Precio, id);
                        
        }
    }

    public void BotonVender(int id)
    {
        if (mercadoManager == null)
            mercadoManager = FindObjectOfType<MercadoManager>();

        if (barco.Recursos[id].Cantidad > 0)
        {
            mercadoManager.Recursos[id].Cantidad++;
            barco.Recursos[id].Cantidad--;
            Globals.Dinero += mercadoManager.Recursos[id].PrecioVenta;
            barco.restarDineroGastado(id);
        }

        if (barco.Recursos[id].Cantidad == 0)
        {
            barco.setPrecio3(mercadoManager.Recursos[id].Precio, id);
            barco.resetDineroGastado(id);
        }
           

    }
}       
