using UnityEngine;
using System.Collections;

public interface IPoolable
{
    void OnGet();
    void OnRecycle();
    GameObject GetActiveInstance();
    Pool Pool { get; set; }
}
