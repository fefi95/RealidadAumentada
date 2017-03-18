using UnityEngine;
using System.Collections;
public class ControlJugador : MonoBehaviour {
    private GameObject CentroDelMundo;
    private GameObject Centro;
    private Rigidbody RigidBodyPelota;
    private float x;
    private Vector3 vectorMov;
    void Start()
    {
        CentroDelMundo = GameObject.Find("CentroJuego");
    }
    void Update()
    {

    }
    GameObject BuscarCentro()
    {
        //FUNCION INCOMPLETA
        //Si el centro del mundo es visible, entonces permite usar los poderes y devuelve el objeto
        //Que representa al centro para que lo use
        //Si no, devuelve null

        CentroDelMundo = GameObject.Find("CentroJuego");
        return CentroDelMundo;
     }

    public void Truenos(){
        //FUNCION INCOMPLETA
        //LLama a BuscarCentro, si consigue al centro entonces convoca truenos sobre los
        //Enemigos que estén a cierta distancia del "suelo"
        //Si no consigue al centro recibe null y no hace nada
        Debug.Log("Lanzo truenos!");
        Centro = BuscarCentro();
        if (Centro == null){
            Debug.Log("El mundo no es visible");
        }
        else{
            Debug.Log(CentroDelMundo.transform.position.x +20);
        }
    }
    public void Piedras(){
        //FUNCION INCOMPLETA
        //LLama a BuscarCentro, si consigue al centro entonces convoca 9 piedras que rodaran
        //Sobre el terreno y mataran a todo enemigo que toquen
        //Si no consigue al centro recibe null y no hace nada

        Debug.Log("Lanzo piedras!");
    }
    public void Estaca(){
        //FUNCION INCOMPLETA
        //LLama a BuscarCentro, si consigue al centro entonces lanza una estaca que sale de la camara
        //hacia el frente
        //Si no consigue al centro recibe null y no hace nada

        Debug.Log("Lanzo hielo!");

    }
    public void Escudo(){
        //FUNCION INCOMPLETA
        //LLama a BuscarCentro, si consigue al centro entonces genera un escudo que evita que se pierda vida
        //Por un limite de tiempo
        //Si no consigue al centro recibe null y no hace nada
        
        Debug.Log("Me protejo!");
    }

}
