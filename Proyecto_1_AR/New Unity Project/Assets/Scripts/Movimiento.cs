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
            y = -(1 - x);
            if ((camara.transform.eulerAngles.x > 0)&&(camara.transform.eulerAngles.x <= 45)){
                z = (camara.transform.eulerAngles.x)/(45);
            }
            else if ((camara.transform.eulerAngles.x > 315)&&(camara.transform.eulerAngles.x <= 360)){
                z = -(camara.transform.eulerAngles.x - 315)/(45);
            }
        }
        else if ((camara.transform.eulerAngles.z > 45)&&(camara.transform.eulerAngles.z <= 135)){
            y = (camara.transform.eulerAngles.z - 90)/(45);
            x = (1 - y);
            if ((camara.transform.eulerAngles.y > 0)&&(camara.transform.eulerAngles.y <= 45)){
                z = (camara.transform.eulerAngles.y)/(45);
            }
            else if ((camara.transform.eulerAngles.y > 315)&&(camara.transform.eulerAngles.y <= 360)){
                z = -(camara.transform.eulerAngles.y - 315)/(45);
            }
        }
        else if ((camara.transform.eulerAngles.z > 135)&&(camara.transform.eulerAngles.z <= 225)){
            x = -(camara.transform.eulerAngles.z - 180)/(45);
            y = (1 - x);
            if ((camara.transform.eulerAngles.x > 0)&&(camara.transform.eulerAngles.x <= 45)){
                z = -(camara.transform.eulerAngles.x)/(45);
            }
            else if ((camara.transform.eulerAngles.x > 315)&&(camara.transform.eulerAngles.x <= 360)){
                z = (camara.transform.eulerAngles.x - 315)/(45);
            }

        }
        else if ((camara.transform.eulerAngles.z > 225)&&(camara.transform.eulerAngles.z <= 315)){
            y = -(camara.transform.eulerAngles.z - 270)/(45);
            x = -(1 - y);
            if ((camara.transform.eulerAngles.y > 0)&&(camara.transform.eulerAngles.y <= 45)){
                z = -(camara.transform.eulerAngles.y)/(45);
            }
            else if ((camara.transform.eulerAngles.y > 315)&&(camara.transform.eulerAngles.y <= 360)){
                z = (camara.transform.eulerAngles.y - 315)/(45);
            }
        }
        else if ((camara.transform.eulerAngles.z > 315)&&(camara.transform.eulerAngles.z <= 360)){
            x = -(camara.transform.eulerAngles.z - 315)/(45);
            y = -(1 - x);
            if ((camara.transform.eulerAngles.x > 0)&&(camara.transform.eulerAngles.x <= 45)){
                z = (camara.transform.eulerAngles.x)/(45);
            }
            else if ((camara.transform.eulerAngles.x > 315)&&(camara.transform.eulerAngles.x <= 360)){
                z = -(camara.transform.eulerAngles.x - 315)/(45);
            }

        }



        Debug.Log(camara.transform.eulerAngles.z);
        //vectorMov = new Vector3(x,0,z);
        //RigidBodyPelota.velocity = vectorMov;
        //Physics.gravity = new Vector3(camara.transform.eulerAngles.z,camara.transform.eulerAngles.y,-camara.transform.eulerAngles.x);
        Physics.gravity = new Vector3(x,y,-z);
    }
}
