using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour,ISpawner {

    public static int ZombiesOnScreen;

    [SerializeField]
    private List<GameObject> zombiePrefabs;
    [SerializeField]
    private List<Transform> spawningPoints; //implements child of spawwning points
    [SerializeField]
    private bool spawnRandomly;
    [SerializeField][Range(1,6)]
    private int minUnitsPerGroupSpawned;
    [SerializeField][Range(1,6)]
    private int maxUnitsPerGroupSpawned;
    [SerializeField]
    private float spawnFrequency;
    private float spawnCD;
    [SerializeField]
    private float maxZombiesOnScreen;

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

        Transform spawnPos = null;
        if(!spawnRandomly)
        {
            spawnPos = spawningPoints[LastIndexSpawned++];
        }
        else
        {
            int index = Random.Range(0, spawningPoints.Count);
            spawnPos = spawningPoints[index];
        }

        //spawning zombies
        int nOfZombies = Random.Range(minUnitsPerGroupSpawned, maxUnitsPerGroupSpawned + 1);
        for (int i = 0; i < spawnPos.childCount; i++)
        {
            if (nOfZombies < 0) break; //stop spawning
            if (ZombiesOnScreen >= maxZombiesOnScreen) return;

            GameObject zombie = GlobalFactory.Get<IZombie>(zombiePrefabs[0]).GetActiveInstance();
            zombie.transform.position = spawnPos.GetChild(i).position;
            nOfZombies--;
        }

        
    }
}
