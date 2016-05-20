using UnityEngine;
using System.Collections;

public interface IVacuumable
{
    void OnPull();      // Actions the object will apply when triggered by an attractor
    void OnCollected(); // Actions the object will apply once collected
}
