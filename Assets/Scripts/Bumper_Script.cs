using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper_Script : MonoBehaviour
{
    [SerializeField]
    private int _bumperForce;
    [SerializeField]
    private int _bumperScore;
    [SerializeField]
    private Light _lightBumper;
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();

        if (ballRigidbody != null)
        {
            //Vector3 forceDirection = collision.contacts[0].point - transform.position;
            Vector3 forceDirection = collision.GetContact(0).point - transform.position;
            forceDirection = forceDirection.normalized;
            forceDirection = new Vector3 (forceDirection.x, 0, forceDirection.z);

            ballRigidbody.AddForce(forceDirection * _bumperForce * 10);

            ScoreController_Script.Instance.IncreaseScore(_bumperScore);
            SoundController_Script.Instance.LaunchBumperSound1();
            StartCoroutine(FlashLight());
        }
    }

    private IEnumerator FlashLight()
    {
        for (int i = 0; i < 3; i++)
        {
            _lightBumper.enabled = true;
            yield return new WaitForSeconds(0.1f);
            _lightBumper.enabled = false;
            yield return new WaitForSeconds(0.1f);
        }
    }
}

