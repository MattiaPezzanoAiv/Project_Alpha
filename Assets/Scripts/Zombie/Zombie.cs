using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour,IDamageable,IZombie {

    private Statistics stat;
    private GameObject player;

    [SerializeField]
    private float speed;

    public Pool Pool
    {
        get;

        set;
    }

    public void GetDamage(int amount)
    {
        stat.HP -= amount;
        if(stat.HP <= 0)
        {
            Pool.Recycle<IPoolable>(this);
        }
        Debug.Log("taken damage " + amount);
        //instance particle of blood
    }

    void Awake()
    {
        stat = GetComponent<PlayerStatistic>();
        player = GameObject.FindObjectOfType<PlayerShooter>().gameObject;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        Vector3 newFor = (player.transform.position - transform.position).normalized;
        transform.forward = newFor;
        transform.position += newFor * speed * Time.deltaTime;	
	}

    public void OnGet()
    {
        gameObject.SetActive(true);
    }

    public void OnRecycle()
    {
        gameObject.SetActive(false);
    }

    public GameObject GetActiveInstance()
    {
        return gameObject;
    }
}
