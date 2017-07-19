using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour,IShooter {

    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float cadency;
    private float shotCD;



    public bool CanShot{ get { return (shotCD <= 0); } }

    public void Shot()
    {
        IBullet bullet = GlobalFactory.Get<IBullet>(bulletPrefab);
        bullet.GetActiveInstance().transform.position = spawnPoint.position;
        bullet.GetActiveInstance().transform.forward = spawnPoint.forward;
        bullet.GetActiveInstance().SetActive(true);
        shotCD = cadency;
    }


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        //cd if can shot
        if (shotCD > 0)
            shotCD -= Time.deltaTime;
        
	}
}
