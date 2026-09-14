using System;
using UnityEngine;


public class TakeDamage : MonoBehaviour
{
    public static event Action OnPlayerDamaged;
    public Hpmanager hpmanager;

    public void takeDamage(float amount)
    {
        hpmanager.health -= amount;
        OnPlayerDamaged?.Invoke();
    }
}
