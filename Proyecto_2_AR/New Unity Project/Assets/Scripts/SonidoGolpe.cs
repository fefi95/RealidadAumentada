using UnityEngine;
using System.Collections;
public class SonidoGolpe : MonoBehaviour {
    void Start()
    {
    }
    void Update()
    {
    }
    void OnCollisionEnter(Collision coll){
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
