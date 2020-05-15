using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    public List<Light> lights;
    //public List<GameObject> tailLights;
    public List<Light> breakLights;

    public virtual void ToggleHeadlights()
    {
        foreach (Light light in lights)
        {
            light.intensity = light.intensity == 0 ? 4 : 0;
        }

    }
    public virtual void ToggleBreakLights()
    {
        foreach (Light light in breakLights)
        {
            light.intensity = light.intensity == 1 ? 3 : 1;
        }
    }
  
}