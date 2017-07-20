using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour,IExplosion {

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
    }

    public void OnRecycle()
    {
        gameObject.SetActive(false);
    }

    // Use this for initialization
    void Awake () {

    }

    // Update is called once per frame
    void Update () {

      


        if (destroyCD > 0)
            destroyCD -= Time.deltaTime;
        if(destroyCD <= 0)
        {
            Pool.Recycle<IExplosion>(this);
        }
	}
}
