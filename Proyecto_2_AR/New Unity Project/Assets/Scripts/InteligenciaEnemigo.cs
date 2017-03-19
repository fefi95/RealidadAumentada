using UnityEngine;
using System.Collections;
public class InteligenciaEnemigo : MonoBehaviour {
    private GameObject CentroDelMundo;
    private GameObject Camara;
    public GameObject Bala;
    public int i;

    void Start()
    {
        i = 0;
    }
    void Update()
    {
        if (GlobalVariables.JuegoEnCurso)
        {
            if (i <= (30*1.5f)){
                i = i+1;
            }
            else {
                i = 0;
                DispararAJugador();

            }
        }
        else{
            Destroy(gameObject);
        }
    }
    void DispararAJugador()
    {

        // Create the Bullet from the Bullet Prefab
        Vector3 spawnPosition = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y+0.11f,gameObject.transform.position.z);
        var bullet = (GameObject)Instantiate (
        Bala,
        spawnPosition,
        gameObject.transform.rotation);

    }
}
