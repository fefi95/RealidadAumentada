using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ControlJugador : MonoBehaviour {
    public GameObject Piedra;
    private GameObject CentroDelMundo;
    private GameObject ControlEnemigos;
    private GameObject Salud;
    
    private Vector3 posicion_spawn;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private bool TruenoActivo;
    private bool PiedrasActivas;
    private bool HieloActivo;
    private bool EscudoActivo;
    public bool EscudoArriba;
    private int TiempoEscudo;
    private int CoolDownEscudo;
    private int CoolDownPiedras;
    public GameObject TextoBotonEscudo;
    public GameObject TextoBotonPiedras;



    void Start()
    {
        Salud = GameObject.Find("Salud");
        ControlEnemigos = GameObject.Find("ControlDeEnemigos");
        TruenoActivo = true;
        PiedrasActivas = true;
        HieloActivo = true;
        EscudoActivo = true;
        EscudoArriba = false;

    }
    void Update()
    {
        if (EscudoArriba){
            TiempoEscudo = TiempoEscudo + 1;
            if (TiempoEscudo >= 30)
            {
                TiempoEscudo = 0;
                EscudoArriba = false;
            }
        }
        if (EscudoActivo == false){

            TextoBotonEscudo.GetComponent<Text>().text = ""+CoolDownEscudo;

            CoolDownEscudo = CoolDownEscudo - 1;
            if (CoolDownEscudo <= 0){
                EscudoActivo = true;
                TextoBotonEscudo.GetComponent<Text>().text = "Escudo";
            }
        }
        if (PiedrasActivas == false){

            TextoBotonPiedras.GetComponent<Text>().text = ""+CoolDownPiedras;

            CoolDownPiedras = CoolDownPiedras - 1;
            if (CoolDownPiedras <= 0){
                PiedrasActivas = true;
                TextoBotonPiedras.GetComponent<Text>().text = "Piedras";
            }
        }
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
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            foreach (Transform enemigo in ControlEnemigos.transform)
            {
                print("enemigo!" + enemigo.localPosition);
                if (enemigo.localPosition.z > 1)
                {
                    Destroy(enemigo);
                }
            }
            //ControlEnemigos.GetComponent<ControlEnemigos>().SpawnUnEnemigo();
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

            CoolDownPiedras = 60;
            PiedrasActivas = false;

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
        if (GlobalVariables.JuegoEnCurso == false)
        {
            GlobalVariables.JuegoEnCurso = true;
            GlobalVariables.Salud = 10;
            print("saludddddd" + Salud);
            Salud.GetComponent<Text>().text = "Salud: " + GlobalVariables.Salud;
        }
        else
        {
            if (EscudoActivo){
                CoolDownEscudo = 60;
                EscudoArriba = true;
                EscudoActivo = false;
                Debug.Log("Lanzo Escudo!");
            }
        }
    }

}
