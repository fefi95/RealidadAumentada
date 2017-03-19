using UnityEngine;
using System.Collections;
public class ControlJugador : MonoBehaviour {
    public GameObject Piedra;
    private GameObject CentroDelMundo;
    private GameObject ControlEnemigos;
    
    private Vector3 posicion_spawn;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public bool TruenoActivo;
    public bool PiedrasActivas;
    public bool HieloActivo;
    public bool EscudoActivo;


    void Start()
    {
        ControlEnemigos = GameObject.Find("ControlDeEnemigos");
        TruenoActivo = true;
        PiedrasActivas = true;
        HieloActivo = true;
        EscudoActivo = true;
    }
    void Update()
    {

    }

    public void matarEnemigo(GameObject Enemigo){

        //Esta funcion mata al objeto que se pase como argumento
        Destroy(Enemigo);
    }
    public void Truenos(){
        //FUNCION INCOMPLETA
        //LLama a BuscarCentro, si consigue al centro entonces convoca truenos sobre los
        //Enemigos que estén a cierta distancia del "suelo"
        //Si no consigue al centro recibe null y no hace nada

        if (TruenoActivo){
            Debug.Log("Lanzo truenos!");
            ControlEnemigos.GetComponent<ControlEnemigos>().SpawnUnEnemigo();
        }

    }
    public void Piedras(){
        //FUNCION INCOMPLETA
        //LLama a BuscarCentro, si consigue al centro entonces convoca 9 piedras que rodaran
        //Sobre el terreno y mataran a todo enemigo que toquen
        //Si no consigue al centro recibe null y no hace nada

        if (PiedrasActivas){
            CentroDelMundo = GlobalVariables.CentroDelMundo;
            Debug.Log("Lanzo Piedras!");
            posicion_spawn = new Vector3(CentroDelMundo.transform.position.x + 1, 1 ,CentroDelMundo.transform.position.z + 1);
            Instantiate(Piedra, posicion_spawn, Quaternion.identity);
            posicion_spawn = new Vector3(CentroDelMundo.transform.position.x + 1, 1 ,CentroDelMundo.transform.position.z + 0);
            Instantiate(Piedra, posicion_spawn, Quaternion.identity);
            posicion_spawn = new Vector3(CentroDelMundo.transform.position.x + 1, 1 ,CentroDelMundo.transform.position.z - 1);
            Instantiate(Piedra, posicion_spawn, Quaternion.identity);
            posicion_spawn = new Vector3(CentroDelMundo.transform.position.x + 0, 1 ,CentroDelMundo.transform.position.z + 1);
            Instantiate(Piedra, posicion_spawn, Quaternion.identity);
            posicion_spawn = new Vector3(CentroDelMundo.transform.position.x + 0, 1 ,CentroDelMundo.transform.position.z + 0);
            Instantiate(Piedra, posicion_spawn, Quaternion.identity);
            posicion_spawn = new Vector3(CentroDelMundo.transform.position.x + 0, 1 ,CentroDelMundo.transform.position.z -1);
            Instantiate(Piedra, posicion_spawn, Quaternion.identity);
            posicion_spawn = new Vector3(CentroDelMundo.transform.position.x - 1, 1 ,CentroDelMundo.transform.position.z + 1);
            Instantiate(Piedra, posicion_spawn, Quaternion.identity);
            posicion_spawn = new Vector3(CentroDelMundo.transform.position.x - 1, 1 ,CentroDelMundo.transform.position.z + 0);
            Instantiate(Piedra, posicion_spawn, Quaternion.identity);
            posicion_spawn = new Vector3(CentroDelMundo.transform.position.x - 1, 1 ,CentroDelMundo.transform.position.z - 1);
            Instantiate(Piedra, posicion_spawn, Quaternion.identity);
        }
    }
    public void Estaca(){
        //FUNCION INCOMPLETA
        //LLama a BuscarCentro, si consigue al centro entonces lanza una estaca que sale de la camara
        //hacia el frente
        //Si no consigue al centro recibe null y no hace nada

        if (HieloActivo){
            Debug.Log("Lanzo Hielo!");
            // Create the Bullet from the Bullet Prefab
            var bullet = (GameObject)Instantiate (
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

            // Destroy the bullet after 2 seconds
            Destroy(bullet, 2.0f); 
        }

    }
    public void Escudo(){
        //FUNCION INCOMPLETA
        //LLama a BuscarCentro, si consigue al centro entonces genera un escudo que evita que se pierda vida
        //Por un limite de tiempo
        //Si no consigue al centro recibe null y no hace nada
        if (ControlEnemigos.GetComponent<ControlEnemigos>().Activo == false)
        {
            ControlEnemigos.GetComponent<ControlEnemigos>().Activo = true;
        }
        else
        {
            if (TruenoActivo){
                Debug.Log("Lanzo Escudo!");
            }
        }
    }

}
