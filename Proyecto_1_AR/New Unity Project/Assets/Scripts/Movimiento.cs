using UnityEngine;
using System.Collections;
public class Movimiento : MonoBehaviour {
    public GameObject camara;
    private Rigidbody RigidBodyPelota;
    private float x;
    private float y;
    private float z;
    private Vector3 vectorMov;
    void Start()
    {
        camara = GameObject.Find("Camera");
        RigidBodyPelota = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if ((camara.transform.eulerAngles.z > 0)&&(camara.transform.eulerAngles.z <= 45)){
            x = (camara.transform.eulerAngles.z)/(45);
        }
        else if ((camara.transform.eulerAngles.z < 360)&&(camara.transform.eulerAngles.z >= 315)){
            x = -(camara.transform.eulerAngles.z - 315)/(45);
        }
        else{
            
        }


        if ((camara.transform.eulerAngles.x > 0)&&(camara.transform.eulerAngles.x <= 45)){
            z = (camara.transform.eulerAngles.x)/(45);
        }
        else if ((camara.transform.eulerAngles.z < 360)&&(camara.transform.eulerAngles.x >= 315)){
            z = -(camara.transform.eulerAngles.x - 315)/(45);
        }
        else{
            
        }


        if ((camara.transform.eulerAngles.y > 0)&&(camara.transform.eulerAngles.y <= 45)){
            y = (camara.transform.eulerAngles.y)/(45);
        }
        else if ((camara.transform.eulerAngles.y < 360)&&(camara.transform.eulerAngles.y >= 315)){
            y = (camara.transform.eulerAngles.y - 315)/(45);
        }
        else{
            
        }

        Debug.Log(camara.transform.eulerAngles.z);
        //vectorMov = new Vector3(x,0,z);
        //RigidBodyPelota.velocity = vectorMov;
        //Physics.gravity = new Vector3(camara.transform.eulerAngles.z,camara.transform.eulerAngles.y,-camara.transform.eulerAngles.x);
        Physics.gravity = new Vector3(x,0,-z);
    }
}
