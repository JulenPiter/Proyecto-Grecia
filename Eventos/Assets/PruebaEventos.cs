using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PruebaEventos : MonoBehaviour
{

    public UnityEvent OnUnityEvent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            OnUnityEvent?.Invoke();
        }
    }
}
