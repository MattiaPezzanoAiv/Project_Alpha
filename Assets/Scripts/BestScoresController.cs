using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;

public class BestScoresController : MonoBehaviour {

    [SerializeField]
    private GameObject otherScoresParent;
    private List<Text> otherScores;

    [SerializeField]
    private Text myScore;

    private AsyncOperation myAsyncOp;
    private UnityWebRequest myRequest;

    private AsyncOperation otherRequest; //TODO: WRITE QUERY ON HTTP SERVER FOR GETTING BEST SCORES

    private string deviceID;

    void Awake()
    {
        otherScores = new List<Text>();
        for (int i = 0; i < otherScoresParent.transform.childCount; i++)
        {
            Text scoreText = otherScoresParent.transform.GetChild(i).GetComponent<Text>();
            otherScores.Add(scoreText);
        }

        deviceID = SystemInfo.deviceUniqueIdentifier;

        //instance network 
        StartRequests();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        SetLoadingStatus(); //to do null check on async op

        if(myAsyncOp != null && myAsyncOp.isDone)
        {
            if(myRequest.responseCode != 200)
                myScore.text = "Network error, check your connection";
            else
            {
                string responseJson = Encoding.UTF8.GetString(myRequest.downloadHandler.data);
                Score score = JsonUtility.FromJson<Score>(responseJson);
                myScore.text = string.Format("Best Score: {0}", score.Points); //todo: refactoring with more information
            }
        }
	}

    private void StartRequests()
    {
        myRequest = UnityWebRequest.Get(string.Format("http://127.0.0.1:2000/?DeviceID={0}",deviceID)); //temporary set to localhost for debug in unity, dont work in build
        myAsyncOp = myRequest.Send();
    }

    private void SetLoadingStatus()
    {
        myScore.text = string.Format("Loading: {0}%", myAsyncOp.progress);
        foreach (var s in otherScores)
        {
            s.text = "Loading...";
        }
    }

    public void Back()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Main");
    }
}
