using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardarDatos : MonoBehaviour
{

    private Vector3 posicionBarco;
    private Quaternion rotacionBarco;

    private GameObject barco;

    private void Awake()
    {
        
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GuardarDatos");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        } 

        GameObject.DontDestroyOnLoad(gameObject);

        if(FindObjectOfType<Movimiento>().gameObject.tag == "Player")
            barco = FindObjectOfType<Movimiento>().gameObject;
        else
            barco = null;

    }
    
    void Update()
    {
        if(barco != null)
        {
            posicionBarco = barco.transform.position;
            rotacionBarco = barco.transform.rotation;
        }
    }

    public void ActualizaBarcoTransform(GameObject Barco)
    {
        barco = FindObjectOfType<Movimiento>().gameObject;
        
        Barco.GetComponent<Movimiento>().enabled = false;
        Barco.GetComponent<NavMeshAgent>().enabled = false;
        Barco.transform.position = posicionBarco;
        Barco.transform.rotation = rotacionBarco;
        Barco.GetComponent<NavMeshAgent>().enabled = true;
        Barco.GetComponent<Movimiento>().enabled = true;
    }
}
