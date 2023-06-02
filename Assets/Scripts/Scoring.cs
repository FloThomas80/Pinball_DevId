using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    //Player Input Reference
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] private TMP_InputField _inputPlayerName;
    private string _playerNameValue;
    private bool _isPlayerNameValidated = false;
    private int _scoreCurrent = 8000;


    private TextMeshProUGUI _top;
    private Input _playerName;
    private TextMeshProUGUI _score;

    [SerializeField] private Transform _uiContainer;
    [SerializeField] private GameObject _prefabRef;
    private GameObject _prefabInst;

    [SerializeField] private int maxResults = 5;
    //[SerializeField] List<GameObject> _panels = new List<GameObject>();

    [SerializeField] List<Color> _RankColors = new List<Color>();
    //[SerializeField] List<Color> _RankColors;

    public Results results = new Results();
    

void Start()
{
    UpdateScore();
}


void FixedUpdate()
{
    if(_playerInput.actions["ValidatePlayerName"].triggered && _isPlayerNameValidated == true && _inputPlayerName != null)
    {
        Debug.Log("Génie");
            _playerNameValue = _inputPlayerName.text;
                          
                for(int i=0;i <= maxResults;i++)
                {
                    if(_scoreCurrent >= results.scores[i].score)
                    {
                        results.scores.Insert(i,new Scores{Rank = (i+1).ToString(),PlayerName = _playerNameValue,score = _scoreCurrent});
                        
                        // Mettre à jour les rangs des éléments suivants
                        for (int j = i + 1; j < results.scores.Count; j++)
                        {
                            results.scores[j].Rank = (j + 1).ToString();
                        }

                    results.scores.RemoveAt(maxResults);
                    SaveToJson();
                    break;
                    }
                } 
        DisplayRank();
        _inputPlayerName.gameObject.SetActive(false);
        _isPlayerNameValidated = false;
    }
}


    public void SaveToJson()
    {        
        string json = JsonUtility.ToJson(results);
        //Create a path to the file
        string filePath = Application.persistentDataPath + "/results.json";
        Debug.Log(filePath);
        //Insert data into the file
        System.IO.File.WriteAllText(filePath, json);
    }

    public void LoadFromJson()
    {
        //Create a path to the file
        string filePath = Application.persistentDataPath + "/results.json";
        //Read the data from the file
        string json = System.IO.File.ReadAllText(filePath);
        //Convert the data into a Results object
        results = JsonUtility.FromJson<Results>(json);
    }

    public void UpdateScore(){
        //  string filePath = Application.persistentDataPath + "/results.json";
        //  string json = System.IO.File.ReadAllText(filePath);
        //  results = JsonUtility.FromJson<Results>(json);
        LoadFromJson();

        if(_scoreCurrent<=results.scores[maxResults-1].score)
        {
            Debug.Log("Nul");
            _inputPlayerName.gameObject.SetActive(false);
            DisplayRank();
        }
        else
        {       
            _isPlayerNameValidated = true;     
            // Debug.Log("Génie");
            // _playerNameValue = _inputPlayerName.text;
                          
            //     for(int i=0;i <= maxResults;i++)
            //     {
            //         if(scoreCurrent >= results.scores[i].score)
            //         {
            //             results.scores.Insert(i,new Scores{Rank = (i+1).ToString(),PlayerName = _playerNameValue,score = scoreCurrent});
                        
            //             // Mettre à jour les rangs des éléments suivants
            //             for (int j = i + 1; j < results.scores.Count; j++)
            //             {
            //                 results.scores[j].Rank = (j + 1).ToString();
            //             }

            //         results.scores.RemoveAt(maxResults);
            //         SaveToJson();
            //         break;
            //         }
            //     }                
            
            
        }

    }

    public void DisplayRank(){

        for(int i = 0; i < maxResults; i++)
        {
            //Instantiate Prefab in parent
            _prefabInst = Instantiate(_prefabRef,_uiContainer);

            //Get Textmesh Component Rank in prefab and set json value
            TextMeshProUGUI _textTopPrefab = _prefabInst.transform.GetChild(0).GetComponent<TextMeshProUGUI>(); 
                
            _textTopPrefab.text = results.scores[i].Rank;
            _textTopPrefab.color = _RankColors[i];
        

            
            //Get Input Component PlayerName Rank in prefab and set json value
            TMP_InputField _inputNamePrefab = _prefabInst.transform.GetChild(1).GetComponent<TMP_InputField>();
            _inputNamePrefab.text = results.scores[i].PlayerName;
            _inputNamePrefab.textComponent.color = _RankColors[i];


            //Get Input Component PlayerName Rank in prefab and set json value
            TextMeshProUGUI _scorePrefab = _prefabInst.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
            _scorePrefab.faceColor = _RankColors[i];
            _scorePrefab.text = results.scores[i].score.ToString();
         }
    }
}
    [System.Serializable]
    public class Results
    {
        public string Level;
        public List<Scores> scores = new List<Scores>();
    }

    [System.Serializable]
    public class Scores
    {
        public string Rank;
        public string PlayerName;
        public int score;
    }