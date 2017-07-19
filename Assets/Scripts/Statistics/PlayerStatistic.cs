using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistic : Statistics {

    #region EDITOR_SETTINGS
    [SerializeField][Tooltip("Attention: this field set the maximum health of player, isn't a fixer of player hp at runtime.")]
    private int setPlayerHP;
    [SerializeField]
    private int setPlayerAttackPower;
    [SerializeField]
    private float setPlayerDamageRedcution;
    [SerializeField]
    private float setPlayerSpeed;
    #endregion


    



    void Awake()
    {
        MaxHP = setPlayerHP;
        HP = MaxHP;

        AttackPower = setPlayerAttackPower;
        DamageReduction = setPlayerDamageRedcution;
        Speed = setPlayerSpeed;
    }
    
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        
	}
}
