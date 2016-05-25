using UnityEngine;

public interface IPickUp
{
    void OnPull(GameObject Puller);  // Actions the object will apply when triggered by an attractor
    void OnCollected();         // Actions the object will apply once collected
}
