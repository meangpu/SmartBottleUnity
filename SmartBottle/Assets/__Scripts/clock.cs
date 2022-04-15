using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class clock : MonoBehaviour
{
    [SerializeField] TMP_Text clockText;
    [SerializeField] TMP_Text sec;

    private void Start() 
    {
        StartCoroutine(updateTime());
    }

    IEnumerator updateTime()
    {
        var today = System.DateTime.Now;
        clockText.text = today.ToString("HH:mm");
        sec.text = today.ToString("ss");
        yield return new WaitForSeconds(1f);
        StartCoroutine(updateTime());
    }
}
