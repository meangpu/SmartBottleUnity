using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meangpuGetData : MonoBehaviour
{
    [SerializeField] UIcontroller UIconScpt;
    [SerializeField] TreeManager treeManagerScpt;

    [SerializeField] TreeAnimEffect animScpt;



    public SerialController serialController;
    bool getMessage;

    int oldVal;
    int distanceValue;

    void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
    }

    // Executed each frame
    void Update()
    {

        //---------------------------------------------------------------------
        // Receive data
        //---------------------------------------------------------------------

        string message = serialController.ReadSerialMessage();
        if (message == null)
            return;
        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
            Debug.Log("Connection established");
        else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
            Debug.Log("Connection attempt failed or disconnection detected");
        else
            // add these to prevent error
            getMessage = int.TryParse(message, out distanceValue);
            if(!getMessage)
            {
                Debug.Log(message);
                return;
            }
            else
            {
                UIconScpt.updateSlider(distanceValue);
                treeManagerScpt.SetTreePref(distanceValue);

                if(oldVal == distanceValue)
                {
                    return;
                }
                else
                {
                    animScpt.DoDrinkAnim();
                    oldVal = distanceValue;

                }

            }
    }
}
