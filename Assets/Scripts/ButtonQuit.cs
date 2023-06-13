using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonQuit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //get button component
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(QuitGame);
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
   
}
