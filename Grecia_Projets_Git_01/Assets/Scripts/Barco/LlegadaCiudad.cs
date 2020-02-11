using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LlegadaCiudad : MonoBehaviour
{
    private MeshRenderer rBarco;
    private bool entradaOn;

    public string Ciudad;

    private void Awake()
    {
        rBarco = GameObject.FindGameObjectWithTag("Player").GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("Player"))
        {
            entradaOn = true;
            rBarco.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
                
        if (other.tag == ("Player"))
        {
            entradaOn = false;
            rBarco.enabled = true;
        }
    }

    private void OnMouseDown()
    {
        if (entradaOn)
        {
            SceneManager.LoadScene(Ciudad);
            FindObjectOfType<Movimiento>().GetComponent<Movimiento>().posicionMapa = FindObjectOfType<Movimiento>().transform.position;
        }
    }


    
}
