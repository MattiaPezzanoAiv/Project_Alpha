using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneController : MonoBehaviour {

    [SerializeField]
    private Button play;
    [SerializeField]
    private Button credits;
    [SerializeField]
    private Button scores;

	// Use this for initialization
	void Start () {
		if(play == null || credits == null || scores == null) //null check
        {
            Debug.LogError("CREDITS/PLAY/SCORES HAVE NULL VALUE");
            Debug.Break();
        }

        //assign button operation from code
        play.onClick.AddListener(OnPlay);
        credits.onClick.AddListener(OnCredits);
        scores.onClick.AddListener(OnScores);
        
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnPlay()
    {
        //do thing 
        //load play scene
        GlobalFactory.Restart();
        SceneManager.LoadSceneAsync("Game");
    }

    private void OnCredits()
    {
        //do thing
        //load credits scene
    }
    private void OnScores()
    {

    }
}
