using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int HitPoints;
    public int MaxHitPoints = 100;
    public int HealthRegeneration = 1;


    public int ManaPoints;
    public int MaxManaPoints = 100;
    public int ManaRegeneration = 1;

    public int Damage = 25;

    public void Start()
    {
        HitPoints = MaxHitPoints;
        ManaPoints = MaxManaPoints;
    }
}
