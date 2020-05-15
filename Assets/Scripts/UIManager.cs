using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI fpsText;
    public float speedMPH;
   

    public virtual void changeText(float speed)
    {
        float s = speed * 2.23694f;// 1 meter per second = 2.23694 miles per hour. this is the algorithim  to change to get MPH. metric is superior
        speedText.text = Mathf.Clamp(Mathf.Round(s),0f,1000f) + "MPH"; // clamp set to keep decimal out of the MPH text. the 1000f is considered an unachievable speed. if the speed breaks 1000MPH then the 1000f will have to be increased.
        speedMPH = s;
    }


    void Update()
    {
        fpsText.text = (Mathf.Round(1f / Time.deltaTime)).ToString() + "FPS";
    }

}
