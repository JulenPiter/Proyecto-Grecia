using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMapa : MonoBehaviour
{
    public float scrollSpeed;

    public float topBarrier;
    public float botBarrier;
    public float leftBarrier;
    public float rightBarrier;


    void Update()
    {
        if (Input.mousePosition.y >= Screen.height * topBarrier)
        {
            transform.Translate(Vector3.up * Time.deltaTime * scrollSpeed, Space.World);
        }

        if (Input.mousePosition.y <= Screen.height * botBarrier)
        {
            transform.Translate(Vector3.down * Time.deltaTime * scrollSpeed, Space.World);
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
