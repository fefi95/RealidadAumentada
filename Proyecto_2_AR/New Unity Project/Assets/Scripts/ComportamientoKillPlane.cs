using UnityEngine;
using System.Collections;
public class ComportamientoKillPlane : MonoBehaviour {
    void Start()
    {
    }
    void Update()
    {
    }
    void OnCollisionEnter(Collision coll){
        //Cuando se consigue la caja por primera vez empieza el tutorial
        Destroy(coll.gameObject);
    }

}
