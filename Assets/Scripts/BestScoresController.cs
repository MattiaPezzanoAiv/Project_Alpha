using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoresController : MonoBehaviour {

    [SerializeField]
    private GameObject otherScoresParent;
    private List<Text> otherScores;

    void Awake()
    {
        otherScores = new List<Text>();
        for (int i = 0; i < otherScoresParent.transform.childCount; i++)
        {
            Text scoreText = otherScoresParent.transform.GetChild(i).GetComponent<Text>();
            otherScores.Add(scoreText);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
