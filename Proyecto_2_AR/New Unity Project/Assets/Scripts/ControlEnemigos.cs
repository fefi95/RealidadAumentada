using UnityEngine;
using System.Collections;
public class ControlEnemigos : MonoBehaviour {
    public GameObject Enemigo;
    private GameObject EnemigoGenerado;
    private GameObject CentroDelMundo;
    private Vector3 posicion_spawn;
    public int i;

    void Start()
    {
        CentroDelMundo = GlobalVariables.CentroDelMundo;
        i = 0;

    }
    void Update()
    {
        //Esta Funcion spawnea enemigos cada 3 segundos, mientras JuegoEnCurso sea true
        SpawnEnemigos();
    }
    void SpawnEnemigos(){
        //Esta Funcion spawnea enemigos cada 3 segundos, mientras juegoEnCurso sea true
        if (GlobalVariables.JuegoEnCurso)
        {
            if (i <= (30*3)){
                i = i+1;
            }
            else {
                SpawnUnEnemigo();
                i = 0;
            }
        }
    }
    public void SpawnUnEnemigo(){
        //Esta Funcion spawnea enemigos cada 3 segundos, mientras juegoEnCurso sea true
        posicion_spawn = new Vector3(Random.Range(-1.0f, 1.0f), 1, Random.Range(-1.0f, 1.0f));
        EnemigoGenerado = Instantiate(Enemigo, posicion_spawn, Quaternion.identity);
        EnemigoGenerado.transform.SetParent(gameObject.transform);
    }
}
