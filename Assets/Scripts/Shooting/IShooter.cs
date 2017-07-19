using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShooter {

    void Shot();
    bool CanShot { get;  }
}
