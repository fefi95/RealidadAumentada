using UnityEngine;
using System.Collections;
public class ControlEnemigos : MonoBehaviour {
    public GameObject Enemigo;
    private GameObject CentroDelMundo;
    private Vector3 posicion_spawn;
    public int i;
    public bool Activo;

    void Start()
    {
        CentroDelMundo = GlobalVariables.CentroDelMundo;
        Activo = false;
        i = 0;

    }
    void Update()
    {
        //Esta Funcion spawnea enemigos cada 3 segundos, mientras JuegoEnCurso sea true
        SpawnEnemigos();
    }
    void SpawnEnemigos(){
        //Esta Funcion spawnea enemigos cada 3 segundos, mientras juegoEnCurso sea true
        if (Activo)
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
        Instantiate(Enemigo, posicion_spawn, Quaternion.identity);
    }
}
