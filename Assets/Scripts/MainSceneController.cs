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

	// Use this for initialization
	void Start () {
		if(play == null || credits == null) //null check
        {
            Debug.LogError("CREDITS/PLAY HAVE NULL VALUE");
            Debug.Break();
        }

        //assign button operation from code
        play.onClick.AddListener(OnPlay);
        credits.onClick.AddListener(OnCredits);

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnPlay()
    {
        //do thing 
        //load play scene
        SceneManager.LoadSceneAsync("Game");
    }

    private void OnCredits()
    {
        //do thing
        //load credits scene
    }
}
