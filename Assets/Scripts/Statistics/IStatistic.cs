using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatistic  {

    int MaxHP { get; set; }
    int HP { get; set; }
    int AttackPower { get; set; }
    
    /// <summary>
    /// must be normalized value, ex. if 0.80f the damage taken it's equal to damage * (1- 0.8f); reduce damage by 80%
    /// </summary>
    float DamageReduction { get; set; }
    float Speed { get; set; }
}
