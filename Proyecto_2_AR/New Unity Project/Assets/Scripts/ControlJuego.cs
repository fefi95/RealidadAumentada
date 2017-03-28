using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public static class GlobalVariables{
    public static GameObject CentroDelMundo;
    public static bool JuegoEnCurso;
    public static int Salud;
    public static bool MarcaEnMira;
    public static bool ActiveSmartTerrain;
    
}

public class ControlJuego : MonoBehaviour {

    public GameObject GameOver;
    private GameObject Salud;
   

    void Start()
    {
        //GlobalVariables.JuegoEnCurso = true;
        BuscarCentro();
        GlobalVariables.Salud = 10;
        Salud = GameObject.Find("Salud");
        //JuegoEnCurso = DeterminarJuegoActivo();
    }
    void Update()
    {
        print(GlobalVariables.Salud);
        if (!GlobalVariables.JuegoEnCurso && GlobalVariables.Salud <= 0)
        {
            GameOver.SetActive(true);
        }
        else
        {
            GameOver.SetActive(false);
        }
    }

    void BuscarCentro()
    {
        GlobalVariables.CentroDelMundo = GameObject.Find("CentroJuego");
    }

    public void ReiniciarJuego()
    {
        GlobalVariables.JuegoEnCurso = true;
        GlobalVariables.Salud = 10;
        print("saludddddd" + Salud);
        Salud.GetComponent<Text>().text = "Salud: " + GlobalVariables.Salud;
    }
    
}
