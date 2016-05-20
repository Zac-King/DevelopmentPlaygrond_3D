using UnityEngine;
using System.Collections;

public interface IExpirable
{
    float LifeTime { get; }             // read only instance property // How long object will be alive before it Expires (in Seconds)
    bool IsExpiring { get; set; }       // read-write instance property // Is the instance currently Expiring
    void OnExpire();                    // Instance Function // Actions to be done for the objects expiration
    IEnumerator ExpirtionCountDown();   // Instance Coroutine // countdown till expire
}