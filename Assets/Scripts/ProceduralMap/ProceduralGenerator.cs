using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerator : MonoBehaviour
{



    [SerializeField]
    private GameObject player;
    [SerializeField]
    private int mapW;
    [SerializeField]
    private int mapH;
    [SerializeField]
    private List<GameObject> mapPrefabs;

    private MapPortion[,] map;
    private MapPortion central;

    // Use this for initialization
    void Start()
    {
        map = new MapPortion[mapW, mapH];
        central = map[2, 2];  //is the central portion? :D
    }

    // Update is called once per frame
    void Update()
    {



    }


    /// <summary>
    /// this method not set the position of map
    /// </summary>
    /// <returns></returns>
    private MapPortion GetRandomMapPortion()
    {
        MapPortion portion = new MapPortion();
        portion.map = mapPrefabs[Random.Range(0, mapPrefabs.Count)];

        return portion;
    }

    /// <summary>
    /// Return the access indexes of current portion of map walked by player
    /// </summary>
    /// <returns></returns>
    private Vector2 GetCurrentPortionMapOfPlayer()
    {
        float distance = float.MaxValue;
        Vector2 indexes = Vector2.zero;
        for (int i = 0; i < mapH; i++)
        {
            for (int j = 0; j < mapW; j++)
            {
                float dist = Vector3.Distance(map[j,i].position, player.transform.position);
                if (dist < distance)
                {
                    distance = dist;
                    indexes = new Vector2(j, i);
                }
            }
        }
        return indexes;
    }
}

public class MapPortion
{

    public GameObject map;
    public Vector3 position { get { return map.transform.position; } }
}
