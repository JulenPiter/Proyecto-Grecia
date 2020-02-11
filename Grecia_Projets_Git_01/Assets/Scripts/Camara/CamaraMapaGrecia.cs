using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMapaGrecia : MonoBehaviour
{
    public float scrollSpeed;
    public float topBarrier;
    public float botBarrier;
    public float leftBarrier;
    public float rightBarrier;
    
    private void FixedUpdate()
    {
        if (Input.mousePosition.y >= Screen.height * topBarrier)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * scrollSpeed, Space.World);
        }

        if (Input.mousePosition.y <= Screen.height * botBarrier)
        {
            transform.Translate(Vector3.back * Time.deltaTime * scrollSpeed, Space.World);
        }

        if (Input.mousePosition.x >= Screen.width * rightBarrier)
        {
            transform.Translate(Vector3.right * Time.deltaTime * scrollSpeed, Space.World);
        }

        if (Input.mousePosition.x <= Screen.width * leftBarrier)
        {
            transform.Translate(Vector3.left * Time.deltaTime * scrollSpeed, Space.World);
        }
    }
}
