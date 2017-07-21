using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour, IPoints
{
    [SerializeField]
    private float destroyTime;
    private float destroyCD;

    public Pool Pool
    {
        get;set;
    }

    public GameObject GetActiveInstance()
    {
        return gameObject;
    }

    public void OnGet()
    {
        destroyCD = destroyTime;
        gameObject.SetActive(true);
    }

    public void OnRecycle()
    {
        gameObject.SetActive(false);
    }


    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * 5f;
        transform.LookAt(Camera.main.transform);


        if (destroyCD > 0)
            destroyCD -= Time.deltaTime;
        if(destroyCD <= 0)
        {
            Pool.Recycle<IPoints>(this);
        }
    }
}
