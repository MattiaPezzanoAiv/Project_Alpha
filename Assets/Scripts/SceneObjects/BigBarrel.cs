using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBarrel : Barrel {


    [SerializeField]
    private List<Transform> multipleSpawnPointsOfExplosions;
    [SerializeField]
    private int countToTakeFire;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Hitted()
    {
        currentHitCount--;
        countToTakeFire--;
        if (currentHitCount <= 0)
        {
            //this call spawn points text assets and update points in ui
            PointsManager.Instance.SpawnPoints(transform.position + (Vector3.up * 2f), PointsManager.Instance.AddKillPoints());
            SpawnParticle();
            Destroy(gameObject);
        }
        else if(countToTakeFire <= 0)
        {
            transform.Find("Fire").gameObject.SetActive(true);
        }
    }
    public override void SpawnParticle()
    {
        foreach (var point in multipleSpawnPointsOfExplosions)
        {
            GameObject go = GlobalFactory.Get<IExplosion>(explosionParticle).GetActiveInstance();
            go.transform.position = point.position;
        }
    }

   
}
