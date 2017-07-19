using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour,IBullet {

    [SerializeField]
    private int damage;
    public int Damage { get { return damage; } }

    [SerializeField]
    private float speed;


    public Pool Pool
    {
        get;

        set;
    }

    private float destroyCD;
    [SerializeField]
    private float destroyTime;
    public float DestroyTime
    {
        get { return destroyTime; }
        set { destroyTime = value; }
    }

    public GameObject GetActiveInstance()
    {
        return gameObject;
    }

    public void OnGet()
    {
        gameObject.SetActive(true);
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

        transform.position += transform.forward * speed * Time.deltaTime;

        if (destroyCD > 0)
            destroyCD -= Time.deltaTime;
        if(destroyCD <= 0)
        {
            destroyCD = DestroyTime;
            Pool.Recycle<IBullet>(this);
        }
	}
}
