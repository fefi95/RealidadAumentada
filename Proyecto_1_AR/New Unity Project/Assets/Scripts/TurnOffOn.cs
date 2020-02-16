using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffOn : MonoBehaviour
{
    public float lightUpTime;
    public float lightDownTime;
    public float cycleTime;
    public Light lighting;
    public controladorJuego Control;
    private int caraActual;
    public int frames;

    // Use this for initialization
    void Start()
    {
        GameObject ControlJuego = GameObject.Find("Controlador");
        Control = ControlJuego.GetComponent<controladorJuego>();
        frames = 1;
    }

    // Update is called once per frame
    void Update()
    {
        caraActual = Control.caraActiva;
        //if (caraActual == 3)
        //{
        if ((frames >= 1) && (frames <= lightUpTime))
        {
            float l_lightIntensity = frames / lightUpTime;
            lighting.intensity = Mathf.Lerp(0, 8, l_lightIntensity);
        }
        else if ((frames > lightUpTime) && (frames < (lightDownTime+ lightUpTime)))
        {
            float l_lightIntensity = (frames- lightUpTime) / (lightDownTime - lightUpTime);
            lighting.intensity = Mathf.Lerp(8, 0, l_lightIntensity);
        }
        else
        {
            //turn off lights
            lighting.intensity = 0;
        }
        frames = frames + 1;
        if (frames >= cycleTime)
        {
            frames = 1;
        }

       // }

    }
}