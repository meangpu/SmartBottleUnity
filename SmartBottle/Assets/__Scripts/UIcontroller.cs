using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] int maxNumber = 13;  // max 20cm  but real bottle is 13


    public void updateSlider(float v)
    {
        Mathf.Clamp(v, 0, 13);
        if(v <= 1)  // too far and if 0 sensor is soke with water whic never gonna happen
        {
            return;
        }
        // get 0-1 by devide and invert it again to 13 is least 0 is full
        Debug.Log(v);
        Debug.Log(Mathf.Abs((v / maxNumber)-1));

        slider.value = Mathf.Abs((v / maxNumber)-1) ; 
    }
}
