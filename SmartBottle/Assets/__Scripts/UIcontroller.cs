using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] int maxNumber = 20;  // max 20cm


    public void updateSlider(float v)
    {
        // get 0-1 by devide and invert it again to 20 is least 0 is full
        slider.value = Mathf.Abs((v / maxNumber)-1) ; 
    }
}
