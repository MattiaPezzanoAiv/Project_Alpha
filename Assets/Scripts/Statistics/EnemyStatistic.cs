using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatistic : Statistics {

    #region EDITOR_SETTINGS
    [SerializeField]
    [Tooltip("Attention: this field set the maximum health of enemy, isn't a fixer of enemy hp at runtime.")]
    private int setEnemyHP;
    [SerializeField]
    private int setEnemyAttackPower;
    [SerializeField]
    private float setEnemyDamageRedcution;
    [SerializeField]
    private float setEnemySpeed;
    #endregion



    public override void Reset()
    {
        MaxHP = setEnemyHP;
        HP = MaxHP;
        AttackPower = setEnemyAttackPower;
        Speed = setEnemySpeed;
        DamageReduction = setEnemyDamageRedcution;
    }


    void Awake()
    {
        Reset();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
