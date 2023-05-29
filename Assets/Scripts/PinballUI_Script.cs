using Unity.Netcode;
using TMPro;
using UnityEngine;

public class PinballUI_Script : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI debugText;


    private void Start()
    {
        debugText.text = "Game started";
    }
    public void StartServer()
    {
        //NetworkManager.Singleton.StartServer();
        if (NetworkManager.Singleton.StartServer())
        {
            debugText.text = "Server started";
        }
        else
        {
            debugText.text = "Server failed to Start";
        }
    }
    public void StartClient()
    {
        //NetworkManager.Singleton.StartClient();
        if (NetworkManager.Singleton.StartClient())
        {
            debugText.text = "Client started";
        }
        else
        {
            debugText.text = "Client failed to Start";
        }
    }
    public void StartHost()
    {
        //NetworkManager.Singleton.StartHost();
        if (NetworkManager.Singleton.StartHost())
        {
            debugText.text = "Host started";
        }
        else
        {
            debugText.text = "Host failed to Start";
        }
    }

}