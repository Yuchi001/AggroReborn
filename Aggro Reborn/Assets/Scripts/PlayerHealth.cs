using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatsManager))]
public class PlayerHealth : MonoBehaviour, IDamagable
{
    public int Health { get; set; }
    private void Setup()
    {
        Health = GetComponent<StatsManager>().GetStatValue(EStatsType.MaxHealth);
    }
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ApplyDamage(int damage)
    {
        if (Health - damage <= 0)
        {
            Die();
            return;
        }

        Health -= damage;
    }
    public void ApplyEffect(EEffectType effectType, float time, int damage = 0, float repeatRate = -1)
    {

    }
    public void Die()
    {
        Health = 0;
    }
}
