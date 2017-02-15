using UnityEngine;
using System.Collections;
public class Huecos : MonoBehaviour {
    public GameObject CaraAsignada; //Cara a la que ira la pelota
    public GameObject CaraHogar; //Cara en la que se esta jugando
    public GameObject pelota;
    public GameObject PelotaPrefab; //Como construir la pelota de la siguiente cara
    public controladorJuego Control;
    private GameObject nuevaPelota;
    private int caraActual;

    void Start()
    {
        GameObject ControlJuego = GameObject.Find("Controlador");
        Control = ControlJuego.GetComponent<controladorJuego>();
        print(CaraHogar);
    }
    void OnCollisionEnter (Collision col)
    {
        caraActual = Control.caraActiva;
             
        pelota = CaraHogar.transform.Find("Pelota").gameObject;
        print(pelota.name);
        print(col.gameObject.name + "2");
        print(col.gameObject == pelota);
        if (pelota != null)
        {
            Destroy(col.gameObject); //destruye la pelota
            print("destruye pelota");
            nuevaPelota = Instantiate(PelotaPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            nuevaPelota.name = "Pelota";
            nuevaPelota.transform.parent = GameObject.Find("Origen/"+ CaraAsignada.name).transform;
            print(CaraAsignada.name);
            nuevaPelota.SetActive(false);
            //Control.caraActiva = CaraAsignada;
        }
        
        //if (caraActual == CaraHogar){
        //    if (caraActual == 1){
        //        pelota = GameObject.Find("Origen/CaraDeAgua/Pelota");
        //    }
        //    else if (caraActual == 2){
        //        pelota = GameObject.Find("Origen/CaraDeCosa/Pelota");
        //    } 
        //}
        //if(col.gameObject == pelota)
        //{
        //    if(CaraAsignada == 2)
        //    {
        //        Destroy(col.gameObject);
        //        nuevaPelota = Instantiate(PelotaPrefab, new Vector3(0, 0, 0),Quaternion.identity);
        //        nuevaPelota.name = "Pelota";
        //        nuevaPelota.transform.parent = GameObject.Find("Origen/CaraDeCosa").transform;
        //        nuevaPelota.active = false;
        //        Control.caraActiva = CaraAsignada;
        //    }
        //    else if (CaraAsignada == 1)
        //    {
        //        Destroy(col.gameObject);
        //        nuevaPelota = Instantiate(PelotaPrefab, new Vector3(0, 0, 0),Quaternion.identity);
        //        nuevaPelota.name = "Pelota";
        //        nuevaPelota.transform.parent = GameObject.Find("Origen/CaraDeAgua").transform;
        //        nuevaPelota.active = false;
        //        Control.caraActiva = CaraAsignada;

        //    }
        //}
    }
}
