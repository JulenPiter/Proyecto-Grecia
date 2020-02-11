using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Movimiento : MonoBehaviour
{
    public LayerMask clickOn;
    public GuardarDatos guardarDatos;
    public NavMeshAgent miBarco;
    public Vector3 posicionMapa;

    private void OnLevelWasLoaded(int level)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<MeshRenderer>().enabled = true;
        miBarco.enabled = false;

        if (SceneManager.GetActiveScene().buildIndex != 0)
            gameObject.transform.position = new Vector3(GameObject.FindGameObjectWithTag("PuntoInicio").transform.position.x, transform.position.y, GameObject.FindGameObjectWithTag("PuntoInicio").transform.position.z);
        else
            transform.position = posicionMapa;
        
        miBarco.enabled = true;
    }

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        GameObject.DontDestroyOnLoad(gameObject);
    }

    void Start ()
    {
        guardarDatos = FindObjectOfType<GuardarDatos>();
        guardarDatos.ActualizaBarcoTransform(gameObject);
        miBarco = GetComponent<NavMeshAgent> ();
    }

    void Update () { 
        if (Input.GetMouseButtonDown(1))
        {
            Ray miRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast (miRay, out hitInfo, 100, clickOn))
            {
                miBarco.SetDestination(hitInfo.point);
            }
        }
    }
}
