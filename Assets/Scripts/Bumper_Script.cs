using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper_Script : MonoBehaviour
{
    [SerializeField]
    private int bumperForce;
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();

        if (ballRigidbody != null)
        {
            //Vector3 forceDirection = collision.contacts[0].point - transform.position;
            Vector3 forceDirection = collision.GetContact(0).point - transform.position;
            forceDirection = forceDirection.normalized;
            forceDirection = new Vector3 (forceDirection.x, 0, forceDirection.z);

            ballRigidbody.AddForce(forceDirection * bumperForce * 10);
        }
    }
}
