using UnityEngine;
using System.Collections;
using System;

public class HealthOrb : MonoBehaviour, IVacuumable, IExpirable
{
    [SerializeField] private float lifeTime = 0;

    private bool isExpiring;
    public bool IsExpiring
    {
        get
        {
            throw new NotImplementedException();
        }

        set
        {
            throw new NotImplementedException();
        }
    }

    public float LifeTime
    {
        get
        { return lifeTime; }
    }

    public IEnumerator ExpirtionCountDown()
    {
        throw new NotImplementedException();
    }

    public void OnCollected()
    {
        throw new NotImplementedException();
    }

    public void OnExpire()
    {
        throw new NotImplementedException();
    }

    public void OnPull()
    {
        throw new NotImplementedException();
    }
}
