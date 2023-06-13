using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonRestart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //get button component
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(RestartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void RestartGame()
    {
        Debug.Log("Restart Game");
        SceneManager.LoadScene("OutdoorsScene");
    }
}
