using UnityEngine;
using System.Collections;

public static class GlobalVariables{
    public static GameObject CentroDelMundo;
    public static bool JuegoEnCurso;
}

public class ControlJuego : MonoBehaviour {



    void Start()
    {
        BuscarCentro();
        //JuegoEnCurso = DeterminarJuegoActivo();
    }
    void Update()
    {

    }

    void BuscarCentro()
    {
        GlobalVariables.CentroDelMundo = GameObject.Find("CentroJuego");
    }
}
