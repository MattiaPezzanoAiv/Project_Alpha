using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pool
{
    private GameObject prefab;
    private Queue<GameObject> instances;

    public Pool(GameObject prefab)
    {
        this.prefab = prefab;
        instances = new Queue<GameObject>();
    }

    public T Get<T>() where T : IPoolable
    {
        T item;

        if(instances.Count > 0)
        {
            item = instances.Dequeue().GetComponent<T>();
        }
        else
        {
            item = GameObject.Instantiate<GameObject>(prefab).GetComponent<T>();
        }
        item.OnGet();
        item.Pool = this;

        return item;
    }
    public void Recycle<T>(T item) where T : IPoolable
    {
        item.OnRecycle();
        instances.Enqueue(item.GetActiveInstance());
    }
}
