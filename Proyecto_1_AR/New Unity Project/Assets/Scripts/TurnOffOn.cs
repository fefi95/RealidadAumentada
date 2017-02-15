using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffOn : MonoBehaviour
{
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
            if ((frames >= 1) && (frames <= 90))
            {
                GameObject.Find("Origen/CaraTrueno/Plane").active = false;
            }
            else if ((frames > 90) && (frames < 180))
            {
                //turn off lights
                GameObject.Find("Origen/CaraTrueno/Plane").active = true;
            }
            frames = frames + 1;
            if (frames == 180)
            {
                frames = 1;
            }

       // }

    }
}