using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ComportamientoDelGUI : MonoBehaviour {
    private bool botones;
    private GameObject Contenido;
    public GameObject BotonTrueno;
    public GameObject BotonPiedras;
    public GameObject BotonHielo;
    public GameObject BotonEscudo;
    public GameObject BotonSmartTerrain;
    public GameObject Salud;
    public GameObject TextoMarcaPerdida;



    void Start()
    {
        Contenido = GameObject.Find("Contenido");
        botones = false;
    }
    void Update()
    {

        if (GlobalVariables.MarcaEnMira)
        {
            if (botones == false)
            {
                print("Estado Smart Terrain" + GlobalVariables.ActiveSmartTerrain);
                if (GlobalVariables.ActiveSmartTerrain)
                {
                    Contenido.SetActive(true);
                    BotonTrueno.SetActive(true);
                    BotonPiedras.SetActive(true);
                    BotonHielo.SetActive(true);
                    BotonEscudo.SetActive(true);
                    BotonSmartTerrain.SetActive(false);
                    Salud.SetActive(true);
                    Debug.Log("pon los botones");
                    botones = true;
                    if (GlobalVariables.Salud > 0)
                    {
                        GlobalVariables.JuegoEnCurso = true;
                    }
                }
                else
                {
                    BotonSmartTerrain.SetActive(true);
                }
                TextoMarcaPerdida.SetActive(false);
            }

        }
        else
        {
            if (botones == true)
            {
                BotonTrueno.SetActive(false);
                BotonPiedras.SetActive(false);
                BotonHielo.SetActive(false);
                BotonEscudo.SetActive(false);
                BotonSmartTerrain.SetActive(false);
                Salud.SetActive(false);
                botones = false;
                GlobalVariables.JuegoEnCurso = false;
            }
            TextoMarcaPerdida.SetActive(true);
        }
        if (!GlobalVariables.JuegoEnCurso)
        {
            BotonTrueno.SetActive(false);
            BotonPiedras.SetActive(false);
            BotonHielo.SetActive(false);
            BotonEscudo.SetActive(false);
            //BotonSmartTerrain.SetActive(false);
            Salud.SetActive(false);
            botones = false;
        }
    }
    
}
