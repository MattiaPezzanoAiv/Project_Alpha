using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShooter : MonoBehaviour {

    private IShooter currentWeapon;
    private PlayerStatistic myStat;


    void Awake()
    {
        currentWeapon = GetComponentInChildren<IShooter>();
        myStat = GetComponent<PlayerStatistic>();
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        float horShoot = CrossPlatformInputManager.GetAxis("Horizontal2");
        float verShoot = CrossPlatformInputManager.GetAxis("Vertical2");

        if (horShoot != 0 && verShoot != 0) //shooting
        {

            Vector3 newFor = (Camera.main.transform.right * horShoot + Camera.main.transform.up * verShoot).normalized;
            newFor.y = 0;
            transform.forward = newFor;
            Shot();
        }

        float hor = CrossPlatformInputManager.GetAxis("Horizontal");
        float ver = CrossPlatformInputManager.GetAxis("Vertical");
        if (hor == 0 && ver == 0) return;

        Vector3 newDir = (Camera.main.transform.right * hor + Camera.main.transform.up * ver).normalized;
        newDir.y = 0;
        transform.position += newDir * myStat.Speed * Time.deltaTime;
    }

    private void Shot()
    {
        if (currentWeapon.CanShot)
            currentWeapon.Shot();
    }
}
