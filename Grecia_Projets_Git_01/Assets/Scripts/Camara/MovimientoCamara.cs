using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public float scrollSpeed;
    public float zoomSpeed;
    public float distanciaMinimaSuelo;
    public float distanciaMaximaSuelo;
    public float topBarrier;
    public float botBarrier;
    public float leftBarrier;
    public float rightBarrier;
    public float distance;


    void LateUpdate()
    {
        if (Input.mousePosition.y >= Screen.height - botBarrier)
        {
            transform.Translate(Vector3.right * Time.deltaTime * scrollSpeed, Space.World);
        }

        if (Input.mousePosition.y <= 0 + botBarrier)
        {
            transform.Translate(Vector3.left * Time.deltaTime * scrollSpeed, Space.World);
        }

        if (Input.mousePosition.x >= Screen.width - rightBarrier)
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * scrollSpeed, Space.World);
        }

        if (Input.mousePosition.x <= 0 + leftBarrier)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * scrollSpeed, Space.World);
        }

        
        Ray ray = new Ray();
        RaycastHit hit;
        ray.origin = transform.position;
        ray.direction = transform.forward;

        if(Physics.Raycast(ray, out hit))
        {
            distance = Vector3.Distance(ray.origin,hit.point);
            print(distance);
            if(distance > distanciaMinimaSuelo && distance < distanciaMaximaSuelo) 
                transform.Translate(transform.forward * Time.deltaTime * zoomSpeed * Input.GetAxis("Mouse ScrollWheel"), Space.World);
            if (distance <= distanciaMinimaSuelo)
                transform.position = hit.point - transform.forward * (distanciaMinimaSuelo + 0.001f);
            else if (distance >= distanciaMaximaSuelo)
                transform.position = hit.point - transform.forward * (distanciaMaximaSuelo - 0.001f);
        }

        

    }
}
