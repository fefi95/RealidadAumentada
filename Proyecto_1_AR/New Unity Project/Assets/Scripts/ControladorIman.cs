using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorIman : MonoBehaviour {

    public LayerMask magneticLayers;
    public Vector3 position;
    public float radius;
    public float force;

    void FixedUpdate()
    {
        Collider[] colliders;
        Rigidbody rigidbody;

        colliders = Physics.OverlapSphere(transform.position + position, radius, magneticLayers);
        foreach (Collider collider in colliders)
        {
            rigidbody = (Rigidbody)collider.gameObject.GetComponent(typeof(Rigidbody));
            if (rigidbody != null)
            {
                print("collide:" + rigidbody.name);
                rigidbody.AddExplosionForce(force * -1, transform.position + position, radius);
            }
        }
    }

    void OnDrawGizmosSelected() {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + position, radius);
    }
}
