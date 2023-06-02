using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController_Script : MonoBehaviour
{
    private static ScoreController_Script instance = null;
    public static ScoreController_Script Instance => instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

    }
}
