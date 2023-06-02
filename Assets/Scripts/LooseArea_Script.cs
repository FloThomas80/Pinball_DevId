using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseArea_Script : MonoBehaviour
{

    [SerializeField]
    private GameObject _ballPrefab;

    private Transform SpawnPoint;

    private void Start()
    {
        SpawnPoint = _ballPrefab.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            Debug.Log("Ball as entered the area" + other);
            Destroy(other, 5);

            Instantiate(_ballPrefab, SpawnPoint.position, SpawnPoint.rotation);
        }
    }
}
