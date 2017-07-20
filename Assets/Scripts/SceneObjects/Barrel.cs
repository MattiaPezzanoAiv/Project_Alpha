using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour,IBarrel {

    [SerializeField]
    private GameObject explosionParticle;
    [SerializeField]
    private int hitCountBeforeDestory;
    private int currentHitCount;


    public void Hitted()
    {
        currentHitCount--;
        if(currentHitCount <= 0)
        {
            SpawnParticle();
            Destroy(gameObject);
        }
    }
    
    public void SpawnParticle()
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
