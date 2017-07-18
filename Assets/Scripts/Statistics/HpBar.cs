using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour {

    [SerializeField][Tooltip("This field represent a statistic object where will be getted hp value")]
    private Statistics stat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //creating float beacuse 2 int division return 0;
        float hp = stat.HP;
        float maxHp = stat.MaxHP;
        Vector3 newScale = new Vector3(hp/maxHp, 1, 1);
        transform.localScale = newScale;

        if (Input.GetKeyDown(KeyCode.Space))
            stat.HP -= 5;
	}
}
