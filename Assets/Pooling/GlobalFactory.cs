using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GlobalFactory
{
    private static Dictionary<GameObject, Pool> pools;

	static GlobalFactory()
    {
        Restart();
	}

    public static T Get<T>(GameObject item) where T : IPoolable
    {
        if (!pools.ContainsKey(item))
            pools.Add(item, new Pool(item));
        return pools[item].Get<T>();
    }
    public static void Recycle<T>(GameObject item) where T : IPoolable
    {
        pools[item].Recycle<T>(item.GetComponent<T>());
    }
    public static void Restart()
    {
        pools = new Dictionary<GameObject, Pool>();
    }
}
