using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Ciudad()
    {
        SceneManager.LoadScene(1);
    }

    public void NuevaPartida()
    {
        SceneManager.LoadScene(2);
    }

    public void MapaGrecia()
    {
        SceneManager.LoadScene(3);
    }


    public void QuitarJuego()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }


}
