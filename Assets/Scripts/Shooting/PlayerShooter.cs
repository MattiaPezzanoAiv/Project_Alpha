using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShooter : MonoBehaviour {

    private IShooter currentWeapon;
    private PlayerStatistic myStat;
    private CharacterController controller;


    void Awake()
    {
        currentWeapon = GetComponentInChildren<IShooter>();
        myStat = GetComponent<PlayerStatistic>();
        controller = GetComponent<CharacterController>();
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        float hor = CrossPlatformInputManager.GetAxis("Horizontal");
        float ver = CrossPlatformInputManager.GetAxis("Vertical");
        Vector3 newDir = Vector3.zero;
        if (hor != 0 && ver != 0) //moving
        {
            newDir=(Camera.main.transform.right * hor + Camera.main.transform.up * ver).normalized;
            newDir.y = 0;
            CharacterController controller = GetComponent<CharacterController>();
            Vector3 currentPos = transform.position;
            Vector3 nextPos = currentPos + (newDir * myStat.Speed * Time.deltaTime);
            controller.Move(nextPos - currentPos);
        }

        float horShoot = CrossPlatformInputManager.GetAxis("Horizontal2");
        float verShoot = CrossPlatformInputManager.GetAxis("Vertical2");

        if (horShoot != 0 && verShoot != 0) //shooting
        {
            Vector3 newFor = (Camera.main.transform.right * horShoot + Camera.main.transform.up * verShoot).normalized;
            newFor.y = 0;
            transform.forward = newFor;
            Shot();
        }
        else if(hor != 0 && ver != 0) //not shooting but moving 
        {
            transform.forward = newDir;
        }
    }

    private void Shot()
    {
        if (currentWeapon.CanShot)
            currentWeapon.Shot();
    }
}
