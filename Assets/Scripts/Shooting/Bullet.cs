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

    private GameObject owner;

    public void SetOwner(GameObject go)
    {
        owner = go;
    }

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

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == owner) return;    //it's me

        IDamageable damageable = col.collider.GetComponent<IDamageable>();
        if(damageable != null)
        {
            PlayerStatistic playerStat = owner.GetComponent<PlayerStatistic>();
            PlayerStatistic enemyStat = col.collider.GetComponent<PlayerStatistic>();
            float dmgTaken = (Damage + playerStat.AttackPower) * (1 - enemyStat.DamageReduction);
            damageable.GetDamage((int)dmgTaken);
            //spawn blood particle
        }
        ISceneObject sceneObject = col.collider.GetComponent<ISceneObject>();
        if(sceneObject != null)
        {
            sceneObject.Hitted();
        }
        Pool.Recycle<IBullet>(this);
    }
}
