using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffOn : MonoBehaviour {
    public controladorJuego Control;
    private int caraActual;
    public int frames;
    public GameObject Luz;
    public GameObject Luz2;

    // Use this for initialization
    void Start () {
        GameObject ControlJuego = GameObject.Find("Controlador");
        Control = ControlJuego.GetComponent<controladorJuego>();
        GameObject Luz = GameObject.Find("Directional light");
        GameObject Luz2 = GameObject.Find("Point light");
        frames = 1;
    }
	
	// Update is called once per frame
	void Update () {
        caraActual = Control.caraActiva;
        //if (caraActual == 3)
        //{
            if ((frames >= 1) && (frames <= 30))
            {
                Luz.GetComponent<Light>().enabled = true;
                Luz2.GetComponent<Light>().enabled = true;
            }
            else if ((frames > 30) && (frames < 150))
            { 
                //turn off lights
                Luz.GetComponent<Light>().enabled = false;
                Luz2.GetComponent<Light>().enabled = false;
            }
            frames = frames + 1;
            if (frames == 150)
            {
                frames = 1;
            }
            
        //}
		
	}
}
