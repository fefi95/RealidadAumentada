using UnityEngine;
using System.Collections;
public class ComportamientoPiedra : MonoBehaviour {
    private GameObject CentroDelMundo;
    private GameObject ControlJugador;
    private GameObject Centro;
    private GameObject Camara;
    public int i;

    void Start()
    {
        i = 0;
        ControlJugador = GameObject.Find("ControlDelJugador");
    }
    void Update()
    {
        if (GlobalVariables.JuegoEnCurso){
            if (i > (60))
            {
                Destroy(gameObject);
            }
            else
            {
               i = i +1;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision coll){
        //Cuando se consigue la caja por primera vez empieza el tutorial
        if (coll.gameObject.tag == "Enemigo"){
            ControlJugador.GetComponent<ControlJugador>().matarEnemigo(coll.gameObject);
        }
    }

}
