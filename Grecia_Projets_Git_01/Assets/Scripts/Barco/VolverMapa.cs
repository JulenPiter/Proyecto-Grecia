using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VolverMapa : MonoBehaviour
{

    public void volverMapa(string Ciudad)
    {
        SceneManager.LoadScene(Ciudad);
    }
}
