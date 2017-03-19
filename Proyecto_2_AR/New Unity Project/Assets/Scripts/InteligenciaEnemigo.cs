using UnityEngine;
using System.Collections;
public class InteligenciaEnemigo : MonoBehaviour {
    private GameObject CentroDelMundo;
    private GameObject Camara;
    public int i;
    public bool Activo;

    void Start()
    {
        i = 0;
    }
    void Update()
    {
        if (Activo)
        {
            if (i <= (30*1.5f)){
                i = i+1;
            }
            else {
                Debug.Log("PEW!");
                DispararAJugador();
                i = 0;
            }
        }
    }
    void DispararAJugador()
    {
    }
}
