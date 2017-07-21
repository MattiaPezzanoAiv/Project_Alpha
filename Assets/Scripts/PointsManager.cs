using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsManager : MonoBehaviour {

    public static PointsManager Instance
    {
        get { return GameObject.FindObjectOfType<PointsManager>(); }
    }

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Text textFieldOnCanvas;
    [SerializeField]
    private int pointsPerKill;
    [SerializeField]
    private int pointsPerExplosion;
    [SerializeField]
    private GameObject pointPrefab;

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
    /// <summary>
    /// Return points added
    /// </summary>
    /// <returns></returns>
    public int AddKillPoints()
    {
        points += pointsPerKill;
        UpdatePoints();
        return pointsPerKill;
    }
    /// <summary>
    /// Return points added
    /// </summary>
    /// <returns></returns>
    public int AddExplosionPoints()
    {
        points += pointsPerExplosion;
        UpdatePoints();
        return pointsPerExplosion;
    }
    public string PointsAssetName
    {
        get
        {
            return "PointTextPro";
        }
    }
    public void SpawnPoints(Vector3 pos,int points)
    {
        GameObject go = GlobalFactory.Get<IPoints>(pointPrefab).GetActiveInstance();
        go.transform.position = pos;
        go.GetComponentInChildren<TextMeshPro>().SetText(""+points);
    }
}
