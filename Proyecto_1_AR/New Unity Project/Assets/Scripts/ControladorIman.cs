using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorIman : MonoBehaviour {

    public LayerMask m_MagneticLayers;
    public Vector3 m_Position;
    public float m_Radius;
    public float m_Force;

    void FixedUpdate()
    {
        Collider[] colliders;
        Rigidbody rigidbody;

        colliders = Physics.OverlapSphere(transform.position + m_Position, m_Radius, m_MagneticLayers);
        print(colliders.Length);
        foreach (Collider collider in colliders)
        {
            print("holis!");
            rigidbody = (Rigidbody)collider.gameObject.GetComponent(typeof(Rigidbody));
            if (rigidbody != null)
            {
                print("collide:" + rigidbody.name);
                rigidbody.AddExplosionForce(m_Force * -1, transform.position + m_Position, m_Radius);
            }
        }
    }

    void OnDrawGizmosSelected() {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + m_Position, m_Radius);
    }
}
