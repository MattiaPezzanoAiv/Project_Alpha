using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet : IPoolable {

    float DestroyTime { get; set; }
    void SetOwner(GameObject go);

}
