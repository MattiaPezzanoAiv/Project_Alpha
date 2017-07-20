using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour,IBlood {

    [SerializeField]
    private float destroyTime;
    private float destroyCD;


    public Pool Pool
    {
        get;set;
    }

    public GameObject GetActiveInstance()
    {
        return gameObject;
    }

    public void OnGet()
    {
        destroyCD = destroyTime;
        gameObject.SetActive(true);
        GetComponent<ParticleSystem>().Clear();
    }

    public void OnRecycle()
    {
        gameObject.SetActive(false);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (destroyCD > 0)
            destroyCD -= Time.deltaTime;
        if (destroyCD <= 0)
        {
            Pool.Recycle<IBlood>(this);
        }
    }
}
