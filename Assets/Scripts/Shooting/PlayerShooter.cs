using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShooter : MonoBehaviour {

    private IShooter currentWeapon;

	// Use this for initialization
	void Start () {
        currentWeapon = GetComponentInChildren<IShooter>();
	}
	
	// Update is called once per frame
	void Update () {

        float hor = CrossPlatformInputManager.GetAxis("Horizontal");
        float ver = CrossPlatformInputManager.GetAxis("Vertical");
        if (hor == 0 && ver == 0) return;

        Vector3 newFor = Camera.main.transform.right * hor + Camera.main.transform.up * ver;
        newFor.y = 0;
        transform.forward = newFor;
        transform.position += newFor * 5 * Time.deltaTime;
    }

    public void Shot()
    {
        if (currentWeapon.CanShot)
            currentWeapon.Shot();
    }
}
