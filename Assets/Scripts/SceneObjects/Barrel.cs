using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour,IBarrel {

    [SerializeField]
    protected GameObject explosionParticle;
    [SerializeField]
    protected int hitCountBeforeDestory;
    protected int currentHitCount;


    public virtual void Hitted()
    {
        currentHitCount--;
        if(currentHitCount <= 0)
        {
            //this call spawn points text assets and update points in ui
            PointsManager.Instance.SpawnPoints(transform.position + (Vector3.up * 2f), PointsManager.Instance.AddKillPoints());
            SpawnParticle();
            Destroy(gameObject);
        }
    }
    
    public virtual void SpawnParticle()
    {
        GameObject explosion = GlobalFactory.Get<IExplosion>(explosionParticle).GetActiveInstance();
        explosion.transform.position = transform.position;
    }

    // Use this for initialization
    void Awake () {

        currentHitCount = hitCountBeforeDestory;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    
}
