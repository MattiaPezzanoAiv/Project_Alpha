using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour,ISpawner {

    [SerializeField]
    private List<GameObject> zombiePrefabs;
    [SerializeField]
    private List<Transform> spawningPoints; //implements child of spawwning points
    [SerializeField]
    private bool spawnRandomly;
    [SerializeField]
    private int minUnitsPerGroupSpawned;
    [SerializeField]
    private int maxUnitsPerGroupSpawned;
    [SerializeField]
    private float spawnFrequency;
    private float spawnCD;

    private int lastIndexSpawned;
    private int LastIndexSpawned
    {
        get
        {
            return lastIndexSpawned;
        }
        set
        {
            lastIndexSpawned = value;
            if (lastIndexSpawned >= spawningPoints.Count) //if more than max spawning point reset
                lastIndexSpawned = 0;

        }
    }

   

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (spawningPoints.Count <= 0) return;

        if (spawnCD > 0)
            spawnCD -= Time.deltaTime;
        if(spawnCD <= 0)
        {
            Spawn();
            spawnCD = spawnFrequency;
        }
    }

    public void Spawn()
    {
        Vector3 spawnPos = Vector3.zero;
        if(!spawnRandomly)
        {
            spawnPos = spawningPoints[LastIndexSpawned++].position;
        }
        else
        {
            int index = Random.Range(0, spawningPoints.Count);
            spawnPos = spawningPoints[index].position;
        }

        //spawning zombies
        int nOfZombies = Random.Range(minUnitsPerGroupSpawned, maxUnitsPerGroupSpawned + 1);
        for (int i = 0; i < nOfZombies; i++)
        {
            GameObject zombie = GlobalFactory.Get<IZombie>(zombiePrefabs[0]).GetActiveInstance();
            zombie.transform.position = spawnPos;

        }

        
    }
}
