using UnityEngine;
using System.Collections;
public class controladorJuego : MonoBehaviour {
    public int caraActiva;
    public GameObject pelota;
    void Start()
    {
        pelota = GameObject.Find("Origen/CaraDeAgua/Pelota");
    }
    void Update()
    {
    
    }
}
