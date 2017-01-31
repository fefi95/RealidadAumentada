using UnityEngine;
using System.Collections;
public class Huecos : MonoBehaviour {
    public int CaraAsignada;
    public int CaraHogar;
    public GameObject pelota;
    public GameObject PelotaPrefab;
    public controladorJuego Control;
    private GameObject nuevaPelota;
    private int caraActual;

    void Start()
    {
        GameObject ControlJuego = GameObject.Find("Controlador");
        Control = ControlJuego.GetComponent<controladorJuego>();
    }
    void OnCollisionEnter (Collision col)
    {
        caraActual = Control.caraActiva;
        if (caraActual == CaraHogar){
            if (caraActual == 1){
                pelota = GameObject.Find("Origen/CaraDeAgua/Pelota");
            }
            else if (caraActual == 2){
                pelota = GameObject.Find("Origen/CaraDeCosa/Pelota");
            } 
        }
        if(col.gameObject == pelota)
        {
            if(CaraAsignada == 2)
            {
                Destroy(col.gameObject);
                nuevaPelota = Instantiate(PelotaPrefab, new Vector3(0, 0, 0),Quaternion.identity);
                nuevaPelota.name = "Pelota";
                nuevaPelota.transform.parent = GameObject.Find("Origen/CaraDeCosa").transform;
                nuevaPelota.active = false;
                Control.caraActiva = CaraAsignada;
            }
            else if (CaraAsignada == 1)
            {
                Destroy(col.gameObject);
                nuevaPelota = Instantiate(PelotaPrefab, new Vector3(0, 0, 0),Quaternion.identity);
                nuevaPelota.name = "Pelota";
                nuevaPelota.transform.parent = GameObject.Find("Origen/CaraDeAgua").transform;
                nuevaPelota.active = false;
                Control.caraActiva = CaraAsignada;

            }
        }
    }
}
