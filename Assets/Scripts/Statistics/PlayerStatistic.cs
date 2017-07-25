using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

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



    public override void Reset()
    {
        MaxHP = setPlayerHP;
        HP = MaxHP;
        AttackPower = setPlayerAttackPower;
        Speed = setPlayerSpeed;
        DamageReduction = setPlayerDamageRedcution;
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

        if (HP <= 0)
            Die();
        
	}


    public void Die()
    {
        //set die animation
        Score myScore = new Score();
        myScore.Points = PointsManager.Instance.Points;
        myScore.EndPoint = null;
        myScore.DeviceID = SystemInfo.deviceUniqueIdentifier;
        myScore.Device = SystemInfo.deviceName;
        myScore.Date = System.DateTime.Now;
        BestScoresController.SendBestScoreToServer(myScore);
    }
}
