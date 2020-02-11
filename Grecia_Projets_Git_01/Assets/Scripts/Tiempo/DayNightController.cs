using UnityEngine;
using System.Collections;

public class DayNightController : MonoBehaviour {

    
    public Light sun;

    // The number of real-world seconds in one full game day.
    // Set this to 86400 for a 24-hour realtime day.
    public float secondsInFullDay = 120f;

    // The value we use to calculate the current time of day.
    // Goes from 0 (midnight) through 0.25 (sunrise), 0.5 (midday), 0.75 (sunset) to 1 (midnight).
    
    [Range(0,1)]
    public float currentTimeOfDay = 0;

     
    public TimeControl tiempo;
    
    float sunInitialIntensity;
    void Start() {
        sunInitialIntensity = sun.intensity;
    }

 
    void Update() {
        
        UpdateSun();

       
        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * tiempo.timeMultiplier;


        if (currentTimeOfDay >= 1)
        {
            FindObjectOfType<Calendar>().SumarDia();
            currentTimeOfDay = 0;
        }
    }

    void UpdateSun() {
        
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        
        float intensityMultiplier = 1;
        
        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f) {
            intensityMultiplier = 0;
        }
        // Fade in the sun when it rises.
        else if (currentTimeOfDay <= 0.25f) {
            // 0.02 is the amount of time between sunrise and the time we start fading out
            // the intensity (0.25 - 0.23). By dividing 1 by that value we we get get 50.
            // This tells us that we have to fade in the intensity 50 times faster than the
            // time is passing to be able to go from 0 to 1 intensity in the same amount of
            // time as the currentTimeOfDay variable goes from 0.23 to 0.25. That way we get
            // a perfect fade.
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }
        
        else if (currentTimeOfDay >= 0.73f) {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
        }

        
        sun.intensity = sunInitialIntensity * intensityMultiplier;
    }
}