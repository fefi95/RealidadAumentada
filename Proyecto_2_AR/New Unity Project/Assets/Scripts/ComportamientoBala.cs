using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ComportamientoBala : MonoBehaviour {
    public GameObject GameOver;
    private Vector3 PosiciónJugador;
    private Vector3 NuevaPosicion;
    private float VelocidadBala;
    private GameObject Salud;
    private GameObject ControlJugador;
    void Start()
    {
        VelocidadBala = 0.1f;
        PosiciónJugador = GameObject.Find("Objetivo").transform.position;
        ControlJugador = GameObject.Find("ControlDelJugador");

    }
    void Update()
    {
        if (GlobalVariables.JuegoEnCurso){
            PosiciónJugador = GameObject.Find("Objetivo").transform.position;
            float xActual = gameObject.transform.position.x;
            float yActual = gameObject.transform.position.y;
            float zActual = gameObject.transform.position.z;
            float xCamara = PosiciónJugador.x;
            float yCamara = PosiciónJugador.y;
            float zCamara = PosiciónJugador.z;
            float xDiferencia =  xCamara - xActual;
            float yDiferencia =  yCamara - yActual;
            float zDiferencia =  zCamara - zActual;
            float DifTotal = Mathf.Abs(xDiferencia) + Mathf.Abs(yDiferencia) + Mathf.Abs(zDiferencia);
            float nuevaPosicionx = VelocidadBala*(xDiferencia/DifTotal);
            float nuevaPosiciony = VelocidadBala*(yDiferencia/DifTotal);
            float nuevaPosicionz = VelocidadBala*(zDiferencia/DifTotal);

            NuevaPosicion = new Vector3(xActual + (nuevaPosicionx), yActual + (nuevaPosiciony), zActual + (nuevaPosicionz));
            gameObject.transform.position = NuevaPosicion;
        }
        else{
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision coll){
        //Cuando se consigue la caja por primera vez empieza el tutorial
        if (coll.gameObject.tag == "Jugador"){
            
            if (ControlJugador.GetComponent<ControlJugador>().EscudoArriba){
            }
            else{
                GlobalVariables.Salud = GlobalVariables.Salud - 1;
                Salud = GameObject.Find("Salud");
                Salud.GetComponent<Text>().text = "Salud: " + GlobalVariables.Salud;
                if (GlobalVariables.Salud <= 0)
                {
                    GlobalVariables.JuegoEnCurso = false;
                }
              
            }
            Destroy(gameObject);

        }
    }

}
