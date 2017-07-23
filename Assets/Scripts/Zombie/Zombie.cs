using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Zombie : MonoBehaviour,IDamageable,IZombie {

    private Statistics stat;
    private GameObject player;
    [SerializeField]
    private GameObject bloodParticlePrefab;
    private NavMeshAgent agent;

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
            //this call spawn points text assets and update points in ui
            PointsManager.Instance.SpawnPoints(transform.position + (Vector3.up * 2f), PointsManager.Instance.AddKillPoints());
            Pool.Recycle<IZombie>(this);
            return;
        }
        //instance particle of blood
        GameObject blood = GlobalFactory.Get<IBlood>(bloodParticlePrefab).GetActiveInstance();
        Transform bloodSpawner = transform.Find("BloodSpawner");
        blood.transform.position = bloodSpawner.position;
        blood.transform.forward = bloodSpawner.forward;
    }

    void Awake()
    {
        stat = GetComponent<PlayerStatistic>();
        player = GameObject.FindObjectOfType<PlayerShooter>().gameObject;
        agent = GetComponent<NavMeshAgent>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        agent.SetDestination(player.transform.position); //set target to agent 
        if(Vector3.Distance(player.transform.position,transform.position) <= 1.5f)
        {
            agent.isStopped = true;
            //attacking
            //now die with one shot
            SceneManager.LoadSceneAsync("Main");
        }
        //Vector3 newFor = (player.transform.position - transform.position).normalized;
        //transform.forward = newFor;
        //transform.position += newFor * speed * Time.deltaTime;	
	}

    public void OnGet()
    {
        gameObject.SetActive(true);
        stat.Reset();
        agent.speed = speed;
        ZombieSpawner.ZombiesOnScreen++;
    }

    public void OnRecycle()
    {
        gameObject.SetActive(false);
        ZombieSpawner.ZombiesOnScreen--;
    }

    public GameObject GetActiveInstance()
    {
        return gameObject;
    }
}
