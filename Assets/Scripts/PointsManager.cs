using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour {

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Text textFieldOnCanvas;
    [SerializeField]
    private int pointsPerKill;
    [SerializeField]
    private int pointsPerExplosion;


    private int points;
    public int Points
    {
        get
        {
            return points;
        }
    }

	// Use this for initialization
	void Start () {
		if(player == null)
            player = GameObject.FindObjectOfType<PlayerShooter>().gameObject;
        if (player == null)
            throw new UnityException("PLAYER IN POINTS MANAGER MISSING REFERENCE");
    }
	
	private void UpdatePoints()
    {
        textFieldOnCanvas.text = string.Format("Points: {0}", Points);
    }
    public void AddKillPoints()
    {
        points += pointsPerKill;
    }
    public void AddExplosionPoints()
    {
        points += pointsPerExplosion;
    }
}
