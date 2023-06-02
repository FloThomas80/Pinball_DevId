using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerGlobal : MonoBehaviour
{
    private static GameManagerGlobal instance;

    // Propriété pour accéder à l'instance du GameManager
    public static GameManagerGlobal Instance
    {
        get { return instance; }
    }
    //[SerializeField] ScoreController scoreController;
   private void Awake()
    {
        // Vérifie si une instance du GameManager existe déjà
        if (instance != null && instance != this)
        {
            // Détruit le GameObject actuel s'il y a une autre instance du GameManager
            Destroy(gameObject);
            return;
        }

        // Assigne l'instance actuelle à la variable statique
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    
}
