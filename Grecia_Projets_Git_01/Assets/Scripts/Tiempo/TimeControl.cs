using UnityEngine;


public class TimeControl : MonoBehaviour {


    public bool enabledList = false;
    
    public GameObject pausa;
    

    public float timeMultiplier = 1f;

    public Movimiento mover;

 
	void Update() {

     
               
        if (Input.GetKeyDown(KeyCode.P))
        {
          

            if (!enabledList)
            {
                timeMultiplier = 0f;

                mover.miBarco.enabled = false;

                pausa.gameObject.transform.position = new Vector3(393, pausa.gameObject.transform.position.y, pausa.gameObject.transform.position.z);
            }
            else
            {
                timeMultiplier = 1f;

                mover.miBarco.enabled = true;

                pausa.gameObject.transform.position = new Vector3(1000, pausa.gameObject.transform.position.y, pausa.gameObject.transform.position.z);
            }

            enabledList = !enabledList;
        }

          		
	}
}
