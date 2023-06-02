using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseArea_Script : MonoBehaviour
{

    [SerializeField]
    private GameObject _ballPrefab;

    private Transform SpawnPoint;

    [SerializeField] private int life = 3;

    private void Start()
    {
        life = 3;
        SpawnPoint = _ballPrefab.transform;        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            Debug.Log("Ball as entered the area" + other);
            Destroy(other, 5);

            if(life!=0){
                Instantiate(_ballPrefab, SpawnPoint.position, SpawnPoint.rotation);
            } 
            else
            {
                GameOver();
            }           
            life--;
        }
    }

    private void GameOver()
    {       
            //load scene scores
            SceneManager.LoadScene("Scores");        
    }
}
