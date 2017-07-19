using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour,IDamageable {

    private Statistics stat;
    private GameObject player;

    [SerializeField]
    private float speed;

    public void GetDamage(int amount)
    {
        throw new NotImplementedException();
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
}
