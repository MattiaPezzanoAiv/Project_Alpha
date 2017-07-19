using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour {

    [SerializeField]
    private GameObject target;
    public Vector3 compensation;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        transform.position = target.transform.position + compensation;
	}
}
