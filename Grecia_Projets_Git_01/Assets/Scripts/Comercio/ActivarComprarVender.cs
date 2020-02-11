using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarComprarVender : MonoBehaviour
{

    public MercadoManager ciudad;
    public ComprarVender comprarVender;
    bool enabledList = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //comprarVender.gameObject.SetActive(true);
            if (!enabledList)
            {
                
                comprarVender.gameObject.transform.position = new Vector3(comprarVender.gameObject.transform.position.x - 820, comprarVender.gameObject.transform.position.y, comprarVender.gameObject.transform.position.z);
                comprarVender.mercadoManager = ciudad;
            }
            else
            {
                comprarVender.gameObject.transform.position = new Vector3(comprarVender.gameObject.transform.position.x + 820, comprarVender.gameObject.transform.position.y, comprarVender.gameObject.transform.position.z);
            }
            enabledList = !enabledList;
        }

    }

}
