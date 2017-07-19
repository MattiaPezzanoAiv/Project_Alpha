using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour {

    private IShooter currentWeapon;

	// Use this for initialization
	void Start () {
        currentWeapon = GetComponentInChildren<IShooter>();
	}
	
	// Update is called once per frame
	void Update () {
		
        
	}

    public void Shot()
    {
        if (currentWeapon.CanShot)
            currentWeapon.Shot();
    }
}
