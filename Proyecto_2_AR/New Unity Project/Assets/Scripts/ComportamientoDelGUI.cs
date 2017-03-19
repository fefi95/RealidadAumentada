using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ComportamientoDelGUI : MonoBehaviour {
    private bool botones;
    public GameObject BotonTrueno;
    public GameObject BotonPiedras;
    public GameObject BotonHielo;
    public GameObject BotonEscudo;
    public GameObject Salud;
    public GameObject TextoMarcaPerdida;



    void Start()
    {
        botones = false;
    }
    void Update()
    {
        if (GlobalVariables.MarcaEnMira == false)
        {
            if (botones == true){
                BotonTrueno.SetActive(false);
                BotonPiedras.SetActive(false);
                BotonHielo.SetActive(false);
                BotonEscudo.SetActive(false);
                Salud.SetActive(false);
                TextoMarcaPerdida.SetActive(true);
                botones = false;
            }
        }
        else
        {
            if (botones == false){
                BotonTrueno.SetActive(true);
                BotonPiedras.SetActive(true);
                BotonHielo.SetActive(true);
                BotonEscudo.SetActive(true);
                Salud.SetActive(true);
                TextoMarcaPerdida.SetActive(false);
                Debug.Log("pon los botones");
                botones = true;
            }
        }
    }
}
