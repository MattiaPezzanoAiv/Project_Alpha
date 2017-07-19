using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Statistics : MonoBehaviour,IStatistic {

    //TO DO: PASSIVE PERKS

    private int attackPower;
    public int AttackPower
    {
        get
        {
            return attackPower;
        }

        set
        {
            attackPower = value;
            if (attackPower < 0) attackPower = 0;
        }
    }

    private float damageReduction;
    public float DamageReduction
    {
        get
        {
            return damageReduction;
        }

        set
        {
            damageReduction = value;
            if (damageReduction >= 1.0f) damageReduction = 1.0f; //if more than 1, must be 100% reduction damage.
            //no need less than 0 check because if less than 0, is incremented damage take
        }
    }

    private int hP;
    public int HP
    {
        get
        {
            return hP;
        }

        set
        {
            hP = value;
            if (hP > maxHP)
                hP = maxHP;

            if (hP < 0)
                hP = 0;
        }
    }

    private int maxHP;
    public int MaxHP
    {
        get
        {
            return maxHP;
        }

        set
        {
            maxHP = value;
            if (maxHP <= 0)
            {
                maxHP = 0;
                Debug.LogWarning("Warning: max hp setted as 0. It's least strange.");
            }

        }
    }

    private float speed;
    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
            if (speed < 0) speed = 0;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
