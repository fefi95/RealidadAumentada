using UnityEngine;
using System.Collections;

public static class GlobalVariables{
    public static GameObject CentroDelMundo;
    public static bool JuegoEnCurso;
    public static int Salud;
    public static bool MarcaEnMira;
}

public class ControlJuego : MonoBehaviour {



    void Start()
    {
        GlobalVariables.JuegoEnCurso = true;
        BuscarCentro();
        GlobalVariables.Salud = 10;
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
